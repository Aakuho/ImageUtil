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
        private int step;
        public convertIndividual()
        {
            InitializeComponent();
            updateConvertButton();
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.btnKeepFiles.BackColor = Color.FromArgb(40, 40, 40);
            this.btnKeepFiles.Text = "✕ Keep files";
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
            labelFilesHeader.Text = "Loaded file(s):";
            labelFiles.Text = Program.organizeLoadedFiles(files);
            updateStep(1);
        }

        private void updateConvertButton()
        {
            if (files.Count > 0) { 
                btnConvert.Text = $"Convert {Program.filterFiles(files, activeFormat).Count} file(s)";
                btnConvert.BackColor = Color.FromArgb(60, 60, 60);
            }
            else { 
                btnConvert.BackColor = Color.FromArgb(40, 40, 40);
                btnConvert.Text = $"Convert";
            }
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            FormatButton activeButton = ((FormatButton)sender);
            activeFormat = activeButton.formatName;
            // Toggle isSelected
            foreach (FormatButton fb in buttons) { fb.Default(); }
            activeButton.Highlight();
            Console.WriteLine(activeFormat);
            updateConvertButton();
            updateStep(2);
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            foreach (Converter convertor in Program.converters)
            {
                if (convertor.toFormat == activeFormat)
                {
                    convertor.convert(Program.filterFiles(files, activeFormat), keepFiles);
                }
            }
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
            if (!keepFiles) { keepFiles = true; btnKeepFiles.BackColor = Color.FromArgb(80, 80, 80); btnKeepFiles.Text = "✓ Keep files"; }
            else { keepFiles = false; btnKeepFiles.BackColor = Color.FromArgb(40, 40, 40); btnKeepFiles.Text = "✕ Keep files"; }
        }
    }
}
