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
            this.btnConvert = new System.Windows.Forms.Button();
            this.btnFileSelection = new System.Windows.Forms.Button();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnKeepFiles = new System.Windows.Forms.Button();
            this.panelText = new System.Windows.Forms.Panel();
            this.labelFiles = new System.Windows.Forms.Label();
            this.labelFilesHeader = new System.Windows.Forms.Label();
            this.panelText.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConvert
            // 
            this.btnConvert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnConvert.FlatAppearance.BorderSize = 0;
            this.btnConvert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConvert.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnConvert.Location = new System.Drawing.Point(360, 8);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(160, 40);
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
            this.btnFileSelection.Location = new System.Drawing.Point(8, 8);
            this.btnFileSelection.Name = "btnFileSelection";
            this.btnFileSelection.Size = new System.Drawing.Size(160, 40);
            this.btnFileSelection.TabIndex = 5;
            this.btnFileSelection.Text = "Select Files";
            this.btnFileSelection.UseVisualStyleBackColor = false;
            this.btnFileSelection.Click += new System.EventHandler(this.btnFileSelection_Click);
            // 
            // panelButtons
            // 
            this.panelButtons.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelButtons.Location = new System.Drawing.Point(11, 92);
            this.panelButtons.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(240, 320);
            this.panelButtons.TabIndex = 10;
            // 
            // btnKeepFiles
            // 
            this.btnKeepFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnKeepFiles.FlatAppearance.BorderSize = 0;
            this.btnKeepFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeepFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKeepFiles.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnKeepFiles.Location = new System.Drawing.Point(184, 8);
            this.btnKeepFiles.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnKeepFiles.Name = "btnKeepFiles";
            this.btnKeepFiles.Size = new System.Drawing.Size(160, 40);
            this.btnKeepFiles.TabIndex = 11;
            this.btnKeepFiles.Text = "Keep original files";
            this.btnKeepFiles.UseVisualStyleBackColor = false;
            this.btnKeepFiles.Click += new System.EventHandler(this.btnKeepFiles_Click);
            // 
            // panelText
            // 
            this.panelText.Controls.Add(this.labelFiles);
            this.panelText.Location = new System.Drawing.Point(315, 121);
            this.panelText.Name = "panelText";
            this.panelText.Size = new System.Drawing.Size(287, 320);
            this.panelText.TabIndex = 15;
            // 
            // labelFiles
            // 
            this.labelFiles.AutoSize = true;
            this.labelFiles.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelFiles.Location = new System.Drawing.Point(0, 0);
            this.labelFiles.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFiles.Name = "labelFiles";
            this.labelFiles.Size = new System.Drawing.Size(0, 15);
            this.labelFiles.TabIndex = 0;
            // 
            // labelFilesHeader
            // 
            this.labelFilesHeader.AutoSize = true;
            this.labelFilesHeader.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelFilesHeader.Location = new System.Drawing.Point(312, 79);
            this.labelFilesHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFilesHeader.Name = "labelFilesHeader";
            this.labelFilesHeader.Size = new System.Drawing.Size(0, 15);
            this.labelFilesHeader.TabIndex = 14;
            // 
            // convertIndividual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(954, 572);
            this.Controls.Add(this.panelText);
            this.Controls.Add(this.labelFilesHeader);
            this.Controls.Add(this.btnKeepFiles);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.btnFileSelection);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "convertIndividual";
            this.Text = "7";
            this.panelText.ResumeLayout(false);
            this.panelText.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Button btnFileSelection;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnKeepFiles;
        private System.Windows.Forms.Panel panelText;
        private System.Windows.Forms.Label labelFiles;
        private System.Windows.Forms.Label labelFilesHeader;
    }
}