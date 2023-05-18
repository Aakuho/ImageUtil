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
        public convertIndividual()
        {
            InitializeComponent();
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            int buttonAmount = 0;
            foreach (KeyValuePair<String, Type> kvp in Program.convertClasses)
            {
                Converter converterInstance = (Converter)Activator.CreateInstance(kvp.Value);
                String format = converterInstance.toFormat;

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
            Console.WriteLine("Skill issue");
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.webp, *.bpm)|*.jpg;*.jpeg;*.png;*.webp;*.bmp|All files (*.*)|*.*";
            openFileDialog.Multiselect = true;
            switch (openFileDialog.ShowDialog())
            {
                case DialogResult.OK:
                    foreach (string file in openFileDialog.FileNames) { files.Add(file); }

                    break;
                default:
                    Console.WriteLine("User cancelled the selection");
                    break;
            }

        }

        String activeFormat = "";

        // yoink
        private void ButtonClick(object sender, EventArgs e)
        {

            FormatButton activeButton = ((FormatButton)sender);
            activeFormat = activeButton.formatName;
            // Toggle isSelected
            foreach (FormatButton fb in buttons) { fb.Default(); }
            activeButton.Highlight();
            Console.WriteLine(activeFormat);

        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            foreach (Converter convertor in Program.converters)
            {
                if (convertor.toFormat == activeFormat)
                {
                    convertor.convert(files, keepFiles);
                    this.files = new List<string>();
                }
            }
        }

        private void btnKeepFiles_Click(object sender, EventArgs e)
        {
            if (!keepFiles) { keepFiles = true; btnKeepFiles.BackColor = Color.FromArgb(80, 80, 80); }
            else { keepFiles = false; btnKeepFiles.BackColor = Color.FromArgb(60, 60, 60); }
        }
    }
}
