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
            files2.RemoveAll(x => x.EndsWith(this.toFormat));

            int successful = 0;

            if (!keepFiles)
            {
                DialogResult overwrite = MessageBox.Show("This action will overwrite existing files. Continue?", "Overwrite", MessageBoxButtons.YesNo);
                if ( overwrite == DialogResult.No) { return new List<bool>(); }
            }

            foreach (String file in files)
            {
                Console.WriteLine($"Files to convert: {files2.Count}");
                String name = Path.GetFileNameWithoutExtension(file);
                try
                {
                    using (Image sourceImage = Image.FromFile(file))
                    {
                        ImageFormat format = (ImageFormat)new ImageFormatConverter().ConvertFromString(this.toFormat);
                        sourceImage.Save($"{Path.GetDirectoryName(file)}\\{name}.{this.toFormat}", format);
                        result.Add(true);
                        successful++; 
                    }
                    if (!keepFiles) { File.Delete(file); }
                }
                catch (Exception ex)
                {
                    // Switch with Exception case is not supported in my current version of C#, bummer
                    // cancel the image convert and display the error message to the user
                    if ( ex is BadImageFormatException ) { }
                    if ( ex is NotSupportedException ) { }
                    if ( ex is System.Security.SecurityException ) { }

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

