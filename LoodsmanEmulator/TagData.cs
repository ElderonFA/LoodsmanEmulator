using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoodsmanEmulator
{
    public class TagData
    {
        public string IdVersion { get; }
        public string Product { get; }
        public string Type { get; }
        public string Version { get; }
        private bool isDoc;
        public bool IsDocument => isDoc;

        /// <summary> Создание объекта для хранения в теге ноды </summary>
        /// <param name="IdVersion">Уникальный ID</param>
        /// <param name="Product">Ключевой атрибут</param>
        /// <param name="Type">ID типа</param>
        /// <param name="Version">Номер версии</param>
        /// <param name="isDoc">Является ли документом</param>
        public TagData(
            object IdVersion, 
            object Product, 
            object Type,
            object Version,
            object isDoc)
        {
            this.IdVersion = IdVersion.ToString();
            this.Product   = Product.ToString();
            this.Type      = Type.ToString();
            this.Version   = Version.ToString();
            this.isDoc     = isDoc.ToString() == "1";
        }
    }
}
