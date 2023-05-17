using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;
using ImageUtil.converters;
using ImageUtil.structure;
using System.IO;

namespace ImageUtil
{
    static class Program
    {
        // DEPRECATED Register new formats here, only if they are supported by the Image library
        public static List<String> formats = new List<String>
        {
            "jpg",
            "png",
            "bmp",
            "webp",
            "tga",
            "jpeg"
        };

        // Registed new converters here
        // C# Image library by default supports:
        /*
         * Bmp      DO
         * Gif      DONT
         * Icon     DO
         * Jpeg     DO
         * Png      DO
         * Tiff     DONT
         * Webp     DO
         */
        public static List<Converter> converters = new List<Converter>
        {
            new JpgConverter(),
            new PngConverter(),
            new BmpConverter(),
            new IconConverter(),
            new WebpConverter()
        };



        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ParentForm());
        }


        public static List<String> filterFiles (List<String> directory, String suffix) 
        {
            List<String> returnFiles = new List<String>();
            foreach (String file in directory)
            {
                if (Path.GetExtension(file).Remove(0, 1) == suffix) { returnFiles.Add(file); }
            }

            return returnFiles;
        }   
    }
}
