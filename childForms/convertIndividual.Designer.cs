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
            this.SuspendLayout();
            // 
            // btnConvert
            // 
            this.btnConvert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnConvert.FlatAppearance.BorderSize = 0;
            this.btnConvert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConvert.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnConvert.Location = new System.Drawing.Point(450, 10);
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
            this.btnFileSelection.Location = new System.Drawing.Point(10, 10);
            this.btnFileSelection.Margin = new System.Windows.Forms.Padding(4);
            this.btnFileSelection.Name = "btnFileSelection";
            this.btnFileSelection.Size = new System.Drawing.Size(200, 50);
            this.btnFileSelection.TabIndex = 5;
            this.btnFileSelection.Text = "Select Files";
            this.btnFileSelection.UseVisualStyleBackColor = false;
            this.btnFileSelection.Click += new System.EventHandler(this.btnFileSelection_Click);
            // 
            // panelButtons
            // 
            this.panelButtons.Location = new System.Drawing.Point(10, 100);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(200, 400);
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
            // convertIndividual
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(977, 946);
            this.Controls.Add(this.btnKeepFiles);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.btnFileSelection);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "convertIndividual";
            this.Text = "convertIndividual";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Button btnFileSelection;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnKeepFiles;
    }
}