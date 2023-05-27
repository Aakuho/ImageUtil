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
        public String fromFormat = "";
        public String toFormat = "";
        public List<FormatButton> leftButtons;
        public List<FormatButton> rightButtons;
        public List<String> files;
        public bool keepFiles;
        public int filesAmount = 0;
        public int step;

        public convertPerFormat()
        {
            InitializeComponent();
            updateStep(0);
            btnKeepFiles.Text = "✕ Keep files";


            leftButtons = new List<FormatButton>();
            rightButtons = new List<FormatButton>();
            files = new List<String>();

            int buttonAmount = 0;

            foreach (Converter cv in Program.converters)
            {
                String format = cv.toFormat;
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

        private void updateStep(int updatedStep)
        {
            step = updatedStep;
            switch (step)
            {
                case 0:
                    labelSource.Visible = false;
                    labelDestination.Visible = false;
                    panelButtonsLeft.Visible = false;
                    panelButtonsRight.Visible = false;
                    btnKeepFiles.Visible = false;
                    btnConvert.Enabled = false;
                    btnConvert.Visible = false;
                    break;
                case 1:
                    labelSource.Visible = true;
                    labelDestination.Visible = true;
                    panelButtonsLeft.Visible = true;
                    panelButtonsRight.Visible = true;
                    btnKeepFiles.Visible = true;
                    btnConvert.Enabled = false;
                    btnConvert.Visible = false;
                    labelFilesHeader.Text = "Available file(s):";
                    keepFiles = true; btnKeepFiles.BackColor = Color.FromArgb(80, 80, 80); btnKeepFiles.Text = "✓ Keep files";
                    break;
                case 2:
                    labelSource.Visible = true;
                    labelDestination.Visible = true;
                    panelButtonsLeft.Visible = true;
                    panelButtonsRight.Visible = true;
                    btnKeepFiles.Visible = true;
                    btnConvert.Enabled = true;
                    btnConvert.Visible = true;
                    labelFilesHeader.Text = "File(s) selected for conversion:";
                    List<String> ff = Program.organizeLoadedFiles(files).Split("\n".ToCharArray()).ToList();
                    ff.RemoveAll(n => !n.EndsWith(fromFormat));
                    if (fromFormat == "jpeg") 
                    { 
                        foreach ( String file in files)
                        {
                            if (file.EndsWith(".jpg")){ ff.Add(Path.GetFileName(file)); }
                        }
                    }
                    labelFiles.Text = String.Join("\n", ff);
                    break;
            }

        }

        private void selectButtonInColumn(List<FormatButton> fblist, FormatButton fb) {
            foreach (FormatButton iterButton in fblist)
            {
                if (!(iterButton.isDisabled)) { iterButton.Default(); }
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
                updateConvertButton();
                updateStep(2); 
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
                updateConvertButton();
            }
        }
        
        
        private void btnFileSelect_Click(object sender, EventArgs e)
        {
            resetForm();

            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = "C:\\Users";
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                string folderPath = dialog.FileName;
                string[] dirFiles = Directory.GetFiles(folderPath);
                List<String> dirFilesList = dirFiles.ToList<String>();
                dirFilesList.ForEach(f => files.Add(f));

                labelFiles.Text = Program.organizeLoadedFiles(files);
                updateStep(1);
            }
            
        }

        private void resetForm()
        {
            files = new List<string>();
            labelFiles.Text = "";
            labelFilesHeader.Text = "";
            leftButtons.ForEach(btn => btn.Default());
            rightButtons.ForEach(btn => btn.Default());
            keepFiles = false; btnKeepFiles.BackColor = Color.FromArgb(40, 40, 40);
            fromFormat = "";
            toFormat = "";
            updateConvertButton();
            updateStep(0);
        }
        private void updateConvertButton()
        {
            if (files.Count > 0 && fromFormat != "" && toFormat != "")
            {
                if (toFormat != null && fromFormat != null) { btnConvert.Text = $"Convert {Program.filterFilesPF(files, fromFormat, toFormat).Count} file(s)"; }           
                btnConvert.BackColor = Color.FromArgb(60, 60, 60);
            }
            else
            {
                btnConvert.BackColor = Color.FromArgb(40, 40, 40);
                btnConvert.Text = $"Convert";
            }
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
            if (!keepFiles) { keepFiles = true; btnKeepFiles.BackColor = Color.FromArgb(80, 80, 80); btnKeepFiles.Text = "✓ Keep files"; }
            else { keepFiles = false; btnKeepFiles.BackColor = Color.FromArgb(40, 40, 40); btnKeepFiles.Text = "✕ Keep files"; }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (!(btnConvert.BackColor == Color.FromArgb(60, 60, 60))) { return; }
            foreach (Converter convertor in Program.converters)
            {
                if (convertor.toFormat == toFormat)
                {
                    convertor.convert(Program.filterFilesPF(files, fromFormat, toFormat), keepFiles);
                }
            }
            // reset everything to it's base form
            resetForm();
        }

        private void convertPerFormat_Load(object sender, EventArgs e)
        {

        }
    }
}
