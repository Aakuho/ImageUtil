﻿namespace ImageUtil.childForms
{
    partial class convertPerFormat
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
            this.panelButtonsLeft = new System.Windows.Forms.Panel();
            this.panelButtonsRight = new System.Windows.Forms.Panel();
            this.btnConvert = new System.Windows.Forms.Button();
            this.btnKeepFiles = new System.Windows.Forms.Button();
            this.btnFileSelect = new System.Windows.Forms.Button();
            this.labelFilesHeader = new System.Windows.Forms.Label();
            this.labelFiles = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panelButtonsLeft
            // 
            this.panelButtonsLeft.Location = new System.Drawing.Point(10, 100);
            this.panelButtonsLeft.Name = "panelButtonsLeft";
            this.panelButtonsLeft.Size = new System.Drawing.Size(200, 400);
            this.panelButtonsLeft.TabIndex = 9;
            // 
            // panelButtonsRight
            // 
            this.panelButtonsRight.Location = new System.Drawing.Point(230, 100);
            this.panelButtonsRight.Name = "panelButtonsRight";
            this.panelButtonsRight.Size = new System.Drawing.Size(200, 400);
            this.panelButtonsRight.TabIndex = 10;
            // 
            // btnConvert
            // 
            this.btnConvert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnConvert.FlatAppearance.BorderSize = 0;
            this.btnConvert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConvert.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConvert.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnConvert.Location = new System.Drawing.Point(450, 10);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(200, 50);
            this.btnConvert.TabIndex = 1;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = false;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // btnKeepFiles
            // 
            this.btnKeepFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnKeepFiles.FlatAppearance.BorderSize = 0;
            this.btnKeepFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeepFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKeepFiles.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnKeepFiles.Location = new System.Drawing.Point(230, 10);
            this.btnKeepFiles.Name = "btnKeepFiles";
            this.btnKeepFiles.Size = new System.Drawing.Size(200, 50);
            this.btnKeepFiles.TabIndex = 8;
            this.btnKeepFiles.Text = "Keep original files";
            this.btnKeepFiles.UseVisualStyleBackColor = false;
            this.btnKeepFiles.Click += new System.EventHandler(this.btnKeepFiles_Click);
            // 
            // btnFileSelect
            // 
            this.btnFileSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnFileSelect.FlatAppearance.BorderSize = 0;
            this.btnFileSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFileSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFileSelect.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnFileSelect.Location = new System.Drawing.Point(10, 10);
            this.btnFileSelect.Name = "btnFileSelect";
            this.btnFileSelect.Size = new System.Drawing.Size(200, 50);
            this.btnFileSelect.TabIndex = 0;
            this.btnFileSelect.Text = "Select Folder";
            this.btnFileSelect.UseVisualStyleBackColor = false;
            this.btnFileSelect.Click += new System.EventHandler(this.btnFileSelect_Click);
            // 
            // labelFilesHeader
            // 
            this.labelFilesHeader.AutoSize = true;
            this.labelFilesHeader.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelFilesHeader.Location = new System.Drawing.Point(600, 100);
            this.labelFilesHeader.Name = "labelFilesHeader";
            this.labelFilesHeader.Size = new System.Drawing.Size(0, 16);
            this.labelFilesHeader.TabIndex = 11;
            // 
            // labelFiles
            // 
            this.labelFiles.AutoSize = true;
            this.labelFiles.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelFiles.Location = new System.Drawing.Point(600, 150);
            this.labelFiles.Name = "labelFiles";
            this.labelFiles.Size = new System.Drawing.Size(0, 16);
            this.labelFiles.TabIndex = 12;
            // 
            // convertPerFormat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(702, 553);
            this.Controls.Add(this.labelFiles);
            this.Controls.Add(this.labelFilesHeader);
            this.Controls.Add(this.panelButtonsRight);
            this.Controls.Add(this.panelButtonsLeft);
            this.Controls.Add(this.btnKeepFiles);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.btnFileSelect);
            this.Name = "convertPerFormat";
            this.Text = "convertPerFormat";
            this.Load += new System.EventHandler(this.convertPerFormat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelButtonsLeft;
        private System.Windows.Forms.Panel panelButtonsRight;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Button btnKeepFiles;
        private System.Windows.Forms.Button btnFileSelect;
        private System.Windows.Forms.Label labelFilesHeader;
        private System.Windows.Forms.Label labelFiles;
    }
}