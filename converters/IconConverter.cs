using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageUtil;
using ImageUtil.structure;

namespace ImageUtil.converters
{
    public class IconConverter : Converter
    {
        public IconConverter()
        {
            this.toFormat = "ico";
        }

        public override void convert(List<String> files, bool keepFiles) { }


    }
}
