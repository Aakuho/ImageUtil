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
    public class IconConverter : Converter
    {
        public IconConverter()
        {
            this.toFormat = "ico";
        }

        public override List<bool> convert(List<String> files, bool keepFiles)
        {
            List<bool> results = base.convert(files, keepFiles);
            Program.failedConvertCheck(results, files);

            return new List<bool>();
        }
    }
}
