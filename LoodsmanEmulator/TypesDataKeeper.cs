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
        private Dictionary<string, int> typesIdInImgList;

        private Dictionary<string, string> typesIdAndName;

        public TypesDataKeeper()
        {
            typesIdInImgList = new Dictionary<string, int>();
            typesIdAndName   = new Dictionary<string, string>();
        }

        /// <summary> Добавляет данные в словари </summary>
        public void AddInfo(string typeID, string typeName, int idInImageList)
        {
            typesIdInImgList[typeID] = idInImageList;
            typesIdAndName[typeID]   = typeName;
        }

        /// <summary> Возвращает индекс типа в списке ImageList через ID </summary>
        public int GetImgIndexByID(object typeId)
        {
            return typesIdInImgList[typeId.ToString()];
        }

        /// <summary> Возвращает индекс типа в списке ImageList через название типа </summary>
        public int GetImgIndexByName(object typeName)
        {
            var typeID = GetTypeIdByName(typeName);
            return typesIdInImgList[typeID];
        }

        /// <summary> Возвращает название типа по ID </summary>
        public string GetTypeNameById(object typeId)
        {
            return typesIdAndName[typeId.ToString()];
        }

        /// <summary> Возвращает ID типа по названию </summary>
        public string GetTypeIdByName(object typeName)
        {
            return typesIdAndName.First(x => x.Value == typeName.ToString()).Key;
        }

        public List<string> GetAllTypesName()
        {
            var listTypesNames = new List<string>();

            foreach (var a in typesIdAndName)
            {
                listTypesNames.Add(a.Value);
            }

            return listTypesNames;
        }
    }
}
