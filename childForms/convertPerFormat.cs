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
using ImageUtil.structure;


namespace ImageUtil.childForms
{
    public partial class convertPerFormat : Form
    {
        public convertPerFormat()
        {
            InitializeComponent();
            List<formatButton> leftButtons = new List<formatButton>();
            List<formatButton> rightButtons = new List<formatButton>();

            foreach (string format in Program.formats)
            {
                Console.WriteLine(format);
                leftButtons.Add(new formatButton($"btnLeft{format}", format.ToUpper(), format, 0, (1 + Program.formats.IndexOf(format)) * 60));
                rightButtons.Add(new formatButton($"btnRight{format}", format.ToUpper(), format, 0, (1 + Program.formats.IndexOf(format)) * 60));
            }

            foreach (formatButton fb in leftButtons)
            {
                panelButtonsLeft.Controls.Add(fb.button);
            }
            foreach ( formatButton fb in rightButtons)
            {
                panelButtonsRight.Controls.Add(fb.button);
            }
            formatButton exButton = leftButtons[0];
            Console.WriteLine($"{exButton.button.Width} | {exButton.button.Height}");
            panelButtonsLeft.Size = new Size(exButton.button.Width, 400);
            panelButtonsRight.Size = new Size(exButton.button.Width, 400);
            panelButtonsRight.Location = new Point(exButton.button.Width + 60, panelButtonsRight.Location.Y);

            this.AutoScaleMode = AutoScaleMode.Dpi;

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
            
        }

        private void resetButtonColorsRight()
        {
              
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
    }
}
