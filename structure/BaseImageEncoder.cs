using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageUtil.structure
{
    public class BaseImageEncoder
    {
        public void ConvertImage(string inputFilePath, string outputFilePath, string outputFormat)
        {
            using (Image inputImage = Image.FromFile(inputFilePath))
            {
                ImageFormat format = GetImageFormat(outputFormat);

                if (format != null)
                {
                    inputImage.Save(outputFilePath, format);
                }
                else
                {
                    throw new Exception("Unsupported output format");
                }
            }
        }

        private ImageFormat GetImageFormat(string outputFormat)
        {
            switch (outputFormat.ToLower())
            {
                case "png":
                    return ImageFormat.Png;
                case "jpg":
                case "jpeg":
                    return ImageFormat.Jpeg;
                case "bmp":
                    return ImageFormat.Bmp;
                case "ico":
                    return ImageFormat.Icon;
                case "tiff":
                    return ImageFormat.Tiff;
                case "gif":
                    return ImageFormat.Gif;
                default:
                    return null; // Format not registered or not in ImageFormat 
            }
        }
    }
}
