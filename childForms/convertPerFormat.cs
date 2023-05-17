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
        public String fromFormat;
        public String toFormat;
        public List<FormatButton> leftButtons;
        public List<FormatButton> rightButtons;
        public List<String> files;
             
        public convertPerFormat()
        {
            InitializeComponent();
            leftButtons = new List<FormatButton>();
            rightButtons = new List<FormatButton>();
            files = new List<String>();

            int buttonAmount = 0;

            foreach (KeyValuePair<String, Type> kvp in Program.convertClasses)
            {
                Converter converterInstance = (Converter)Activator.CreateInstance(kvp.Value);
                String format = converterInstance.toFormat;
                leftButtons.Add(new FormatButton($"btnLeft{format}", format.ToUpper(), format, 0, buttonAmount * 60));
                rightButtons.Add(new FormatButton($"btnRight{format}", format.ToUpper(), format, 0, buttonAmount * 60));
                buttonAmount++;
            }

            foreach (FormatButton fb in leftButtons)
            {
                panelButtonsLeft.Controls.Add(fb);
            }
            foreach (FormatButton fb in rightButtons)
            {
                panelButtonsRight.Controls.Add(fb);
            }
            FormatButton exButton = leftButtons[0];
            Console.WriteLine($"{exButton.Width} | {exButton.Height}");
            panelButtonsLeft.Size = new Size(exButton.Width, 400);
            panelButtonsRight.Size = new Size(exButton.Width, 400);
            panelButtonsRight.Location = new Point(exButton.Width + 60, panelButtonsRight.Location.Y);


            foreach (FormatButton fb in leftButtons)
            {
                fb.Click += new EventHandler(LeftButtonClick);
            }

            foreach (FormatButton fb in rightButtons)
            {
                fb.Click += new EventHandler(RightButtonClick);
            }


            this.AutoScaleMode = AutoScaleMode.Dpi;

        }

        private void selectButtonInColumn(List<FormatButton> fblist, FormatButton fb) {
            foreach (FormatButton iterButton in fblist)
            {
                if (!(iterButton.isDisabled)) { iterButton.Default();  }
            }
            fb.Highlight(); fb.isSelected = true;
        }

        private void LeftButtonClick(object sender, EventArgs e)
        {
            
            FormatButton activeButton = ((FormatButton)sender);
            fromFormat = activeButton.formatName;
            if (!(activeButton.isDisabled))
            {
                // Disable conversion to the same type
                resetButtonColors(rightButtons);
                selectButtonInColumn(leftButtons, activeButton);
                rightButtons[leftButtons.IndexOf(activeButton)].Disable();

                // Toggle isSelected
                foreach (FormatButton fb in leftButtons) { fb.isSelected = false; }
                activeButton.isSelected = true;
                Console.WriteLine($"Updated - from {fromFormat} to {toFormat}");
            }
        }

        private void RightButtonClick(object sender, EventArgs e)
        {
            FormatButton activeButton = ((FormatButton)sender);
            toFormat = activeButton.formatName;
            if (!(activeButton.isDisabled))
            {
                resetButtonColors(leftButtons);
                selectButtonInColumn(rightButtons, activeButton);
                leftButtons[rightButtons.IndexOf(activeButton)].Disable();

                foreach (FormatButton fb in rightButtons) { fb.isSelected = false; }
                activeButton.isSelected = true;
                Console.WriteLine($"Updated - from {fromFormat} to {toFormat}");
            }
        }


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
                    if (Program.convertClasses.ContainsKey(Path.GetExtension(file).Remove(0, 1))) { files.Add(file); }
                }
            }
        }
        public String formatFrom = "";
        public String formatTo = "";
        public bool keepFiles;
        Color defaultColor = Color.FromArgb(60, 60, 60);

        public void call()
        {
            Console.WriteLine("Called function");
        }

        private void resetButtonColors(List<FormatButton> fblist)
        {
            foreach ( FormatButton fb in fblist )
            {
                if (!(fb.isSelected)) { fb.Default(); }
            }
        }
        private void btnKeepFiles_Click(object sender, EventArgs e)
        {
            if ( keepFiles ) { keepFiles = false; btnKeepFiles.BackColor = defaultColor; }
            else { keepFiles = true; btnKeepFiles.BackColor = Color.FromArgb(80, 80, 80); }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (Program.convertClasses.TryGetValue(toFormat, out Type convertClass))
            {
                Converter convertInstance = (Converter)Activator.CreateInstance(convertClass);
                convertInstance.convert(files, keepFiles);
            }
            Console.WriteLine(Program.convertClasses.TryGetValue(toFormat, out Type cc));
        }
    }
}
