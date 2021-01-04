using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Sims3ModLoader
{
    public class PackageFile
    {
        public struct PackageItem
        {
            public UInt32 Type;
            public UInt32 Group;
            public UInt64 Instance;
            public UInt32 DataOffset;
            public UInt32 DataLength;
            public UInt32 DataUnCompressedLength;
            public UInt32 IsDataCompressed;
            public byte[] Data;

            public PackageItem(UInt32 type,UInt32 group,UInt64 instance,UInt32 dataoffset, UInt32 datalength, UInt32 dataUnCompressedLength,UInt32 isDataCompressed)
            {
                Type = type;
                Group = group;
                Instance = instance;
                DataOffset = dataoffset;
                DataLength = datalength;
                DataUnCompressedLength = dataUnCompressedLength;
                IsDataCompressed = isDataCompressed;
                Data = new byte[DataLength & 0x7FFFFFFF];
            }
            public PackageItem(PackageItem item)
            {
                Type = item.Type;
                Group = item.Group;
                Instance = item.Instance;
                DataOffset = item.DataOffset;
                DataLength = item.DataLength;
                DataUnCompressedLength = item.DataUnCompressedLength;
                IsDataCompressed = item.IsDataCompressed;
                Data = item.Data;
            }
        }

        public string filePath;
        public string fileName;
        public UInt32 indexType;
        public UInt32 itemCount;
        public List<PackageItem> items;

        public PackageFile(UInt32 indextype)
        {
            filePath = "";
            fileName = "";
            indexType = indextype;
            itemCount = 0;
            items = new List<PackageItem>();
        }

        public PackageFile(string path)
        {
            filePath = path;

            FileInfo fiPackFile = new FileInfo(path);
            fileName = fiPackFile.Name;
            Read();
        }

        private int GetSharedHeaderLenght(UInt32 indexType)
        {
            int lenght = 0;
            for (int i = 0; i < 32; i++)
            {
                if ((indexType & (1 << i)) != 0)
                    lenght++;
            }
            return lenght;
        }

        public void AddItem(UInt32 type, UInt32 group, UInt64 instance,byte[] itemData)
        {
            PackageItem newItem = new PackageItem();
            newItem.Type = type;
            newItem.Group = group;
            newItem.Instance = instance;
            newItem.DataLength = (UInt32)itemData.Length;
            newItem.Data = itemData;
            newItem.DataUnCompressedLength = newItem.DataLength;
            newItem.IsDataCompressed = 65536;
            newItem.DataOffset = 0;

            items.Add(newItem);
            itemCount++;
        }

        public void AddItem(PackageItem item)
        {
            items.Add(item);
            itemCount++;
        }

        private void Read()
        { 
            Stream istream = new FileStream(filePath, FileMode.Open);
            BinaryReader reader = new BinaryReader(istream);
            byte[] magic = reader.ReadBytes(4);//magic number DBPF
            if (Encoding.ASCII.GetString(magic, 0, 4) == "DBPF")
            {
                //FileHeader
                reader.BaseStream.Position = 36; 
                itemCount = reader.ReadUInt32();//number of items
                reader.BaseStream.Position = 44;
                UInt32 indexSize = reader.ReadUInt32();//Size of index
                reader.BaseStream.Position = 64;
                UInt32 indexPosition = reader.ReadUInt32();//Position of index

                //IndexHeaders
                reader.BaseStream.Position = indexPosition;
                indexType = reader.ReadUInt32();//index Type
                int SharedLenght = GetSharedHeaderLenght(indexType);//universal headerpart
                UInt32[] indexHeader = new UInt32[8];//0=type 1=group 2-3=instance 4=dataoffset 5=datasize  6=datasizeuncompressed 7=compressed(lowWord)
                items = new List<PackageItem>();

                for (int i = 0; i < SharedLenght; i++)//Read universal Part
                {
                    indexHeader[i] = reader.ReadUInt32();
                }

                for (int item = 0; item < itemCount; item++)//Read itemspecific header parts
                {
                    for (int i = SharedLenght; i < indexHeader.Length; i++)
                    {
                        indexHeader[i] = reader.ReadUInt32();
                    }
                    PackageItem newItem = new PackageItem(indexHeader[0], indexHeader[1], GetInstanceId(indexHeader[2],indexHeader[3]),indexHeader[4],indexHeader[5],indexHeader[6],indexHeader[7]);
                    items.Add(newItem);
                }
            }

            istream.Close();
            FillItemData();
        }

        private void FillItemData()
        {
            Stream istream = new FileStream(filePath, FileMode.Open);
            BinaryReader reader = new BinaryReader(istream);
            for (int i = 0; i < itemCount; i++)
            {
                reader.BaseStream.Position = items[i].DataOffset;
                PackageItem tempItem = new PackageItem(items[i]);
                tempItem.Data = reader.ReadBytes(tempItem.Data.Length);
                items.RemoveAt(i);
                items.Insert(i,tempItem);
            }
            istream.Close();
        }

        private UInt64 GetInstanceId(UInt32 highpart ,UInt32 lowPart)
        {
            UInt64 instance = 0;

            List<byte> instanceBytes = new List<byte>();
            for (int i = 0; i < 4;i++ )
                instanceBytes.Add(BitConverter.GetBytes(lowPart)[i]);

            for (int i = 0; i < 4; i++)
                instanceBytes.Add(BitConverter.GetBytes(highpart)[i]);

            instance = BitConverter.ToUInt64(instanceBytes.ToArray(),0);
            return instance;
        }

        private UInt32[] GetInstanceIdHighLow(UInt64 instance)
        {
            UInt32[] highlow = new UInt32[2];

            List<byte> highBytes = new List<byte>();
            List<byte> lowBytes = new List<byte>();
            for (int i = 0; i < 4; i++)
                lowBytes.Add(BitConverter.GetBytes(instance)[i]);

            for (int i = 4; i < 8; i++)
                highBytes.Add(BitConverter.GetBytes(instance)[i]);

            highlow[0] = BitConverter.ToUInt32(highBytes.ToArray(),0);
            highlow[1] = BitConverter.ToUInt32(lowBytes.ToArray(), 0);
            return highlow;
        }

        public void SavePackage(string fileName)
        {
            if (itemCount != 0)
            {
                Stream oStream = new FileStream(fileName, FileMode.Create);
                BinaryWriter writer = new BinaryWriter(oStream);

                //Write File header
                writer.Write(Encoding.ASCII.GetBytes("DBPF"));//magic number DBPF
                writer.Write((UInt32)2);
                writer.Write((UInt32)0);
                byte[] unUsed = new byte[24];
                writer.Write(unUsed);//unused
                writer.Write(itemCount);
                writer.Write((UInt32)0);//unused

                int sharedLength = GetSharedHeaderLenght(indexType);
                UInt32 indexSize = (UInt32)(1 + sharedLength + itemCount * (8 - sharedLength)) * 4;
                writer.Write(indexSize);//IndexHeadersLength
                byte[] unUsed2 = new byte[12];
                writer.Write(unUsed2);//unused
                writer.Write((UInt32)3);//version always 3

                UInt32 dataLength = 0;
                foreach (PackageItem item in items)
                    dataLength += (UInt32)item.Data.Length;
                UInt32 IndexHeaderOffset = 96 + dataLength;
                writer.Write(IndexHeaderOffset);// IndexPosition offset
                byte[] unUsed3 = new byte[28];
                writer.Write(unUsed3);//unused

                //Write Data;
                UInt32 offset = 96;
                for (int i = 0; i < itemCount; i++)
                {
                    PackageItem tempItem = new PackageItem(items[i]);
                    tempItem.DataOffset = offset;//Save offset
                    items.RemoveAt(i);
                    items.Insert(i, tempItem);

                    writer.Write(tempItem.Data);//FileBytes
                    offset += (UInt32)tempItem.Data.Length;
                }

                //Write Index Header
                writer.Write(indexType);

                if (sharedLength >= 1)
                    writer.Write(items[0].Type);

                if (sharedLength >= 2)
                    writer.Write(items[0].Group);

                for (int item = 0; item < itemCount; item++)//Read itemspecific header parts
                {
                    if (sharedLength == 0)
                        writer.Write(items[item].Type);

                    if (sharedLength <= 1)
                        writer.Write(items[item].Group);
                    writer.Write(GetInstanceIdHighLow(items[item].Instance)[0]);
                    writer.Write(GetInstanceIdHighLow(items[item].Instance)[1]);
                    writer.Write(items[item].DataOffset);
                    writer.Write(items[item].DataLength);
                    writer.Write(items[item].DataUnCompressedLength);
                    writer.Write(items[item].IsDataCompressed);
                }

                oStream.Close();
            }
        }

        /// <summary>
        /// Extracts the file in the .package directory
        /// </summary>
        /// <param name="saveFileName">Just the name no path or extension</param>
        public void ExtractFile(int itemNum,string saveFileName)
        {
            if (items[itemNum].Type == 121612807)//if file = s3sa file
            {
                FileInfo fiPack = new FileInfo(filePath);
                string savePath = fiPack.DirectoryName + "\\"+saveFileName + ".s3sa";
                Stream oStream = new FileStream(savePath, FileMode.Create);
                BinaryWriter writer = new BinaryWriter(oStream);
                writer.Write(items[itemNum].Data);
                oStream.Close();
            }
        }
    }
}
