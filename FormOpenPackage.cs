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
    public partial class FormOpenPackage : Form
    {
        public PackageFile packFile;
        public FormOpenPackage(string packagePath)
        {
            InitializeComponent();
            packFile = new PackageFile(packagePath);
            for(int item =0;item < packFile.itemCount;item++)
            {
                UInt64 instance = packFile.items[item].Instance;
                string name = InstanceDecoder.GetName(instance);
                listBoxContainedFiles.Items.Add("Type = " + packFile.items[item].Type.ToString() + " Instance = " + name);
            }
        }

        private void listBoxContainedFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxContainedFiles.SelectedIndex >= 0)
            {
                UInt64 instance = packFile.items[listBoxContainedFiles.SelectedIndex].Instance;
                string name = InstanceDecoder.GetName(instance);
                packFile.ExtractFile(listBoxContainedFiles.SelectedIndex, name);
            }
        }
    }
}
