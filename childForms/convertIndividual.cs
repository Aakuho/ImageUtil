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
            /*foreach (Converter converter in Program.converters)
            {
                String format = converter.toFormat;
                buttons.Add(new FormatButton($"btn{format}", format.ToUpper(), format, 0, (1 + Program.formats.IndexOf(format)) * 60));
            }
            */
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
                    convertor.convert(files, true);
                }
            }


            /*if (Program.convertClasses.TryGetValue(activeFormat, out Type convertClass))
            {
                Converter convertInstance = (Converter)Activator.CreateInstance(convertClass);
                convertInstance.convert(files, true);
            }
            Console.WriteLine(Program.convertClasses.TryGetValue(activeFormat, out Type cc));
            */
        }
    }
}
