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
using Microsoft.WindowsAPICodePack.Dialogs;

namespace ImageUtil.childForms
{
    public partial class convertBulk : Form
    {
        public List<FormatButton> buttons;
        public List<String> files;
        public bool keepFiles;
        public int filesAmount;
        public String activeFormat = "";
        /*
         * step 0 - No files selected, formats, keep files and convert hidden and disabled
         * step 1 - Files selected formats and keep files shown
         * step 2 - Files and format selected, show convert
         */
        public int step = 0; 

        public convertBulk()
        {
            buttons = new List<FormatButton>();
            files = new List<String>();

            InitializeComponent();
            btnConvert.BackColor = Color.FromArgb(40, 40, 40);
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            int buttonAmount = 0;
            foreach (Converter cv in Program.converters)
            {
                String format = cv.toFormat;
                buttons.Add(new FormatButton($"btn{format}", format.ToUpper(), format, 0, buttonAmount * 60));
                buttonAmount++;
            }
            foreach (var button in buttons)
            {
                panelButtons.Controls.Add(button);
                button.Click += new EventHandler(ButtonClick);
            }
            keepFiles = true; btnKeepFiles.BackColor = Color.FromArgb(80, 80, 80); btnKeepFiles.Text = "✓ Keep files";
            updateStep(0);
        }

        private void updateStep(int updatedStep)
        {
            step = updatedStep;
            switch (step)
            {
                case 0:
                    labelSource.Visible = false;
                    panelButtons.Visible = false;
                    btnKeepFiles.Visible = false;
                    btnConvert.Enabled = false;
                    btnConvert.Visible = false;
                    break;
                case 1:
                    labelSource.Visible = true;
                    panelButtons.Visible = true;
                    btnKeepFiles.Visible = true;
                    btnConvert.Enabled = false;
                    btnConvert.Visible = false;
                    labelFilesHeader.Text = "Usable file(s)";
                    keepFiles = true; btnKeepFiles.BackColor = Color.FromArgb(80, 80, 80); btnKeepFiles.Text = "✓ Keep files";
                    break;
                case 2:
                    labelSource.Visible = true;
                    panelButtons.Visible = true;
                    btnKeepFiles.Visible = true;
                    btnConvert.Enabled = true;
                    btnConvert.Visible = true;
                    labelFilesHeader.Text = "File(s) selected for conversion";
                    List<String> ff = Program.organizeLoadedFiles(files).Split("\n".ToCharArray()).ToList();
                    ff.RemoveAll(n => n.EndsWith(activeFormat));
                    labelFiles.Text = String.Join("\n", ff);
                    break;
            }
                
        }

        private void ButtonClick(object sender, EventArgs e)
        {

            FormatButton activeButton = ((FormatButton)sender);
            activeFormat = activeButton.formatName;
            // Toggle isSelected
            foreach (FormatButton fb in buttons) { fb.Default(); }
            activeButton.Highlight();
            updateConvertButton();
            updateStep(2);

        }

        private void updateConvertButton()
        {
            if (files.Count > 0)
            {
                btnConvert.Text = $"Convert {Program.filterFiles(files, activeFormat).Count} file(s)";
                btnConvert.BackColor = Color.FromArgb(60, 60, 60);
            }
            else
            {
                btnConvert.BackColor = Color.FromArgb(40, 40, 40);
                btnConvert.Text = $"Convert";
            }
        }
        private void resetForm()
        {
            files = new List<string>();
            labelFiles.Text = "";
            labelFilesHeader.Text = "";
            buttons.ForEach(btn => btn.Default());
            keepFiles = false; btnKeepFiles.BackColor = Color.FromArgb(40, 40, 40);
            activeFormat = "";
            updateConvertButton();
        }

        private void btnFileSelection_Click(object sender, EventArgs e)
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
            }
            updateStep(1);
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            foreach (Converter convertor in Program.converters)
            {
                if (convertor.toFormat == activeFormat) {
                    convertor.convert(Program.filterFiles(files, activeFormat), keepFiles);
                }
            }
            files = new List<string>();
            // reset everything to it's base form
            files = new List<string>();
            labelFiles.Text = "";
            labelFilesHeader.Text = "";
            buttons.ForEach(btn => btn.Default());
            keepFiles = false; btnKeepFiles.BackColor = Color.FromArgb(40, 40, 40);
            activeFormat = "";
            updateConvertButton();
            updateStep(0);
        }

        private void btnKeepFiles_Click(object sender, EventArgs e)
        {
            updateKeepFiles();
        }

        private void updateKeepFiles()
        {
            if (!keepFiles) { keepFiles = true; btnKeepFiles.BackColor = Color.FromArgb(80, 80, 80); btnKeepFiles.Text = "✓ Keep files"; }
            else { keepFiles = false; btnKeepFiles.BackColor = Color.FromArgb(40, 40, 40); btnKeepFiles.Text = "✕ Keep files"; }
        }
    }
}
