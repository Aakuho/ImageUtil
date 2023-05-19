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
using ImageUtil;
namespace ImageUtil.childForms
{
    public partial class convertIndividual : Form
    {
        public bool keepFiles;
        public List<FormatButton> buttons = new List<FormatButton>();
        public List<String> files = new List<string>();
        String activeFormat = "";
        public convertIndividual()
        {
            InitializeComponent();
            updateConvertButton();
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
        private void btnFileSelection_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.webp, *.bpm)|*.jpg;*.jpeg;*.png;*.webp;*.bmp|All files (*.*)|*.*";
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

        private void updateConvertButton()
        {
            if (files.Count > 0)
            {
                btnConvert.BackColor = Color.FromArgb(60, 60, 60);
            }
            else { btnConvert.BackColor = Color.FromArgb(40, 40, 40); }
        }

        // yoink
        private void ButtonClick(object sender, EventArgs e)
        {

            FormatButton activeButton = ((FormatButton)sender);
            activeFormat = activeButton.formatName;
            // Toggle isSelected
            foreach (FormatButton fb in buttons) { fb.Default(); }
            activeButton.Highlight();
            Console.WriteLine(activeFormat);
            updateConvertButton();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            foreach (Converter convertor in Program.converters)
            {
                if (convertor.toFormat == activeFormat)
                {
                    convertor.convert(Program.filterFiles(files, activeFormat), true);
                }
            }
            this.files = new List<string>();
        }

        private void btnKeepFiles_Click(object sender, EventArgs e)
        {
            if (!keepFiles) { keepFiles = true; btnKeepFiles.BackColor = Color.FromArgb(80, 80, 80); }
            else { keepFiles = false; btnKeepFiles.BackColor = Color.FromArgb(60, 60, 60); }
        }
    }
}
