using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoodsmanEmulator
{
    public static class Utils
    {
        /// <summary> Преобразует массив байт в изображение с прозрачностью </summary>
        public static Image byteArrayToImage(byte[] bytesArr)
        {
            using (MemoryStream memstr = new MemoryStream(bytesArr))
            {
                Image img = Image.FromStream(memstr);
                Bitmap imgBitmap = new Bitmap(img);
                imgBitmap.MakeTransparent();

                return imgBitmap;
            }
        }

        /// <summary> Приводит числовое значение статуса БП к словесному </summary>
        public static string FormatBPState(string nonFormatValue)
        {
            switch (nonFormatValue)
            {
                case "0":
                    return "Новый";
                case "1":
                    return "Выполняется";
                case "2":
                    return "Приостановлен";
                case "3":
                    return "Выполнено";
                default:
                    return "Unknow state!";
            }
        }
    }
}
