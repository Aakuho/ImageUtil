using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Drawing.Imaging;
using System.IO;
using ImageUtil.structure;

namespace ImageUtil.childForms
{
    public partial class convertBulk : Form
    {
        public List<FormatButton> buttons = new List<FormatButton>();
        private List<String> files = new List<string>();
        public convertBulk()
        {
            InitializeComponent();
            foreach (Converter converter in Program.converters)
            {
                String format = converter.toFormat;
                Console.WriteLine(format);
                buttons.Add(new FormatButton($"btn{format}", format.ToUpper(), format, 0, (1 + Program.formats.IndexOf(format)) * 60));
            }
            foreach (var button in buttons)
            {
                panelButtons.Controls.Add(button);
            }
        }

            private void btnFileSelection_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string folderPath = dialog.SelectedPath;
                string[] dirFiles = Directory.GetFiles(folderPath);

                foreach (string file in dirFiles)
                {
                    Console.WriteLine(Path.GetExtension(file));
                    if (Program.formats.Contains(Path.GetExtension(file))){ files.Add(file);  }
                }
            }
        }
        String activeFormat = "";

        private void btnConvert_Click(object sender, EventArgs e)
        {
            foreach (String filePath in files)
            {

                String name = Path.GetFileNameWithoutExtension(filePath);
                using ( Image sourceImage = Image.FromFile(filePath) ){
                    ImageFormat format = (ImageFormat)new ImageFormatConverter().ConvertFromString(activeFormat);
                    sourceImage.Save($"{Path.GetDirectoryName(filePath)}\\{name}.{activeFormat}", format);
                }
            }
        }


    }
}
