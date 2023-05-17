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
        private List<String> files;
        public convertBulk()
        {
            buttons = new List<FormatButton>();
            files = new List<String>();

            InitializeComponent();
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

        private void ButtonClick(object sender, EventArgs e)
        {

            FormatButton activeButton = ((FormatButton)sender);
            activeFormat = activeButton.formatName;
            // Toggle isSelected
            foreach (FormatButton fb in buttons) { fb.Default(); }
            activeButton.Highlight();

        }

        private void btnFileSelection_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string folderPath = dialog.SelectedPath;
                string[] dirFiles = Directory.GetFiles(folderPath);

                foreach (string file in dirFiles)
                {
                    //if (Program.formats.Contains(Path.GetExtension(file).Remove(0, 1))){ files.Add(file); }
                }
            }
        }
        String activeFormat = "";

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (Program.convertClasses.TryGetValue(activeFormat, out Type convertClass))
            {
                Converter convertInstance = (Converter)Activator.CreateInstance(convertClass);
                convertInstance.convert(files, true);
            }
            Console.WriteLine(Program.convertClasses.TryGetValue(activeFormat, out Type cc));
        }
    }
}
