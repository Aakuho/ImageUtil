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
        /*
         * Color 1-4 will be used as 4 dominant colors that will manipulate the general appearance. 
         * If the colors are not hard set, and are instead stored as variables, they can be changed during run time.
         */
        private String color1 = "";
        private String color2 = "";
        private String color3 = "";
        private String color4 = "";
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
