using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using ImageUtil.structure;
using ImageUtil;

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
                Image sourceImage = null;
                BaseImageEncoder encoder = new BaseImageEncoder();
                
                try
                {
                    // If the format is not compatible, or something is wrong, it'll go straight to the exceptions
                        String path = $"{generateUniqueName(file, this.toFormat)}.{this.toFormat}";
                        //sourceImage.Save(path, format);
                        encoder.ConvertImage(file, path, this.toFormat);
                        result.Add(true);
                        successful++;
                        if (!keepFiles)
                        { 
                            File.Delete(file); // .. delete it, it won't go through and will cause an exception
                        }

                }
                catch (Exception e){
                    result.Add(false);
                    Console.WriteLine(e);
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
                    if (!result[statusIndex])
                    {
                        stringBuilder.Append(files[statusIndex].ToString() + "\n");
                    }
                }
                MessageBox.Show(stringBuilder.ToString(), "Result", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            return result;
        }

        // Some pictures may have an identical name, this will be solved by definitely not copying Windows's way of doing it nooooo
        public string generateUniqueName(String name, String format)
        {
            string baseName = Path.GetFileNameWithoutExtension(name);
            List<String> existingFilesWithDir = Directory.GetFiles(Path.GetDirectoryName(name)).ToList();
            List<String> existingFiles = new List<String>();
            foreach ( String file in existingFilesWithDir) { existingFiles.Add(Path.GetFileName(file));  }
            existingFiles.Remove(Path.GetFileName(name));
            String dir = Path.GetDirectoryName(name);

         
            String candidate = Path.GetFileNameWithoutExtension(name);
            if (!existingFiles.Contains(candidate + $".{format}")) { return $"{dir}\\{Path.GetFileNameWithoutExtension(name)}"; }

            for (int highestSuffix = 1; true; highestSuffix++)
            {
                if ( highestSuffix != 1) {
                    candidate = $"{candidate.Substring(0, candidate.IndexOf("("))}({highestSuffix})";
                }
                else { candidate = $"{candidate} ({highestSuffix})"; }
                if (!existingFiles.Contains($"{candidate}.{format}")) { return $"{dir}\\{candidate}"; }
            }
        }
    }
}