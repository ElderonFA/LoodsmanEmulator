using Ascon.Plm.Loodsman.PluginSDK;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoodsmanEmulator
{
    public class LinksDataKeeper
    {
        private INetPluginCall NPC;

        private ComboBox dropBoxForLinks;
        private ListView listViewLinksInfo;

        private List<LinkData> linkDatas = new List<LinkData>();
        public List<LinkData> LinkDatas => linkDatas;

        private Dictionary<int, string> linksIconsIDInImageList = new Dictionary<int, string>();

        List<TypeHasLinks> typesAndLinks = new List<TypeHasLinks>();

        private string currentLinkName;
        private string selectedId;
        public void SetSelectedID(string id) 
        {
            selectedId = id;
        }

        private List<string> allTypesNames;

        public LinksDataKeeper(INetPluginCall NPC, ComboBox comboBoxLinkNames, ListView listViewLinksInfo, List<string> allTypesNames)  
        {
            this.NPC = NPC;
            this.listViewLinksInfo = listViewLinksInfo;
            this.allTypesNames = allTypesNames;

            listViewLinksInfo.SmallImageList = new ImageList();

            dropBoxForLinks = comboBoxLinkNames;
            var data = NPC.GetDataTable("GetLinkList");
            var imgList = listViewLinksInfo.SmallImageList.Images;

            foreach (DataRow row in data.Rows)
            {
                var linkData = new LinkData(
                    row["_ID"],
                    row["_NAME"],
                    row["_INVERSENAME"],
                    row["_TYPE"],
                    row["_ICON"],
                    row["_ORDER"]
                );

                linkDatas.Add(linkData);

                linksIconsIDInImageList[imgList.Count] = row["_NAME"].ToString();
                imgList.Add(Utils.byteArrayToImage(row["_ICON"] as byte[]));
            }

            foreach (var typeName in allTypesNames)
            {
                var dataHasLinks = NPC.GetDataTable("GetInfoAboutType", typeName, 11);

                var listLinks = new List<string>();
                foreach (DataRow row1 in dataHasLinks.Rows)
                {
                    listLinks.Add(row1["_NAME"].ToString());
                }

                typesAndLinks.Add(new TypeHasLinks(typeName, listLinks));
            }
        }

        public void SetLinkForSearch(string linkName)
        {
            dropBoxForLinks.Text = linkName;
            currentLinkName = linkName;
        }

        public void UpdateLinkInfoView()
        {
            listViewLinksInfo.Items.Clear();

            if (selectedId == "")
                return;
            
            var data = NPC.GetDataTable("GetLinkedFast", selectedId, dropBoxForLinks.Text, false);
            var imgIdx = linksIconsIDInImageList.First(x => x.Value == currentLinkName).Key;
            foreach (DataRow row in data.Rows)
            {
                var node = listViewLinksInfo.Items.Add(row["_PRODUCT"].ToString());
                node.SubItems.Add(row["_TYPE"].ToString());
                node.ImageIndex = imgIdx;
            }
        }

        public void UpdateListLinksInComboBox(string typeName)
        {
            dropBoxForLinks.Items.Clear();

            var linksForType = typesAndLinks.First(x => x.TypeName == typeName).LinksForType;

            foreach (var link in linksForType)
            {
                dropBoxForLinks.Items.Add(link);
            }

            SetLinkForSearch(dropBoxForLinks.Items[0].ToString());
        }
    }

    public class TypeHasLinks
    {
        public string TypeName { get; }
        public List<string> LinksForType { get; }

        public TypeHasLinks(string typeName, List<string> linksForType)
        {
            TypeName = typeName;
            LinksForType = linksForType;
        }
    }
}
