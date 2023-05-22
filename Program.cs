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
using System.Text;

namespace ImageUtil
{
    static class Program
    {
        // Creating a new form and registering it here will make it appear as a button in the UI
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


        // I want to convert only images that are not of the same format. Ex. cat.png -/> cat.png, but cat.jpg -> cat.png
        // Here I am checking the extensions of folders and comparing them to the suffix and returning all the ones without the same extension
        public static List<String> filterFiles(List<String> directory, String suffix)
        {
            List<String> returnFiles = new List<String>();
            foreach (String file in directory)
            {
                try { if (Path.GetExtension(file).Remove(0, 1) != suffix) { returnFiles.Add(file); }}
                catch{ continue; }
            }
            return returnFiles;
        }

        //I want the files that are sent to be shortened, so that they don't really take up that much space
        // So for example:  C:\Users\marti\Desktop\kitten.png
        //                  -> ...\Desktop\kitten.png 
        // Keep the name as well as one upper directory
        public static String organizeLoadedFiles(List<String> files)
        {
            StringBuilder sb = new StringBuilder();
            foreach (String file in files)
            {
                string[] path = file.Split('\\');
                if (path.Length > 2)
                {
                    sb.Append("...\\");
                    for (int i = path.Length - 2; i < path.Length; i++)
                    {
                        sb.Append(path[i - 1] + "\\");
                    }
                    sb.Append(Path.GetFileName(file) + "\n");
                }
                else 
                {
                    for (int i = 0; i < path.Length; i++)
                    {
                        sb.Append(path[i] + "\\");
                    }
                    sb.Append(Path.GetFileName(file) + "\n");
                }
            }
            return sb.ToString();

        }
    }
}