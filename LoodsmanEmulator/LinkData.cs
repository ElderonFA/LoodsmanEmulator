using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoodsmanEmulator
{
    public class LinkData
    {
        public int    Id { get; }
        public string Name { get; }
        public string InverseName { get; }
        public int    Type { get; }
        public Image  Icon { get; }
        public object Order { get; }

        public LinkData(
            object id,
            object name,
            object inverseName,
            object type,
            object icon,
            object order) 
        {
            this.Id    = Convert.ToInt32(id);
            this.Name  = name.ToString();
            this.InverseName = inverseName.ToString();
            this.Type  = Convert.ToInt32(type);
            this.Icon  = Utils.byteArrayToImage(icon as byte[]);
            this.Order = order;
        }
    }
}
