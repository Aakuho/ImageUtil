using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;
using ImageUtil.converters;
using ImageUtil.structure;
using System.IO;
using System.Diagnostics;

namespace ImageUtil
{
    static class Program
    {

        public static List<Converter> converters = new List<Converter>
        {
            new JpegConverter(),
            new PngConverter(),
            new BmpConverter(),
            new IconConverter(),
            new TgaConverter()
        };

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ParentForm());
        }


        public static List<String> filterFiles(List<String> directory, String suffix)
        {
            List<String> returnFiles = new List<String>();
            foreach (String file in directory)
            {
                try
                {
                    if (Path.GetExtension(file).Remove(0, 1) == suffix) { returnFiles.Add(file); }
                }
                catch
                {
                    continue;
                }
            }

            return returnFiles;
        }

        public static void failedConvertCheck(List<bool> results, List<String> files)
        {
            Debug.Assert(results.Count == files.Count);
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
        }
    }

}