using ImageUtil.structure;
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
        public List<FormatButton> buttons = new List<FormatButton>();
        private List<String> files = new List<string>();
        public convertIndividual()
        {
            InitializeComponent();
            foreach (string format in Program.formats)
            {
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
    }
}
