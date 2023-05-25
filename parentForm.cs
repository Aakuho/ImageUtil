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
    public partial class parentForm : Form
    {
        List<Button> buttonList;

        public parentForm()
        {
            // I did this way before I had dynamic buttons in mind
            InitializeComponent();
            HideSubMenus();
            buttonList = new List<Button>()
            {
                btnAboutProject,
                btnAboutCompany,
                btnAboutSchool,
                btnConvertBulk,
                btnConvertIndividual,
                btnConvertFormat
            };
        }

        // ssshhhhhhh
        public List<Panel> getPanels()
        {
            return new List<Panel> { panelAbout, panelChildForm, panelConvert, panelLogo, panelMenu };
        }
        public List<Button> getButtons()
        {
            return new List<Button> {   btnAbout, btnAboutCompany, btnAboutProject, btnAboutSchool,
                                        btnConvert, btnConvertBulk, btnConvertFormat, btnConvertIndividual,
                                        btnSettings };
        }

        private void HideSubMenus()
        {
            panelAbout.Visible = false;
            panelConvert.Visible = false;
        }

        private void ToggleSubMenu(Panel subMenu)
        {
            //if (subMenu.Visible ? subMenu.Visible = false : subMenu.Visible = true) ;
            HideSubMenus();
            subMenu.Visible = true;
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            ToggleSubMenu(panelAbout);
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            ToggleSubMenu(panelConvert);
        }

        public static Form activeForm = null;
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
        private void toggleButtonColor(Button button)
        {
            buttonList.ForEach(b => b.BackColor = Color.FromArgb(255, Color.FromArgb(Program.color5)));
            button.BackColor = Color.FromArgb(255, Color.FromArgb(Program.color6));
        }


        private void btnAboutProject_Click(object sender, EventArgs e)
        {
            openChildForm(new aboutProjectForm());
            toggleButtonColor(btnAboutProject);
        }

        private void btnAboutCompany_Click(object sender, EventArgs e)
        {
            openChildForm(new aboutCompanyForm());
            toggleButtonColor(btnAboutCompany);
        }

        private void btnAboutSchool_Click(object sender, EventArgs e)
        {
            openChildForm(new aboutSchoolForm());
            toggleButtonColor(btnAboutSchool);
        }

        private void btnConvertBulk_Click(object sender, EventArgs e)
        {
            openChildForm(new convertBulk());
            toggleButtonColor(btnConvertBulk);
        }

        private void btnConvertIndividual_Click(object sender, EventArgs e)
        {
            openChildForm(new convertIndividual());
            toggleButtonColor(btnConvertIndividual);
        }

        private void btnConvertFormat_Click(object sender, EventArgs e)
        {
            openChildForm(new convertPerFormat());
            toggleButtonColor(btnConvertFormat);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            openChildForm(new settingsForm(this));
        }
    }
}
