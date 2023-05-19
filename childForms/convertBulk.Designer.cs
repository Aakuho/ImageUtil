
namespace ImageUtil.childForms
{
    partial class convertBulk
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
            this.btnFileSelection = new System.Windows.Forms.Button();
            this.btnConvert = new System.Windows.Forms.Button();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnKeepFiles = new System.Windows.Forms.Button();
            this.labelFiles = new System.Windows.Forms.Label();
            this.labelFilesHeader = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnFileSelection
            // 
            this.btnFileSelection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnFileSelection.FlatAppearance.BorderSize = 0;
            this.btnFileSelection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFileSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFileSelection.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnFileSelection.Location = new System.Drawing.Point(10, 10);
            this.btnFileSelection.Margin = new System.Windows.Forms.Padding(5);
            this.btnFileSelection.Name = "btnFileSelection";
            this.btnFileSelection.Size = new System.Drawing.Size(200, 50);
            this.btnFileSelection.TabIndex = 0;
            this.btnFileSelection.Text = "Select Folder";
            this.btnFileSelection.UseVisualStyleBackColor = false;
            this.btnFileSelection.Click += new System.EventHandler(this.btnFileSelection_Click);
            // 
            // btnConvert
            // 
            this.btnConvert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnConvert.FlatAppearance.BorderSize = 0;
            this.btnConvert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConvert.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConvert.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnConvert.Location = new System.Drawing.Point(450, 10);
            this.btnConvert.Margin = new System.Windows.Forms.Padding(5);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(200, 50);
            this.btnConvert.TabIndex = 1;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = false;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // panelButtons
            // 
            this.panelButtons.Location = new System.Drawing.Point(10, 100);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(300, 400);
            this.panelButtons.TabIndex = 10;
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
            this.btnKeepFiles.TabIndex = 11;
            this.btnKeepFiles.Text = "Keep original files";
            this.btnKeepFiles.UseVisualStyleBackColor = false;
            this.btnKeepFiles.Click += new System.EventHandler(this.btnKeepFiles_Click);
            // 
            // labelFiles
            // 
            this.labelFiles.AutoSize = true;
            this.labelFiles.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelFiles.Location = new System.Drawing.Point(385, 150);
            this.labelFiles.Name = "labelFiles";
            this.labelFiles.Size = new System.Drawing.Size(0, 16);
            this.labelFiles.TabIndex = 0;
            // 
            // labelFilesHeader
            // 
            this.labelFilesHeader.AutoSize = true;
            this.labelFilesHeader.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelFilesHeader.Location = new System.Drawing.Point(385, 100);
            this.labelFilesHeader.Name = "labelFilesHeader";
            this.labelFilesHeader.Size = new System.Drawing.Size(0, 16);
            this.labelFilesHeader.TabIndex = 12;
            // 
            // convertBulk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(702, 553);
            this.Controls.Add(this.labelFiles);
            this.Controls.Add(this.labelFilesHeader);
            this.Controls.Add(this.btnKeepFiles);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.btnFileSelection);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "convertBulk";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFileSelection;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnKeepFiles;
        private System.Windows.Forms.Label labelFiles;
        private System.Windows.Forms.Label labelFilesHeader;
    }
}