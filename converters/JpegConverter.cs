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
    public class JpegConverter : Converter
    {
        public JpegConverter() 
        {
            this.toFormat = "jpeg"; 
        }

        public override List<bool> convert(List<String> files, bool keepFiles)
        {
            List<bool> results = base.convert(files, keepFiles);

            return results;
        }
    }
}
