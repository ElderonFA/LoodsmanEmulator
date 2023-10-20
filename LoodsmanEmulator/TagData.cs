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
        public string Version { get; }
        public string Product { get; }
        public string idType { get; }

        private bool isDoc;
        public bool IsDocument => isDoc;

        public TagData(
            object IdVersion, 
            object Product, 
            object idType,
            object Version,
            object isDoc)
        {
            this.IdVersion = IdVersion.ToString();
            this.Product   = Product.ToString();
            this.idType    = idType.ToString();
            this.Version   = Version.ToString();
            this.isDoc     = isDoc.ToString() == "1";
        }
    }
}
