﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageUtil;
using ImageUtil.structure;

namespace ImageUtil.converters
{
    public class WebpConverter : Converter
    {
        public WebpConverter()
        {
            this.toFormat = "webp";
        }

        public override void convert(List<String> files, bool keepFiles)
        {
            try { base.convert(files, keepFiles); }
            catch (BadImageFormatException)
            {
                Console.WriteLine("Format is not yet supported");
                // switch case for additional formats
            }
        }
    }
}
