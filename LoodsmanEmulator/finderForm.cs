using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ascon.Plm.Loodsman.PluginSDK;

namespace LoodsmanEmulator
{
    public partial class finderForm : Form
    {
        private mainForm mainForm;
        private INetPluginCall NPC { get; }

        private object idAttrName;

        public finderForm(INetPluginCall call, string firstSearch, mainForm currentMainForm)
        {
            InitializeComponent();

            mainForm = currentMainForm;
            NPC = call;

            var dataType = NPC.GetDataTable("GetInfoAboutAttribute", "Наименование", 1);
            idAttrName = dataType.Rows[0]["_ID"];

            Find(firstSearch);
        }

        private void Find(string searchText)
        {
            var idElements = "";

            finderListBox.Items.Clear();

            var dataObjects = NPC.GetDataTable("FindObjects",
                "",
                "", 
                "", 
                "",
                "Наименование\x2" + "Наименование Like \'%" + searchText + "%\'",
                string.Empty,
                string.Empty);

            //сбор всех id найденых элементов в одну строку
            foreach (DataRow item in dataObjects.Rows)
            {
                idElements += item["_ID_VERSION"].ToString() + ",";
            }
            idElements = idElements.TrimEnd(',');
            
            
            var dataAttr = NPC.GetDataTable("GetPropObjects3", idElements, idAttrName.ToString());

            foreach (DataRow item in dataAttr.Rows)
            {
                var name     = item["Наименование"].ToString();
                var idVer    = item["_ID_VERSION"];
                var Ver      = item["_VERSION"];
                var mainAttr = item["_PRODUCT"].ToString();
                var idtype   = item["_ID_TYPE"].ToString();
                var dCreate  = item["_CREATED"].ToString();

                var tagData = new TagData(idVer, Ver, mainAttr, idtype, false);

                var row = finderListBox.Items.Add(name);
                row.Tag = tagData;

                row.SubItems.Add(mainAttr);
                row.SubItems.Add(dCreate);
            }
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            if (finderTextBox.Text != "")
            {
                Find(finderTextBox.Text);
            }
            else
            {
                MessageBox.Show("Введите название объекта для поиска!");
            }
        }

        private void finderListBox_ItemActivate(Object sender, EventArgs e)
        {
            var item = finderListBox.SelectedItems[0];
            var tagData = item.Tag as TagData;
            var currentObjectID = tagData.IdVersion;

            List<string> path = new List<string>();

            // заполнение массива с идентификаторами пути до искомого файла
            var pathObjects = NPC.GetDataTable("FindPath", "", "", "", currentObjectID, "");

            foreach (DataRow row in pathObjects.Rows) 
            {
                path.Add(row["_ID_VERSION"].ToString());
            }

            if (tagData != null)
            {
                mainForm.CollapseAllInMainTreeView();
                mainForm.OpenFindedObject(path);
                this.Close();
                return;
            }

            MessageBox.Show("Ошибка! Данные в теге пусты!");
        }
    }
}
