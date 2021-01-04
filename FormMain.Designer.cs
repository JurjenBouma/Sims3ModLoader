namespace Sims3ModLoader
{
    partial class FormMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.bestandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openpackageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wijzigpackageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opens3saToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.encryptS3SaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assembleDLLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disasambleDLLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verwijderModToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialogPackageOpen = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogDecryptS3sa = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogDasm = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogAsm = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogEncryptS3sa = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogMods = new System.Windows.Forms.OpenFileDialog();
            this.process1 = new System.Diagnostics.Process();
            this.comboBoxMods = new System.Windows.Forms.ComboBox();
            this.buttonAddMod = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.labelMod = new System.Windows.Forms.Label();
            this.labelDesc = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackgroundImage = global::Sims3ModLoader.Properties.Resources.bg_blue1;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bestandToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // bestandToolStripMenuItem
            // 
            this.bestandToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openpackageToolStripMenuItem,
            this.wijzigpackageToolStripMenuItem,
            this.opens3saToolStripMenuItem,
            this.encryptS3SaToolStripMenuItem,
            this.assembleDLLToolStripMenuItem,
            this.disasambleDLLToolStripMenuItem,
            this.verwijderModToolStripMenuItem});
            this.bestandToolStripMenuItem.Name = "bestandToolStripMenuItem";
            this.bestandToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.bestandToolStripMenuItem.Text = "Bestand";
            // 
            // openpackageToolStripMenuItem
            // 
            this.openpackageToolStripMenuItem.Name = "openpackageToolStripMenuItem";
            this.openpackageToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.openpackageToolStripMenuItem.Text = "Open Package";
            this.openpackageToolStripMenuItem.Click += new System.EventHandler(this.openpackageToolStripMenuItem_Click);
            // 
            // wijzigpackageToolStripMenuItem
            // 
            this.wijzigpackageToolStripMenuItem.Name = "wijzigpackageToolStripMenuItem";
            this.wijzigpackageToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.wijzigpackageToolStripMenuItem.Text = "Nieuw Package";
            this.wijzigpackageToolStripMenuItem.Click += new System.EventHandler(this.newpackageToolStripMenuItem_Click);
            // 
            // opens3saToolStripMenuItem
            // 
            this.opens3saToolStripMenuItem.Name = "opens3saToolStripMenuItem";
            this.opens3saToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.opens3saToolStripMenuItem.Text = "Decrypt S3SA";
            this.opens3saToolStripMenuItem.Click += new System.EventHandler(this.opens3saToolStripMenuItem_Click);
            // 
            // encryptS3SaToolStripMenuItem
            // 
            this.encryptS3SaToolStripMenuItem.Name = "encryptS3SaToolStripMenuItem";
            this.encryptS3SaToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.encryptS3SaToolStripMenuItem.Text = "Encrypt S3Sa";
            this.encryptS3SaToolStripMenuItem.Click += new System.EventHandler(this.encryptS3SaToolStripMenuItem_Click);
            // 
            // assembleDLLToolStripMenuItem
            // 
            this.assembleDLLToolStripMenuItem.Name = "assembleDLLToolStripMenuItem";
            this.assembleDLLToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.assembleDLLToolStripMenuItem.Text = "Assemble DLL";
            this.assembleDLLToolStripMenuItem.Click += new System.EventHandler(this.assembleDLLToolStripMenuItem_Click);
            // 
            // disasambleDLLToolStripMenuItem
            // 
            this.disasambleDLLToolStripMenuItem.Name = "disasambleDLLToolStripMenuItem";
            this.disasambleDLLToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.disasambleDLLToolStripMenuItem.Text = "Disassemble DLL";
            this.disasambleDLLToolStripMenuItem.Click += new System.EventHandler(this.disasambleDLLToolStripMenuItem_Click);
            // 
            // verwijderModToolStripMenuItem
            // 
            this.verwijderModToolStripMenuItem.Name = "verwijderModToolStripMenuItem";
            this.verwijderModToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.verwijderModToolStripMenuItem.Text = "Verwijder Mod";
            this.verwijderModToolStripMenuItem.Click += new System.EventHandler(this.verwijderModToolStripMenuItem_Click);
            // 
            // openFileDialogPackageOpen
            // 
            this.openFileDialogPackageOpen.FileName = "openFileDialog1";
            this.openFileDialogPackageOpen.Filter = "Package Files|*.package|All Files|*.*";
            this.openFileDialogPackageOpen.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogPackage_FileOk);
            // 
            // openFileDialogDecryptS3sa
            // 
            this.openFileDialogDecryptS3sa.FileName = "openFileDialog1";
            this.openFileDialogDecryptS3sa.Filter = "S3SA File|*.s3sa";
            this.openFileDialogDecryptS3sa.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogDecryptS3sa_FileOk);
            // 
            // openFileDialogDasm
            // 
            this.openFileDialogDasm.FileName = "openFileDialog1";
            this.openFileDialogDasm.Filter = "DLL|*.dll";
            this.openFileDialogDasm.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogDasm_FileOk);
            // 
            // openFileDialogAsm
            // 
            this.openFileDialogAsm.FileName = "openFileDialog1";
            this.openFileDialogAsm.Filter = "CIL|*.il";
            this.openFileDialogAsm.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogAsm_FileOk);
            // 
            // openFileDialogEncryptS3sa
            // 
            this.openFileDialogEncryptS3sa.FileName = "openFileDialog1";
            this.openFileDialogEncryptS3sa.Filter = "DLL|*.dll";
            this.openFileDialogEncryptS3sa.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogEncryptS3sa_FileOk);
            // 
            // openFileDialogMods
            // 
            this.openFileDialogMods.FileName = "openFileDialog1]";
            this.openFileDialogMods.Filter = "Mods|*.sims3mod";
            this.openFileDialogMods.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogAddMod_FileOk);
            // 
            // process1
            // 
            this.process1.StartInfo.Domain = "";
            this.process1.StartInfo.LoadUserProfile = false;
            this.process1.StartInfo.Password = null;
            this.process1.StartInfo.StandardErrorEncoding = null;
            this.process1.StartInfo.StandardOutputEncoding = null;
            this.process1.StartInfo.UserName = "";
            this.process1.SynchronizingObject = this;
            // 
            // comboBoxMods
            // 
            this.comboBoxMods.FormattingEnabled = true;
            this.comboBoxMods.Location = new System.Drawing.Point(178, 52);
            this.comboBoxMods.Name = "comboBoxMods";
            this.comboBoxMods.Size = new System.Drawing.Size(451, 21);
            this.comboBoxMods.TabIndex = 1;
            // 
            // buttonAddMod
            // 
            this.buttonAddMod.BackgroundImage = global::Sims3ModLoader.Properties.Resources.EmptyButton;
            this.buttonAddMod.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAddMod.FlatAppearance.BorderSize = 0;
            this.buttonAddMod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddMod.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddMod.Location = new System.Drawing.Point(635, 43);
            this.buttonAddMod.Name = "buttonAddMod";
            this.buttonAddMod.Size = new System.Drawing.Size(102, 37);
            this.buttonAddMod.TabIndex = 2;
            this.buttonAddMod.Text = "Mod Toevoegen";
            this.buttonAddMod.UseVisualStyleBackColor = true;
            this.buttonAddMod.Click += new System.EventHandler(this.buttonAddMod_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.BackgroundImage = global::Sims3ModLoader.Properties.Resources.EmptyButton;
            this.buttonPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonPlay.FlatAppearance.BorderSize = 0;
            this.buttonPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlay.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPlay.Location = new System.Drawing.Point(603, 456);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(134, 64);
            this.buttonPlay.TabIndex = 3;
            this.buttonPlay.Text = "Spelen";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // labelMod
            // 
            this.labelMod.AutoSize = true;
            this.labelMod.BackColor = System.Drawing.Color.Transparent;
            this.labelMod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMod.Location = new System.Drawing.Point(124, 53);
            this.labelMod.Name = "labelMod";
            this.labelMod.Size = new System.Drawing.Size(48, 20);
            this.labelMod.TabIndex = 4;
            this.labelMod.Text = "Mod :";
            // 
            // labelDesc
            // 
            this.labelDesc.AutoSize = true;
            this.labelDesc.BackColor = System.Drawing.Color.Transparent;
            this.labelDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDesc.Location = new System.Drawing.Point(71, 92);
            this.labelDesc.Name = "labelDesc";
            this.labelDesc.Size = new System.Drawing.Size(101, 20);
            this.labelDesc.TabIndex = 5;
            this.labelDesc.Text = "Beschrijving :";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(178, 92);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(451, 195);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Sims3ModLoader.Properties.Resources.bg_blue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.labelDesc);
            this.Controls.Add(this.labelMod);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.buttonAddMod);
            this.Controls.Add(this.comboBoxMods);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Sims3ModLoader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem bestandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openpackageToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialogPackageOpen;
        private System.Windows.Forms.ToolStripMenuItem opens3saToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialogDecryptS3sa;
        private System.Windows.Forms.ToolStripMenuItem disasambleDLLToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialogDasm;
        private System.Windows.Forms.ToolStripMenuItem wijzigpackageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assembleDLLToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialogAsm;
        private System.Windows.Forms.ToolStripMenuItem encryptS3SaToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialogEncryptS3sa;
        private System.Windows.Forms.OpenFileDialog openFileDialogMods;
        private System.Diagnostics.Process process1;
        private System.Windows.Forms.ComboBox comboBoxMods;
        private System.Windows.Forms.Button buttonAddMod;
        private System.Windows.Forms.ToolStripMenuItem verwijderModToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label labelDesc;
        private System.Windows.Forms.Label labelMod;
        private System.Windows.Forms.Button buttonPlay;
    }
}

