﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageUtil.childForms;

namespace ImageUtil
{
    public partial class Form1 : Form
    {
        /*
         * Color 1-4 will be used as 4 dominant colors that will manipulate the general appearance. 
         * If the colors are not hard set, and are instead stored as variables, they can be changed during run time.
         */
        private Color color1 = Color.FromArgb(60, 60, 60);
        /*
         * Dominant color
         */
        private Color color2 = Color.FromArgb(69, 69, 69);
        /*
         * Buttons
         */
        private Color color3 = Color.FromArgb(50, 50, 50);
        /*
         * Restricted Buttons
         */

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

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null) { activeForm.Close(); }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnAboutProject_Click(object sender, EventArgs e)
        {
            openChildForm(new aboutProjectForm());
        }

        private void btnAboutCompany_Click(object sender, EventArgs e)
        {
            openChildForm(new aboutCompanyForm());
        }

        private void btnAboutSchool_Click(object sender, EventArgs e)
        {
            openChildForm(new aboutSchoolForm());
        }
    }
}
