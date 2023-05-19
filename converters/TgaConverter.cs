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
    // FOR TESTING PURPOSES, NOT TO BE IN FINAL BUILD

    public class TgaConverter : Converter
    {
        public TgaConverter()
        {
            this.toFormat = "tga";
        }

        public override List<bool> convert(List<String> files, bool keepFiles)
        {
            List<bool> results = base.convert(files, keepFiles);
            return results;
        }
    }
}
