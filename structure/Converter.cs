using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;

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
            int duplicateAmount = 0;

            if (!keepFiles)
            {
                DialogResult overwrite = MessageBox.Show("This action will overwrite existing files. Continue?", "Overwrite", MessageBoxButtons.YesNo);
                if ( overwrite == DialogResult.No) { return new List<bool>(); }
            }
            foreach (String file in files)
            {
                Console.WriteLine($"Files to convert: {files2.Count}");
                String name = Path.GetFileNameWithoutExtension(file);
                Image sourceImage = null;


                try { using (sourceImage = Image.FromFile(file))
                    {
                        
                        ImageFormat format = (ImageFormat)new ImageFormatConverter().ConvertFromString(this.toFormat);
                        foreach (String i in Directory.GetFiles(Path.GetDirectoryName(file)))
                        {
                            // If a file already exists, change duplicateAmount to 1 and create a suffix, that will be added during naming
                            if (Path.GetFileName(i).Contains($"{name}.{this.toFormat}")) { duplicateAmount++; suffix = $"({duplicateAmount})"; break; }
                            else { continue; }
                        }
                        // If duplicate amount is greater than 0, it means there are multiple files and I should create the (n) 

                        if (duplicateAmount > 0) { 
                            sourceImage.Save($"{Path.GetDirectoryName(file)}\\{name} {suffix}.{this.toFormat}", format); 
                        }
                        else { 
                            sourceImage.Save($"{Path.GetDirectoryName(file)}\\{name}.{this.toFormat}", format); 
                        }
                        result.Add(true);
                        successful++;
                        sourceImage.Dispose();
                        if (!keepFiles) { File.Delete(file); }

                    }
                }
                catch{
                    result.Add(false);
                }
            }
            if ( result.All(x => x) )
            {
                MessageBox.Show($"Successfully converted {files2.Count} file(s)", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else { MessageBox.Show($"Successfully converted {successful} file(s), failed to convert {files2.Count - successful} file(s)", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            return result;
        }
    }
}

