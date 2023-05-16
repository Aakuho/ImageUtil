using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.Integration;

using ImageUtil.childForms;

namespace ImageUtil.structure
{
    partial class formatButton 
    {
        public Button button;
        private String name {get; set;}
        private String text {get; set;}
        private String formatName { get; set;}

        public int x;
        public int y;
        public formatButton(string name, string text, string formatName, int x, int y)
        {
            this.name = name;
            this.text = text;
            this.formatName = formatName;
            this.x = x;
            this.y = y;
            this.button = new Button();

            // common design
            button.BackColor = Color.FromArgb(60, 60, 60);
            button.FlatAppearance.BorderSize = 0;
            button.FlatStyle = FlatStyle.Flat;
            button.ForeColor = Color.Gainsboro;
            button.Location = new Point(this.x, this.y);
            button.Name = this.name;
            button.Size = new Size(200, 50);
            button.TabIndex = 1;
            button.Text = this.text;
            button.TextAlign = ContentAlignment.MiddleCenter;
            button.UseVisualStyleBackColor = false;

        }

        public formatButton(string name, string text, string formatName)
        {
            this.name = name;
            this.text = text;
            this.formatName = formatName;
            this.button = new Button();

            // common design
            button.BackColor = Color.FromArgb(60, 60, 60);
            button.FlatAppearance.BorderSize = 0;
            button.FlatStyle = FlatStyle.Flat;
            button.ForeColor = Color.Gainsboro;
            button.Location = new Point(this.x, this.y);
            button.Name = this.name;
            button.AutoSize = false; 
            button.TextAlign = ContentAlignment.MiddleCenter; 
            button.Text = this.text;
            button.UseVisualStyleBackColor = false;

        }

        public void Highlight() { this.button.BackColor = Color.FromArgb(80, 80, 80); }
        public void Default() { this.button.BackColor = Color.FromArgb(60, 60, 60); }
    }
}