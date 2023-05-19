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
            string suffix = "";
            int successful = 0;

            foreach (String file in files2)
            {
                int duplicateAmount = 0;
                Console.WriteLine($"Files to convert: {files2.Count}"); // Informational
                String name = Path.GetFileNameWithoutExtension(file);
                Image sourceImage = null;

                try
                {
                    // If the format is not compatible, or something is wrong, it'll go straight to the exceptions
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
                        sourceImage.Dispose(); // using keyword normally disposes of the file automatically, but If I try to ..
                        if (!keepFiles)
                        {
                            File.Delete(file); // .. delete it, it won't go through and will cause an exception
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
                // TODO FIX
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append($"Successfully converted {successful} file(s), failed to convert {files2.Count - successful} file(s):\n");
                foreach (bool status in result)
                {
                    if (!status) { stringBuilder.Append(files[result.IndexOf(status)] + "\n"); }
                }
                MessageBox.Show(stringBuilder.ToString(), "Result", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            return result;
        }

        // Some pictures may have identical names, as I said previously. Putting a correct number in the parentheses is for some reason, difficult
        public int generateUniqueSuffix(String name)
        {
            // get all the directories- yeye we get that
            string baseName = Path.GetFileNameWithoutExtension(name);
            string[] existingFiles = Directory.GetFiles(Path.GetDirectoryName(name));
            int highestSuffix = 1; 

            foreach (string file in existingFiles)
            {
                string existingFileName = Path.GetFileNameWithoutExtension(file);

                // checking for matching base name
                if (existingFileName.StartsWith(baseName))
                {
                    // getting the suffix
                    string suffixString = existingFileName.Substring(baseName.Length);
                    if (suffixString.StartsWith(" (") && suffixString.EndsWith(")"))
                    {
                        // remove all the unimportant characters, such as ' ', '(', ')'
                        suffixString = suffixString.Substring(2, suffixString.Length - 3);
                        // Get the max suffix
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