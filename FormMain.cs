using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Sims3ModLoader
{
    public partial class FormMain : Form
    {
        List<Sims3ModFile> ModList = new List<Sims3ModFile>();

        public FormMain()
        {
            InitializeComponent();
            InstanceDecoder.Initialize();
            LoadModList();
        }

        private void openpackageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialogPackageOpen.ShowDialog();
        }

        private void openFileDialogPackage_FileOk(object sender, CancelEventArgs e)
        {
            FormOpenPackage formPackage = new FormOpenPackage(openFileDialogPackageOpen.FileName);
            formPackage.Show();
        }

        private void opens3saToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialogDecryptS3sa.ShowDialog();
        }

        private void openFileDialogDecryptS3sa_FileOk(object sender, CancelEventArgs e)
        {
            s3saFile s3sa = new s3saFile(openFileDialogDecryptS3sa.FileName);
            FileInfo fiS3sa = new FileInfo(openFileDialogDecryptS3sa.FileName);
            string name = fiS3sa.Name.Substring(0, fiS3sa.Name.Length - fiS3sa.Extension.Length);
            s3sa.Save(name,s3saFile.FileType.DDL);
        }

        private void encryptS3SaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialogEncryptS3sa.ShowDialog();
        }

        private void openFileDialogEncryptS3sa_FileOk(object sender, CancelEventArgs e)
        {
            s3saFile s3sa = new s3saFile(openFileDialogEncryptS3sa.FileName);
            FileInfo fiDll = new FileInfo(openFileDialogEncryptS3sa.FileName);
            string name = fiDll.Name.Substring(0, fiDll.Name.Length - fiDll.Extension.Length);
            s3sa.Save(name, s3saFile.FileType.S3SA);
        }

        private void disasambleDLLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialogDasm.ShowDialog();
        }

        private void openFileDialogDasm_FileOk(object sender, CancelEventArgs e)
        {
          FileInfo fiDLL = new FileInfo(openFileDialogDasm.FileName);
          string dllPath = fiDLL.FullName;
          string ilPath = dllPath.Substring(0, dllPath.Length - fiDLL.Extension.Length) + ".il";
          Process.Start(Application.StartupPath + "\\ilasm\\ildasm.exe", dllPath + " /out=" + ilPath);
        }

        private void newpackageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNewPackage formEdit = new FormNewPackage();
            formEdit.Show();
        }

        private void assembleDLLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialogAsm.ShowDialog();
        }

        private void openFileDialogAsm_FileOk(object sender, CancelEventArgs e)
        {
            FileInfo fiIl = new FileInfo(openFileDialogAsm.FileName);
            string iLPath = fiIl.FullName;
            Process.Start(Application.StartupPath + "\\ilasm\\ilasm.exe", iLPath + " /dll");
        }

        private void LoadModList()
        {
            if (File.Exists("Mods.modlist"))
            {
                string[] mods = File.ReadAllLines("Mods.modlist");
                foreach(string mod in mods)
                {
                    Sims3ModFile modFile = new Sims3ModFile(mod,Application.StartupPath);
                    ModList.Add(modFile);
                    comboBoxMods.Items.Add(modFile.ModName);
                    comboBoxMods.SelectedIndex++;
                    richTextBox1.Text = modFile.Description;
                }
            }
        }

        private void openFileDialogAddMod_FileOk(object sender, CancelEventArgs e)
        {
            Sims3ModFile modFile = new Sims3ModFile(openFileDialogMods.FileName,Application.StartupPath);
            ModList.Add(modFile);
            comboBoxMods.Items.Add(modFile.ModName);
            comboBoxMods.SelectedIndex++;
            richTextBox1.Text = modFile.Description;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            List<string> lines = new List<string>();
            foreach(Sims3ModFile modFile in ModList)
                lines.Add(modFile.FilePath);
            File.WriteAllLines("Mods.modlist",lines.ToArray());
            ModList[comboBoxMods.SelectedIndex].UnLoadMod();
        }

        private void buttonAddMod_Click(object sender, EventArgs e)
        {
            openFileDialogMods.ShowDialog();
        }

        private void verwijderModToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (comboBoxMods.SelectedIndex >= 0)
            {
                ModList.RemoveAt(comboBoxMods.SelectedIndex);
                comboBoxMods.Items.RemoveAt(comboBoxMods.SelectedIndex);
                comboBoxMods.Text = "";
                comboBoxMods.SelectedIndex = comboBoxMods.Items.Count - 1;
                if (comboBoxMods.Items.Count > 0)
                    richTextBox1.Text = ModList[comboBoxMods.Items.Count - 1].Description;
                else
                    richTextBox1.Text = "";
            }
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            if (comboBoxMods.SelectedIndex >= 0)
            {
                ModList[comboBoxMods.SelectedIndex].LoadMod();
            }
        }
       
    }
}
