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
            filesAmount = 0;
            foreach (String file in files)
            {
                if (!file.EndsWith(activeFormat)) { filesAmount++; }
                btnConvert.Text = $"Convert {filesAmount} file(s)";
            }
            if (files.Count > 0)
            {
                btnConvert.BackColor = Color.FromArgb(60, 60, 60);
            }
        }

        private void btnFileSelection_Click(object sender, EventArgs e)
        {
            files = new List<string>();
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string folderPath = dialog.SelectedPath;
                string[] dirFiles = Directory.GetFiles(folderPath);

                foreach (string file in dirFiles)
                {
                    files.Add(file);
                }
            }
            updateConvertButton();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            foreach (Converter convertor in Program.converters)
            {
                if (convertor.toFormat == activeFormat) { convertor.convert(files, keepFiles); }
            }
            files = new List<string>();

        }

        private void btnKeepFiles_Click(object sender, EventArgs e)
        {
            if (!keepFiles) { keepFiles= true; btnKeepFiles.BackColor = Color.FromArgb(80, 80, 80); }
            else { keepFiles = false; btnKeepFiles.BackColor = Color.FromArgb(60, 60, 60); }
        }
    }
}
