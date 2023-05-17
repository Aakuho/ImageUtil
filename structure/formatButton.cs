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
    public class FormatButton : Button
    {
        public Button button2;
        public String name;
        public String text;
        public String formatName;

        public int x;
        public int y;
        public bool isSelected;
        public bool isDisabled;
        public FormatButton(string name, string text, string formatName, int x, int y)
        {
            Button button = this;
            this.name = name;
            this.text = text;
            this.formatName = formatName;
            this.x = x;
            this.y = y;
            
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

        public FormatButton(string name, string text, string formatName)
        {
            Button button = this;
            this.name = name;
            this.text = text;
            this.formatName = formatName;
            
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

        public void Highlight() { this.BackColor = Color.FromArgb(80, 80, 80); }
        public void Default() { this.BackColor = Color.FromArgb(60, 60, 60);this.isDisabled = false; }
        public void Disable() { this.BackColor = Color.FromArgb(40, 40, 40); this.isDisabled = true; }
    }
}