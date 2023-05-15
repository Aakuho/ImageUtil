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


namespace ImageUtil.childForms
{
    public partial class convertBulk : Form
    {
        public convertBulk()
        {
            InitializeComponent();
            btnConvert.BackColor = Color.FromArgb(50, 50, 50);
        }

        private ArrayList files = new ArrayList();

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
                    switch (Path.GetExtension(file))
                    {
                        case ".png":
                            files.Add(file);
                            break;
                        case ".jpg":
                            files.Add(file);
                            break;
                        case ".bmp":
                            files.Add(file);
                            break;
                        default: break;

                    }
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

        private void resetButtonColors()
        {
            Color defaultColor = Color.FromArgb(60, 60, 60);
            btnFormatPNG.BackColor = defaultColor;
            btnFormatJPEG.BackColor = defaultColor;
            btnFormatBMP.BackColor = defaultColor;
        }

        private void ToggleButton(Button button)
        {
            resetButtonColors();
            
            button.BackColor = Color.FromArgb(80, 80, 80);
            if (activeFormat == "") { btnConvert.BackColor = Color.FromArgb(50, 50, 50); } 
            else { btnConvert.BackColor = Color.FromArgb(69, 69, 69) ; }
        }

        private void btnFormatPNG_Click(object sender, EventArgs e)
        {
            activeFormat = "png";
            ToggleButton(btnFormatPNG);
        }

        private void btnFormatJPG_Click(object sender, EventArgs e)
        {
            activeFormat = "jpeg";
            ToggleButton(btnFormatJPEG); 
        }

        private void btnFormatBMP_Click(object sender, EventArgs e)
        {
            activeFormat = "bmp";
            ToggleButton(btnFormatBMP);
        }
    }
}
