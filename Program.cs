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
            new TgaConverter(),
            new GifConverter(),
            new TiffConverter()
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
            List<String> acceptibleFormats = new List<String>();

            Program.converters.ForEach(n => acceptibleFormats.Add(n.toFormat.ToLower()));
            acceptibleFormats.Add("jpg");
            foreach (String file in directory)
            {
                String filesuffix = Path.GetExtension(file).Remove(0, 1);
                // if (!directory.Any(c => Path.GetExtension(c).Remove(0, 1) == suffix)) { continue; } idiotic

                // goal:
                // Only add files to return files, that don't have the same suffix
                // Also, if there are no files with the suffix, refrain from returning directory.Count
                if (directory.All(f => f == suffix)) { continue; }
                try { if (filesuffix != suffix && acceptibleFormats.Any(n => n.ToLower() == filesuffix)) { returnFiles.Add(file); Console.WriteLine(suffix); }}
                catch{ continue; }
            }
            return returnFiles;
        }

        // Can't fit this into the normal filterFiles function. F
        public static List<String> filterFilesPF(List<String> directory, String from, String to)
        {
            List<String> returnFiles = new List<String>();
            foreach (String file in directory)
            {
                String format = Path.GetExtension(file).Remove(0, 1);
                if ( directory.All(f => f == from) ) { continue; }
                if ( format == to ) { continue; }
                try { if ( format == from ) { returnFiles.Add(file); Console.WriteLine(to); } }
                catch { continue; }
            }
            return returnFiles;
        }

        //I want the files that are sent to be shortened, so that they don't really take up that much space
        // So for example:  C:\Users\marti\Desktop\kitten.png
        //                  -> ...\Desktop\kitten.png 
        // Keep the name as well as one upper directory
        public static String organizeLoadedFiles(List<String> files)
        {
            List<String> acceptibleFormats = new List<String>();
            Program.converters.ForEach(n => acceptibleFormats.Add(n.toFormat.ToLower()));
            acceptibleFormats.Add("jpg");
            StringBuilder sb = new StringBuilder();

            foreach (String file in files)
            {
                String suffix = Path.GetExtension(file).Remove(0, 1);
                if (!acceptibleFormats.Any(n => n.ToLower() == suffix)) { continue; }
                string[] path = file.Split('\\');
                sb.Append(Path.GetFileName(file) + "\n");
            }
            return sb.ToString(); 

        }
    }
}