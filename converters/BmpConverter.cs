using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageUtil;
using ImageUtil.structure;

namespace ImageUtil.converters
{
    public class BmpConverter : Converter
    {
        public BmpConverter()
        {
            this.toFormat = "bmp";
        }

        public override List<bool> convert(List<String> files, bool keepFiles)
        {
            List<bool> results = base.convert(files, keepFiles);
            if (!results.All(x => x))
            {
                for (int i = 0; i < files.Count; i++)
                {
                    if (!results[i])
                    {
                        Console.WriteLine($"Failed to convert {files[i]}");
                    }
                }
            }

            return new List<bool>();
        }
    }
}
