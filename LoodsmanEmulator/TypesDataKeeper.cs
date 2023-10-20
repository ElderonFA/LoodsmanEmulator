using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoodsmanEmulator
{
    public class TypesDataKeeper
    {
        private Dictionary<string, int> typesIdInImageListWithID;
        private Dictionary<string, int> typesIdInImageListWithNAME;

        private Dictionary<string, string> typesIdxName;

        public TypesDataKeeper()
        {
            typesIdInImageListWithID   = new Dictionary<string, int>();
            typesIdInImageListWithNAME = new Dictionary<string, int>();

            typesIdxName    = new Dictionary<string, string>();
        }

        /// <summary>Добавление данных в словари </summary>
        public void AddInfo(string typeID, string typeName, int idInImageList)
        {
            typesIdInImageListWithID[typeID]     = idInImageList;
            typesIdInImageListWithNAME[typeName] = idInImageList;

            typesIdxName[typeID] = typeName;
        }

        /// <summary> Возвращает индекс типа в списке ImageList через ID</summary>
        public int GetImgIndexByID(object typeId)
        {
            return typesIdInImageListWithID[typeId.ToString()];
        }

        /// <summary> Возвращает индекс типа в списке ImageList через название типа</summary>
        public int GetImgIndexByName(object typeName)
        {
            return typesIdInImageListWithNAME[typeName.ToString()];
        }

        /// <summary> Возвращает название типа по ID </summary>
        public string GetTypeNameById(object typeId)
        {
            return typesIdxName[typeId.ToString()];
        }
    }
}
