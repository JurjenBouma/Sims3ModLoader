using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sims3ModLoader
{
    public partial class FormNewPackage : Form
    {
        public PackageFile packageFile;
        public FormNewPackage()
        {
            InitializeComponent();
            packageFile = new PackageFile(3);
        }

        private void toevoegenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialogAddFile.ShowDialog();
        }

        private void openFileDialogAddFile_FileOk(object sender, CancelEventArgs e)
        {
            FormAddFilePackage formAddFile = new FormAddFilePackage(openFileDialogAddFile.FileName);
            formAddFile.FileOK += new FormAddFilePackage.FileOKHandler(AddItemToPack);
            formAddFile.Show();
        }

        private void opslaanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialogPackage.ShowDialog();
        }

        private void saveFileDialogPackage_FileOk(object sender, CancelEventArgs e)
        {
            packageFile.SavePackage(saveFileDialogPackage.FileName);
        }
        private void AddItemToPack(PackageFile.PackageItem item)
        {
            packageFile.AddItem(item);
            string listBoxTest = InstanceDecoder.GetName(item.Instance);
            listBoxpackageFiles.Items.Add(listBoxTest);
        }
    }
}
