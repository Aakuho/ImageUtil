using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageUtil.childForms
{
    public partial class convertIndividual : Form
    {
        public convertIndividual()
        {
            InitializeComponent();
        }
        private ArrayList files = new ArrayList();
        private void btnFileSelection_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";
            openFileDialog.Multiselect = true;
            switch (openFileDialog.ShowDialog())
            {
                case DialogResult.OK:
                    foreach (string file in openFileDialog.FileNames) { files.Add(file); Console.WriteLine(file); }

                    break;
                default:
                    Console.WriteLine("User cancelled the selection");
                    break;
            }
        }

        String activeFormat = "";

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
            else { btnConvert.BackColor = Color.FromArgb(69, 69, 69); }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            foreach (String filePath in files)
            {

                String name = Path.GetFileNameWithoutExtension(filePath);
                using (Image sourceImage = Image.FromFile(filePath))
                {
                    ImageFormat format = (ImageFormat)new ImageFormatConverter().ConvertFromString(activeFormat);
                    sourceImage.Save($"{Path.GetDirectoryName(filePath)}\\{name}.{activeFormat}", format);
                }
            }
        }

        private void btnFormatPNG_Click(object sender, EventArgs e)
        {
            activeFormat = "png";
            ToggleButton(btnFormatPNG);
        }

        private void btnFormatJPEG_Click(object sender, EventArgs e)
        {
            activeFormat = "jpeg";
            ToggleButton(btnFormatPNG);
        }

        private void btnFormatBMP_Click(object sender, EventArgs e)
        {
            activeFormat = "bmp";
            ToggleButton(btnFormatPNG);
        }
    }
}
