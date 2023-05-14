using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using System.Collections;

namespace ImageUtil.childForms
{
    public partial class convertBulk : Form
    {
        public convertBulk()
        {
            InitializeComponent();
        }

        private ArrayList files = new ArrayList();

        private void btnFileSelection_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            // add formats here
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";
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

        private void btnConvert_Click(object sender, EventArgs e)
        {

        }
    }
}
