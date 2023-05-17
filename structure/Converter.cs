using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ImageUtil.structure
{
    public class Converter
    {
        public String toFormat;

        // Parent convert, uses default System.Drawing Image library
        // Usable formats in ./Program.cs
        public virtual void convert(List<String> files, bool keepFiles)
        {
           
            foreach (String file in files)
            {
                Console.WriteLine($"The active format during conversion is: {toFormat}");
                String name = Path.GetFileNameWithoutExtension(file);
                using (Image sourceImage = Image.FromFile(file))
                {
                    //ImageFormat format = (ImageFormat)new ImageFormatConverter().ConvertFromString(toFormat);
                    ImageFormat format = ImageFormat.Icon;
                    sourceImage.Save($"{Path.GetDirectoryName(file)}\\{name}.{toFormat}", format);
                }
            }
        }
    }
}

