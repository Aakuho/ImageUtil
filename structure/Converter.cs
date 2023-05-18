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

        // Parent convert, uses default System.Drawing Image library
        // Usable formats in ./Program.cs
        public virtual List<bool> convert(List<String> files, bool keepFiles)
        {
            List<bool> result = new List<bool>();
            List<String> files2 = files;
            string suffix = "";
            files2.RemoveAll(x => x.EndsWith(this.toFormat));

            int successful = 0;
            foreach (String file in files2)
            {
                int duplicateAmount = 0;
                Console.WriteLine($"Files to convert: {files2.Count}");
                String name = Path.GetFileNameWithoutExtension(file);
                Image sourceImage = null;

                try
                {
                    ImageFormat format = (ImageFormat)new ImageFormatConverter().ConvertFromString(this.toFormat);
                    using (sourceImage = Image.FromFile(file))
                    {
                        foreach (String i in Directory.GetFiles(Path.GetDirectoryName(file)))
                        {
                            // If a file already exists, change duplicateAmount to 1 and create a suffix, that will be added during naming
                            if (Path.GetFileName(i).Contains($"{name}.{this.toFormat}")) { duplicateAmount++; suffix = $"({duplicateAmount})"; break; }
                            else { continue; }
                        }
                        // If duplicate amount is greater than 0, it means there are multiple files and I should create the (n) 

                        if (duplicateAmount > 0)
                        {
                            sourceImage.Save($"{Path.GetDirectoryName(file)}\\{name} ({generateUniqueSuffix(file)}).{this.toFormat}", format);
                        }
                        else
                        {
                            sourceImage.Save($"{Path.GetDirectoryName(file)}\\{name}.{this.toFormat}", format);
                        }
                        result.Add(true);
                        successful++;
                        sourceImage.Dispose();
                        if (!keepFiles)
                        {
                            File.Delete(file);
                        }
                    }
                }
                catch
                {
                    result.Add(false);
                }
            }
            if ( result.All(x => x) )
            {
                MessageBox.Show($"Successfully converted {files2.Count} file(s)", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            else { 
                // TODO
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append($"Successfully converted {successful} file(s), failed to convert {files2.Count - successful} file(s):\n");
                foreach (bool status in result)
                {
                    if (!status) { stringBuilder.Append(files2[result.IndexOf(status)] + "\n"); }
                }
                MessageBox.Show(stringBuilder.ToString(), "Result", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            return result;
        }
        public int generateUniqueSuffix(String name)
        {
            string baseName = Path.GetFileNameWithoutExtension(name);

            string[] existingFiles = Directory.GetFiles(Path.GetDirectoryName(name));
            int highestSuffix = 1;

            foreach (string file in existingFiles)
            {
                string existingFileName = Path.GetFileNameWithoutExtension(file);

                if (existingFileName.StartsWith(baseName))
                {
                    string suffixString = existingFileName.Substring(baseName.Length);
                    if (suffixString.StartsWith(" (") && suffixString.EndsWith(")"))
                    {
                        suffixString = suffixString.Substring(2, suffixString.Length - 3);

                        if (int.TryParse(suffixString, out int suffix))
                        {
                            highestSuffix = Math.Max(highestSuffix, suffix);
                        }
                    }
                }
            }
            return highestSuffix;
        }
    }
}