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

namespace Sims3ModLoader
{
    public partial class FormAddFilePackage : Form
    {
        public delegate void FileOKHandler(PackageFile.PackageItem item);
        public event FileOKHandler FileOK;

        private PackageFile.PackageItem packItem;
        private string filePath;

        public FormAddFilePackage(string fileName)
        {
            InitializeComponent();
            filePath = fileName;
            ReadFile();
        }
        private void ReadFile()
        {
            packItem = new PackageFile.PackageItem();

            Stream iStream = new FileStream(filePath, FileMode.Open);
            BinaryReader reader = new BinaryReader(iStream);

            packItem.Data = reader.ReadBytes((int)iStream.Length);
            packItem.DataLength = (UInt32)packItem.Data.Length;
            packItem.DataOffset = 0;
            packItem.DataUnCompressedLength = (UInt32)packItem.Data.Length;
            packItem.IsDataCompressed = 0;
            
            packItem.Type = 0;
            FileInfo fiItem = new FileInfo(filePath);
            if(fiItem.Extension == ".s3sa")
                packItem.Type = 121612807;

            packItem.Group = 0;

            string itemName = fiItem.Name.Substring(0, fiItem.Name.Length - fiItem.Extension.Length);
            packItem.Instance = InstanceDecoder.GetInstance(itemName);

            iStream.Close();

            textBoxType.Text = packItem.Type.ToString("X");
            textBoxGroup.Text = packItem.Group.ToString("X");
            textBoxInstance.Text = packItem.Instance.ToString("X");
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            packItem.Type = UInt32.Parse(textBoxType.Text, System.Globalization.NumberStyles.HexNumber);
            packItem.Group = UInt32.Parse(textBoxGroup.Text, System.Globalization.NumberStyles.HexNumber);
            packItem.Instance = UInt64.Parse(textBoxInstance.Text, System.Globalization.NumberStyles.HexNumber);

            FileOK(packItem);
            this.Close();
        }
    }
}
