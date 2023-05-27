namespace ImageUtil.childForms
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
            this.labelSource = new System.Windows.Forms.Label();
            this.labelDestination = new System.Windows.Forms.Label();
            this.panelText = new System.Windows.Forms.Panel();
            this.labelFiles = new System.Windows.Forms.Label();
            this.labelFilesHeader = new System.Windows.Forms.Label();
            this.panelText.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelButtonsLeft
            // 
            this.panelButtonsLeft.AutoScroll = true;
            this.panelButtonsLeft.Location = new System.Drawing.Point(11, 92);
            this.panelButtonsLeft.Margin = new System.Windows.Forms.Padding(2);
            this.panelButtonsLeft.Name = "panelButtonsLeft";
            this.panelButtonsLeft.Size = new System.Drawing.Size(240, 320);
            this.panelButtonsLeft.TabIndex = 9;
            // 
            // panelButtonsRight
            // 
            this.panelButtonsRight.AutoScroll = true;
            this.panelButtonsRight.Location = new System.Drawing.Point(311, 92);
            this.panelButtonsRight.Margin = new System.Windows.Forms.Padding(2);
            this.panelButtonsRight.Name = "panelButtonsRight";
            this.panelButtonsRight.Size = new System.Drawing.Size(240, 320);
            this.panelButtonsRight.TabIndex = 10;
            // 
            // btnConvert
            // 
            this.btnConvert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnConvert.FlatAppearance.BorderSize = 0;
            this.btnConvert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConvert.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConvert.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnConvert.Location = new System.Drawing.Point(221, 432);
            this.btnConvert.Margin = new System.Windows.Forms.Padding(2);
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
            this.btnKeepFiles.Location = new System.Drawing.Point(11, 432);
            this.btnKeepFiles.Margin = new System.Windows.Forms.Padding(2);
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
            this.btnFileSelect.Margin = new System.Windows.Forms.Padding(2);
            this.btnFileSelect.Name = "btnFileSelect";
            this.btnFileSelect.Size = new System.Drawing.Size(200, 50);
            this.btnFileSelect.TabIndex = 0;
            this.btnFileSelect.Text = "Select Folder";
            this.btnFileSelect.UseVisualStyleBackColor = false;
            this.btnFileSelect.Click += new System.EventHandler(this.btnFileSelect_Click);
            // 
            // labelSource
            // 
            this.labelSource.AutoSize = true;
            this.labelSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSource.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelSource.Location = new System.Drawing.Point(11, 69);
            this.labelSource.Name = "labelSource";
            this.labelSource.Size = new System.Drawing.Size(119, 15);
            this.labelSource.TabIndex = 15;
            this.labelSource.Text = "Select source format";
            // 
            // labelDestination
            // 
            this.labelDestination.AutoSize = true;
            this.labelDestination.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDestination.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelDestination.Location = new System.Drawing.Point(311, 69);
            this.labelDestination.Name = "labelDestination";
            this.labelDestination.Size = new System.Drawing.Size(142, 15);
            this.labelDestination.TabIndex = 16;
            this.labelDestination.Text = "Select destination format";
            // 
            // panelText
            // 
            this.panelText.AutoScroll = true;
            this.panelText.Controls.Add(this.labelFiles);
            this.panelText.Location = new System.Drawing.Point(611, 92);
            this.panelText.Name = "panelText";
            this.panelText.Size = new System.Drawing.Size(287, 320);
            this.panelText.TabIndex = 18;
            // 
            // labelFiles
            // 
            this.labelFiles.AutoSize = true;
            this.labelFiles.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelFiles.Location = new System.Drawing.Point(0, 0);
            this.labelFiles.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFiles.Name = "labelFiles";
            this.labelFiles.Size = new System.Drawing.Size(0, 13);
            this.labelFiles.TabIndex = 0;
            // 
            // labelFilesHeader
            // 
            this.labelFilesHeader.AutoSize = true;
            this.labelFilesHeader.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelFilesHeader.Location = new System.Drawing.Point(611, 50);
            this.labelFilesHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFilesHeader.Name = "labelFilesHeader";
            this.labelFilesHeader.Size = new System.Drawing.Size(0, 13);
            this.labelFilesHeader.TabIndex = 17;
            // 
            // convertPerFormat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(954, 572);
            this.Controls.Add(this.panelText);
            this.Controls.Add(this.labelFilesHeader);
            this.Controls.Add(this.labelDestination);
            this.Controls.Add(this.labelSource);
            this.Controls.Add(this.panelButtonsRight);
            this.Controls.Add(this.panelButtonsLeft);
            this.Controls.Add(this.btnKeepFiles);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.btnFileSelect);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "convertPerFormat";
            this.Text = "convertPerFormat";
            this.Load += new System.EventHandler(this.convertPerFormat_Load);
            this.panelText.ResumeLayout(false);
            this.panelText.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelButtonsLeft;
        private System.Windows.Forms.Panel panelButtonsRight;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Button btnKeepFiles;
        private System.Windows.Forms.Button btnFileSelect;
        private System.Windows.Forms.Label labelSource;
        private System.Windows.Forms.Label labelDestination;
        private System.Windows.Forms.Panel panelText;
        private System.Windows.Forms.Label labelFiles;
        private System.Windows.Forms.Label labelFilesHeader;
    }
}