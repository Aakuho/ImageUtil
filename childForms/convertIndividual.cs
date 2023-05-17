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
            foreach (Converter converter in Program.converters)
            {
                String format = converter.toFormat;
                Console.WriteLine(format);
                buttons.Add(new FormatButton($"btn{format}", format.ToUpper(), format, 0, (1 + Program.formats.IndexOf(format)) * 60));
            }
            foreach (var button in buttons)
            {
                panelButtons.Controls.Add(button);
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
                    foreach (string file in openFileDialog.FileNames) { files.Add(file); activeFormat = Path.GetExtension(file).Remove(0, 1); }

                    break;
                default:
                    Console.WriteLine("User cancelled the selection");
                    break;
            }

        }

        String activeFormat = "";

        private void btnConvert_Click(object sender, EventArgs e)
        {
            Console.WriteLine("I am fucking trying");
            Console.WriteLine(activeFormat);
            if (Program.convertClasses.TryGetValue(activeFormat, out Type convertClass))
            {
                Console.WriteLine("No you're not faggot");
                Converter convertInstance = (Converter)Activator.CreateInstance(convertClass);
                convertInstance.convert(files, true);
            }
            Console.WriteLine(Program.convertClasses.TryGetValue(activeFormat, out Type cc));
        }
    }
}
