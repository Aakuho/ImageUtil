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

        public convertBulk()
        {
            buttons = new List<FormatButton>();
            files = new List<String>();

            InitializeComponent();
            btnConvert.BackColor = Color.FromArgb(40, 40, 40);
            this.btnKeepFiles.BackColor = Color.FromArgb(40, 40, 40);

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
        }

        private void ButtonClick(object sender, EventArgs e)
        {

            FormatButton activeButton = ((FormatButton)sender);
            activeFormat = activeButton.formatName;
            // Toggle isSelected
            foreach (FormatButton fb in buttons) { fb.Default(); }
            activeButton.Highlight();
            updateConvertButton();

        }

        private void updateConvertButton()
        {
            if (files.Count > 0) { 
                btnConvert.Text = $"Convert {Program.filterFiles(files, activeFormat).Count} file(s)";
                btnConvert.BackColor = Color.FromArgb(60, 60, 60);
            }
            else { btnConvert.BackColor = Color.FromArgb(40, 40, 40); }
        }

        private void btnFileSelection_Click(object sender, EventArgs e)
        {
            files = new List<string>();
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = "C:\\Users";
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                string folderPath = dialog.FileName;
                string[] dirFiles = Directory.GetFiles(folderPath);
                foreach (string file in dirFiles)
                {
                    foreach (Converter cv in Program.converters)
                    {
                        if (cv.toFormat == Path.GetExtension(file).Remove(0, 1)) { files.Add(file); }
                    }
                }
                labelFilesHeader.Text = "Loaded file(s):";
                labelFiles.Text = Program.organizeLoadedFiles(files);
            }
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

        }

        private void btnKeepFiles_Click(object sender, EventArgs e)
        {
            if (!keepFiles) { keepFiles = true; btnKeepFiles.BackColor = Color.FromArgb(80, 80, 80); }
            else { keepFiles = false; btnKeepFiles.BackColor = Color.FromArgb(40, 40, 40); }
        }
    }
}
