using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageUtil
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            HideSubMenus();
        }

        private void HideSubMenus()
        {
            panelAbout.Visible = false;
            panelConvert.Visible = false;
        }

        private void ToggleSubMenu(Panel subMenu)
        {
            if (subMenu.Visible ? subMenu.Visible = false : subMenu.Visible = true) ;
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            ToggleSubMenu(panelAbout);
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            ToggleSubMenu(panelConvert);
        }
    }
}
