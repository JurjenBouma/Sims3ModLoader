namespace Sims3ModLoader
{
    partial class FormOpenPackage
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
            this.listBoxContainedFiles = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBoxContainedFiles
            // 
            this.listBoxContainedFiles.FormattingEnabled = true;
            this.listBoxContainedFiles.Location = new System.Drawing.Point(3, 2);
            this.listBoxContainedFiles.Name = "listBoxContainedFiles";
            this.listBoxContainedFiles.Size = new System.Drawing.Size(298, 407);
            this.listBoxContainedFiles.TabIndex = 0;
            this.listBoxContainedFiles.SelectedIndexChanged += new System.EventHandler(this.listBoxContainedFiles_SelectedIndexChanged);
            // 
            // FormOpenPackage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 412);
            this.Controls.Add(this.listBoxContainedFiles);
            this.Name = "FormOpenPackage";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sims3 ModLoader";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxContainedFiles;
    }
}