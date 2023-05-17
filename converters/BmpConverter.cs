using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public override void convert(List<String> files, bool keepFiles)
        {
            try { base.convert(files, keepFiles); }
            catch (Exception e)
            {
                //Console.WriteLine("Format is not yet supported");
                Console.WriteLine(e);
                // switch case for additional formats
            }
            

        }
    }
}
