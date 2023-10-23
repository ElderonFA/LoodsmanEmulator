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

        private string currentLinkName;
        private string lastId;

        public LinksDataKeeper(INetPluginCall NPC, ComboBox comboBoxLinkNames, ListView listViewLinksInfo) 
        {
            this.NPC = NPC;
            this.listViewLinksInfo = listViewLinksInfo;

            listViewLinksInfo.SmallImageList = new ImageList();

            dropBoxForLinks = comboBoxLinkNames;
            var data = NPC.GetDataTable("GetLinkList");
            var imgList = listViewLinksInfo.SmallImageList.Images;

            foreach (DataRow row in data.Rows)
            {
                var linkName = row["_NAME"].ToString();

                dropBoxForLinks.Items.Add(linkName);

                var linkData = new LinkData(
                    row["_ID"],
                    linkName,
                    row["_INVERSENAME"],
                    row["_TYPE"],
                    row["_ICON"],
                    row["_ORDER"]
                );

                linkDatas.Add(linkData);

                linksIconsIDInImageList[imgList.Count] = linkName;
                imgList.Add(Utils.byteArrayToImage(row["_ICON"] as byte[]));
            }

            SetLinkForSearch("Состоит из ...");
        } 

        public void SetLinkForSearch(string linkName)
        {
            dropBoxForLinks.Text = linkName;
            currentLinkName = linkName;
            
            UpdateLinkInfoView(lastId);
        }

        public void UpdateLinkInfoView(string id)
        {
            listViewLinksInfo.Items.Clear();

            if (id == "" && lastId == "")
                return;

            lastId = id;
            
            var data = NPC.GetDataTable("GetLinkedFast", id, dropBoxForLinks.Text, false);
            var imgIdx = linksIconsIDInImageList.First(x => x.Value == currentLinkName).Key;
            foreach (DataRow row in data.Rows)
            {
                var node = listViewLinksInfo.Items.Add(row["_PRODUCT"].ToString());
                node.SubItems.Add(row["_TYPE"].ToString());
                node.ImageIndex = imgIdx;
            }
        }
    }
}
