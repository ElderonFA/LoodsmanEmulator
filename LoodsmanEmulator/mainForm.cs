using Ascon.Plm.Loodsman.PluginSDK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LoodsmanEmulator
{
    public partial class mainForm : Form
    {
        private string dataBaseName;

        private static string imagesPath = "D:\\Projects VS\\LoodsmanEmulator\\images\\";

        public INetPluginCall NPC { get; }

        private TypesDataKeeper typesDataKeeper = new TypesDataKeeper();
        private LinksDataKeeper linksDataKeeper;

        public mainForm(INetPluginCall call)
        {
            InitializeComponent();
            InitImagesLists();

            dataBaseName = call.PluginCall.DBName;
            NPC = call;

            mainTreeView.Sort();

            //считывание данных о типах
            var typesData = NPC.GetDataTable("GetTypeList");

            foreach (DataRow td in typesData.Rows)
            {
                var img = Utils.byteArrayToImage(td["_ICON"] as byte[]);

                var tID = td["_ID"].ToString();
                var tNAME = td["_TYPENAME"].ToString();
                var idx = mainTreeView.ImageList.Images.Count;

                typesDataKeeper.AddInfo(tID, tNAME, idx);

                mainTreeView.ImageList.Images.Add(img);
            }

            linksDataKeeper = new LinksDataKeeper(NPC, comboBoxLinkNames, listViewLinksInfo, typesDataKeeper.GetAllTypesName());

            //сбор и добавление данных о каталогах самого верхнего уровня БД Лоцман
            var catalogsData = NPC.GetDataTable("GetProjectListEx", true);

            foreach (DataRow row in catalogsData.Rows)
            {
                var node = mainTreeView.Nodes.Add(row["_PRODUCT"].ToString());

                node.Tag = new TagData(row["_ID_VERSION"], row["_PRODUCT"], row["_TYPE"], row["_VERSION"], row["_DOCUMENT"]);
                node.ImageIndex = typesDataKeeper.GetImgIndexByName(row["_TYPE"]);

                node.Nodes.Add("Загрузка...");
            }
        }

        private void mainTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var selectedTagData = (TagData)e.Node.Tag;
            e.Node.SelectedImageIndex = e.Node.ImageIndex;

            UpdateViewAttributes(selectedTagData);

            UpdateViewFiles(selectedTagData);

            UpdateViewBP(selectedTagData);

            linksDataKeeper.SetSelectedID(selectedTagData.IdVersion);
            linksDataKeeper.UpdateListLinksInComboBox(selectedTagData.Type);
        }

        private void UpdateViewAttributes(TagData data)
        {
            attributesListView.Items.Clear();
            attributesListView.Groups.Clear();

            var attributesData = NPC.GetDataTable("GetInfoAboutVersion",
                data.Type,
                data.Product,
                data.Version,
                data.IdVersion,
                2);

            foreach (DataRow attributes in attributesData.Rows)
            {
                var attributeName = attributes["_NAME"].ToString();
                var attributeValue = attributes["_VALUE"].ToString();

                var newattribute = attributesListView.Items.Add(attributeName);
                newattribute.SubItems.Add(attributeValue);
            }
        }

        private void UpdateViewFiles(TagData data)
        {
            filesListView.Items.Clear();
            filesListView.Groups.Clear();

            var isDocument = data.IsDocument;

            if (isDocument)
            {
                var files = NPC.GetDataTable("GetInfoAboutVersionsFiles", data.IdVersion);
                
                foreach (DataRow file in files.Rows)
                {
                    var fileName = file["_NAME"].ToString();
                    var a = filesListView.Items.Add(fileName);
                    a.ImageIndex = 0;
                }
            }
        }

        private void UpdateViewBP(TagData data)
        {
            bpListView.Items.Clear();
            bpListView.Groups.Clear();

            var bpData = NPC.GetDataTable("GetProcessListByObject", dataBaseName, data.IdVersion);

            foreach (DataRow bp in bpData.Rows)
            {
                var bpName = bp["_ROUTENAME"].ToString();
                var bpState = bp["_WF_STATE"].ToString(); ;
                var bpInitiator = bp["_OWNERNAME"].ToString(); ;

                var item = bpListView.Items.Add(bpName);
                item.ImageIndex = Convert.ToInt32(bpState);
                item.SubItems.Add(Utils.FormatBPState(bpState));
                item.SubItems.Add(bpInitiator);
            }
        }
        

        private void mainTreeView_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Nodes[0].Text == "Загрузка...")
            {
                e.Node.Nodes[0].Remove();

                var nTagData = (TagData)e.Node.Tag;
                var elementsData = NPC.GetDataTable("GetLinkedFast", nTagData.IdVersion, "Состоит из ...", false);

                foreach (DataRow row in elementsData.Rows)
                {
                    var ID_VERS = row["_ID_VERSION"];
                    var VERS    = row["_VERSION"];
                    var PRODUCT = row["_PRODUCT"];
                    var TYPE    = row["_TYPE"];
                    var DOC     = row["_DOCUMENT"];

                    var newNode = e.Node.Nodes.Add(PRODUCT.ToString());

                    newNode.Tag = new TagData(ID_VERS, PRODUCT, TYPE, VERS, DOC);

                    newNode.ImageIndex = typesDataKeeper.GetImgIndexByName(TYPE);

                    newNode.Nodes.Add("Загрузка...");
                }

                var documentsData = NPC.GetDataTable("GetLinkedFast", nTagData.IdVersion, "Документы", false);

                foreach(DataRow row in documentsData.Rows)
                {
                    var ID_VERS = row["_ID_VERSION"];
                    var VERS    = row["_VERSION"];
                    var PRODUCT = row["_PRODUCT"];
                    var TYPE    = row["_TYPE"];
                    var DOC     = row["_DOCUMENT"];

                    var newNode = e.Node.Nodes.Add(PRODUCT.ToString());

                    newNode.Tag = new TagData(ID_VERS, PRODUCT, TYPE, VERS, DOC);

                    newNode.ImageIndex = typesDataKeeper.GetImgIndexByName(TYPE);
                }
            }
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            if (findTextBox.Text != "")
            {
                var newFinderForm = new finderForm(NPC, findTextBox.Text, this);
                newFinderForm.ShowDialog();
            }
        }

        public void OpenFindedObject(List<string> pathToObject, TreeNodeCollection currentNodeCollection = null, int stepInPath = 0)
        {
            currentNodeCollection = currentNodeCollection ?? mainTreeView.Nodes;
            var currentPosInPath = stepInPath;

            if (currentPosInPath == pathToObject.Count)
            {
                return;
            }

            foreach (TreeNode node in currentNodeCollection)
            {
                var tagData = node.Tag as TagData;
                if (tagData.IdVersion == pathToObject[stepInPath])
                {
                    node.Expand();
                    if (currentPosInPath == pathToObject.Count - 1)
                    {
                        mainTreeView.SelectedNode = node;
                        mainTreeView.Focus();
                        return;
                    }

                    currentPosInPath++;

                    OpenFindedObject(pathToObject, node.Nodes, currentPosInPath);
                }
            }
        }

        private void comboBoxLinkNames_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (linksDataKeeper != null)
            {
                linksDataKeeper.SetLinkForSearch(comboBoxLinkNames.SelectedItem.ToString()); 
                linksDataKeeper.UpdateLinkInfoView();
            }
        }

            public void CollapseAllInMainTreeView()
        {
            mainTreeView.CollapseAll();
        }

        private void InitImagesLists()
        {
            mainTreeView.ImageList       = new ImageList();
            filesListView.SmallImageList = new ImageList();
            bpListView.SmallImageList    = new ImageList();

            filesListView.SmallImageList.Images.Add(Image.FromFile(imagesPath + "Документ.bmp"));

            bpListView.SmallImageList.Images.Add(Image.FromFile(imagesPath + "bp\\Новый.bmp"));
            bpListView.SmallImageList.Images.Add(Image.FromFile(imagesPath + "bp\\Выполняется.bmp"));
            bpListView.SmallImageList.Images.Add(Image.FromFile(imagesPath + "bp\\Приостановлен.bmp"));
            bpListView.SmallImageList.Images.Add(Image.FromFile(imagesPath + "bp\\Выполнен.bmp"));
        }
    }
}
