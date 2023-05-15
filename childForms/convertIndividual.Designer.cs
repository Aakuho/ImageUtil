namespace ImageUtil.childForms
{
    partial class convertIndividual
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnFormatBMP = new System.Windows.Forms.Button();
            this.btnFormatJPEG = new System.Windows.Forms.Button();
            this.btnFormatPNG = new System.Windows.Forms.Button();
            this.btnConvert = new System.Windows.Forms.Button();
            this.btnFileSelection = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFormatBMP
            // 
            this.btnFormatBMP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnFormatBMP.FlatAppearance.BorderSize = 0;
            this.btnFormatBMP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFormatBMP.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnFormatBMP.Location = new System.Drawing.Point(504, 272);
            this.btnFormatBMP.Name = "btnFormatBMP";
            this.btnFormatBMP.Size = new System.Drawing.Size(200, 50);
            this.btnFormatBMP.TabIndex = 9;
            this.btnFormatBMP.Text = ".bmp";
            this.btnFormatBMP.UseVisualStyleBackColor = false;
            this.btnFormatBMP.Click += new System.EventHandler(this.btnFormatBMP_Click);
            // 
            // btnFormatJPEG
            // 
            this.btnFormatJPEG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnFormatJPEG.FlatAppearance.BorderSize = 0;
            this.btnFormatJPEG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFormatJPEG.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnFormatJPEG.Location = new System.Drawing.Point(504, 200);
            this.btnFormatJPEG.Name = "btnFormatJPEG";
            this.btnFormatJPEG.Size = new System.Drawing.Size(200, 50);
            this.btnFormatJPEG.TabIndex = 8;
            this.btnFormatJPEG.Text = ".jpeg";
            this.btnFormatJPEG.UseVisualStyleBackColor = false;
            this.btnFormatJPEG.Click += new System.EventHandler(this.btnFormatJPEG_Click);
            // 
            // btnFormatPNG
            // 
            this.btnFormatPNG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnFormatPNG.FlatAppearance.BorderSize = 0;
            this.btnFormatPNG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFormatPNG.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnFormatPNG.Location = new System.Drawing.Point(504, 128);
            this.btnFormatPNG.Name = "btnFormatPNG";
            this.btnFormatPNG.Size = new System.Drawing.Size(200, 50);
            this.btnFormatPNG.TabIndex = 7;
            this.btnFormatPNG.Text = ".png";
            this.btnFormatPNG.UseVisualStyleBackColor = false;
            this.btnFormatPNG.Click += new System.EventHandler(this.btnFormatPNG_Click);
            // 
            // btnConvert
            // 
            this.btnConvert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnConvert.FlatAppearance.BorderSize = 0;
            this.btnConvert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConvert.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnConvert.Location = new System.Drawing.Point(96, 200);
            this.btnConvert.Margin = new System.Windows.Forms.Padding(4);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(200, 50);
            this.btnConvert.TabIndex = 6;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = false;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // btnFileSelection
            // 
            this.btnFileSelection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnFileSelection.FlatAppearance.BorderSize = 0;
            this.btnFileSelection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFileSelection.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnFileSelection.Location = new System.Drawing.Point(96, 128);
            this.btnFileSelection.Margin = new System.Windows.Forms.Padding(4);
            this.btnFileSelection.Name = "btnFileSelection";
            this.btnFileSelection.Size = new System.Drawing.Size(200, 50);
            this.btnFileSelection.TabIndex = 5;
            this.btnFileSelection.Text = "Select Files";
            this.btnFileSelection.UseVisualStyleBackColor = false;
            this.btnFileSelection.Click += new System.EventHandler(this.btnFileSelection_Click);
            // 
            // convertIndividual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(960, 643);
            this.Controls.Add(this.btnFormatBMP);
            this.Controls.Add(this.btnFormatJPEG);
            this.Controls.Add(this.btnFormatPNG);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.btnFileSelection);
            this.Name = "convertIndividual";
            this.Text = "convertIndividual";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFormatBMP;
        private System.Windows.Forms.Button btnFormatJPEG;
        private System.Windows.Forms.Button btnFormatPNG;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Button btnFileSelection;
    }
}