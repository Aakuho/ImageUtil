using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace ImageUtil.structure
{
    public class Converter
    {
        public String toFormat;

        // This convert will be called anytime someone tries to convert anything. If it doesn't go through this,
        // the person can code his own encoder in the separate classes. Also, this process can be removed by deleting
        // this line in the convert classes: List<bool> results = base.convert(files, keepFiles);
        public virtual List<bool> convert(List<String> files, bool keepFiles)
        {
            List<bool> result = new List<bool>();
            List<String> files2 = files;
            int successful = 0;

            foreach (String file in files2)
            {
                Console.WriteLine(file);
                String name = Path.GetFileNameWithoutExtension(file);
                Image sourceImage = null;

                try
                {
                    // If the format is not compatible, or something is wrong, it'll go straight to the exceptions
                    ImageFormat format = (ImageFormat)new ImageFormatConverter().ConvertFromString(this.toFormat);
                    using (sourceImage = Image.FromFile(file))
                    {
                        String path = $"{generateUniqueName(file)}.{this.toFormat}";
                        sourceImage.Save(path, format);
                        result.Add(true);
                        successful++;
                        sourceImage.Dispose(); // using keyword normally disposes of the file automatically, but If I try to ..
                        if (!keepFiles)
                        { 
                            File.Delete(file); // .. delete it, it won't go through and will cause an exception
                        }
                    }
                }
                catch {
                    result.Add(false);
                }
            }
            if ( result.All(x => x) )
            {
                MessageBox.Show($"Successfully converted {files2.Count} file(s)", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            else {  
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append($"Successfully converted {successful} file(s), failed to convert {files2.Count - successful} file(s):\n");
                for (int statusIndex = 0; statusIndex < result.Count; statusIndex++)
                {
                    Console.WriteLine(result[statusIndex]);
                    if (!result[statusIndex])
                    {
                        stringBuilder.Append(files[statusIndex].ToString() + "\n");
                    }
                }
                MessageBox.Show(stringBuilder.ToString(), "Result", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            return result;
        }

        // Some pictures may have an identical name, this will be solved by definitely not copying Windows's way of doing it nooooo
        public string generateUniqueName(String name)
        {
            string baseName = Path.GetFileNameWithoutExtension(name);
            string[] existingFiles = Directory.GetFiles(Path.GetDirectoryName(name));
            String dir = Path.GetDirectoryName(name);

            String candidate = $"{dir}\\{baseName}";
            if (!existingFiles.Contains(candidate + $".{toFormat}")) { return candidate; }

            for (int highestSuffix = 1; true; highestSuffix++)
            {
                candidate = $"{dir}\\{baseName} ({highestSuffix})";
                if (!existingFiles.Contains(candidate)) { return candidate; }
            }
        }
    }
}