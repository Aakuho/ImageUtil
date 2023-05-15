using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace ImageUtil.childForms
{
    public partial class convertPerFormat : Form
    {
        public convertPerFormat()
        {
            InitializeComponent();
        }
        ArrayList files = new ArrayList();
        private void btnFileSelect_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = "C:\\Users";
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                string folderPath = dialog.FileName;
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
        public String formatFrom = "";
        public String formatTo = "";
        public bool keepFiles;
        Color defaultColor = Color.FromArgb(60, 60, 60);

        private void resetButtonColorsLeft()
        {
            btnFromPNG.BackColor = defaultColor;
            btnFromJPG.BackColor = defaultColor;
            btnFromBMP.BackColor = defaultColor;
        }

        private void resetButtonColorsRight()
        {
            btnToPNG.BackColor = defaultColor;
            btnToJPG.BackColor = defaultColor;
            btnToBMP.BackColor = defaultColor;  
        }
        private void ToggleButtonLeft(Button button)
        {
            resetButtonColorsLeft();

            button.BackColor = Color.FromArgb(80, 80, 80);
            if (formatFrom == "") { btnConvert.BackColor = Color.FromArgb(50, 50, 50); }
            else { btnConvert.BackColor = Color.FromArgb(69, 69, 69); }
        }

        private void ToggleButtonRight(Button button)
        {
            resetButtonColorsRight();

            button.BackColor = Color.FromArgb(80, 80, 80);
            if (formatFrom == "") { btnConvert.BackColor = Color.FromArgb(50, 50, 50); }
            else { btnConvert.BackColor = Color.FromArgb(69, 69, 69); }
        }
        private void btnKeepFiles_Click(object sender, EventArgs e)
        {
            if ( keepFiles ) { keepFiles = false; btnKeepFiles.BackColor = defaultColor; }
            else { keepFiles = true; btnKeepFiles.BackColor = Color.FromArgb(80, 80, 80); }
        }

        private void btnFromPNG_Click(object sender, EventArgs e)
        { formatFrom = "png"; ToggleButtonLeft(btnFromPNG); }

        private void btnFromJPG_Click(object sender, EventArgs e)
        { formatFrom = "jpeg"; ToggleButtonLeft(btnFromJPG); }

        private void btnFromBMP_Click(object sender, EventArgs e)
        { formatFrom = "bmp"; ToggleButtonLeft(btnFromBMP); }

        private void btnToPNG_Click(object sender, EventArgs e)
        { formatTo = "png"; ToggleButtonRight(btnToPNG); }

        private void btnToJPG_Click(object sender, EventArgs e)
        { formatTo = "jpeg"; ToggleButtonRight(btnToJPG); }

        private void btnToBMP_Click(object sender, EventArgs e)
        { formatTo = "bmp"; ToggleButtonRight(btnToBMP); }
    }
}
