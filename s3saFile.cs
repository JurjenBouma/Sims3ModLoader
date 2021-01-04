using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Sims3ModLoader
{
    public class s3saFile
    {
        public enum FileType
        {
            DDL,S3SA
        }
        public string filePath;
        public string fileName;
        public byte fileVersion;
        public string gameVersion;
        public UInt32 checksumTypeId;
        byte[] checkSumData;
        ushort blockCount;
        byte[] encryptionTable;
        byte[] dataEncrypted;
        byte[] dataDecrypted;

        public s3saFile(string Path)
        {
            filePath = Path;

            FileInfo fiPackFile = new FileInfo(Path);
            fileName = fiPackFile.Name;
            Read();
        }

        private void Read()
        {
            FileInfo fiS3sa = new FileInfo(filePath);
            if(fiS3sa.Extension == ".s3sa")
                ReadS3sa();
            if (fiS3sa.Extension == ".dll")
                ReadDll();
        }

        private void ReadS3sa()
        {
            Stream iStream = new FileStream(filePath, FileMode.Open);
            BinaryReader reader = new BinaryReader(iStream);

            //header
            fileVersion = reader.ReadByte();
            if (fileVersion == 2)
            {
                UInt32 strLenght = reader.ReadUInt32();
                byte[] gameversBytes = reader.ReadBytes((int)strLenght * 2);
                gameVersion = UnicodeEncoding.Unicode.GetString(gameversBytes);
            }
            checksumTypeId = reader.ReadUInt32();
            checkSumData = reader.ReadBytes(64);
            blockCount = reader.ReadUInt16();
            encryptionTable = reader.ReadBytes(blockCount * 8);
            dataEncrypted = reader.ReadBytes(blockCount * 512);
            iStream.Close();
            Decrypt();
        }

        private void ReadDll()
        {
            Stream iStream = new FileStream(filePath, FileMode.Open);
            BinaryReader reader = new BinaryReader(iStream);
            dataDecrypted = reader.ReadBytes((int)iStream.Length);
            iStream.Close();
            fileVersion = 2;
            gameVersion = "0.2.0.209";
            checksumTypeId = 0x2BC4F79F;
            checkSumData = new byte[64];
            encryptionTable = new byte[(((dataDecrypted.Length & 0x1ff) == 0 ? 0 : 1) + (dataDecrypted.Length >>9))<<3];
            blockCount = (ushort)(encryptionTable.Length >> 3);
            Encrypt();
        }

        private void Decrypt()
        {
            MemoryStream dStream = new MemoryStream();
            MemoryStream eStream = new MemoryStream(dataEncrypted);

            ulong seed = 0;
            for (int i = 0; i < encryptionTable.Length; i += 8)
                seed += BitConverter.ToUInt64(encryptionTable, i);

            seed = (ulong)(encryptionTable.Length - 1) & seed;

            for (int i = 0; i < encryptionTable.Length; i += 8)
            {
                byte[] blockBuffer = new byte[512];
               
                if ((encryptionTable[i] & 1) == 0)
                {
                    eStream.Read(blockBuffer, 0, blockBuffer.Length);
                    for (int b = 0; b < blockBuffer.Length; b++)
                    {
                        byte blockByte = blockBuffer[b];
                        blockBuffer[b] ^= encryptionTable[seed];
                        seed = (ulong)((seed + blockByte) % (ulong)encryptionTable.Length);
                    }
                }
                dStream.Write(blockBuffer, 0, blockBuffer.Length);

            }
            dataDecrypted = dStream.ToArray();
        }

        private void Encrypt()
        {
            MemoryStream dStream = new MemoryStream(dataDecrypted);
            MemoryStream eStream = new MemoryStream();

            ulong seed = 0;
            for (int i = 0; i < encryptionTable.Length; i += 8)
                seed += BitConverter.ToUInt64(encryptionTable, i);

            seed = (ulong)(encryptionTable.Length - 1) & seed;

            for (int i = 0; i < encryptionTable.Length; i += 8)
            {
                byte[] blockBuffer = new byte[512];
                dStream.Read(blockBuffer, 0, blockBuffer.Length);

                for (int b = 0; b < blockBuffer.Length; b++)
                {
                    blockBuffer[b] ^= encryptionTable[seed];
                    seed = (ulong)((seed + blockBuffer[b]) % (ulong)encryptionTable.Length);
                }

                eStream.Write(blockBuffer, 0, blockBuffer.Length);

            }
            dataEncrypted = eStream.ToArray();
        }

        public void Save(string saveFileName,FileType type)
        {
            if(type == FileType.DDL)
                SaveDLL(saveFileName);
            if (type == FileType.S3SA)
                SaveS3SA(saveFileName);
        }

        private void SaveDLL(string saveFileName)
        {
            FileInfo fiS3sa = new FileInfo(filePath);
            string savePath = fiS3sa.DirectoryName + "\\" + saveFileName + ".dll";
            Stream oStream = new FileStream(savePath, FileMode.Create);
            BinaryWriter writer = new BinaryWriter(oStream);

            if (dataDecrypted != null)
                writer.Write(dataDecrypted, 0, dataDecrypted.Length);
            oStream.Close();
        }

        private void SaveS3SA(string saveFileName)
        {
            FileInfo fiDll = new FileInfo(filePath);
            string savePath = fiDll.DirectoryName + "\\" + saveFileName + ".s3sa";
            Stream oStream = new FileStream(savePath, FileMode.Create);
            BinaryWriter writer = new BinaryWriter(oStream);

            if (dataEncrypted != null)
            {
                writer.Write(fileVersion);
                writer.Write((UInt32)gameVersion.Length);
                writer.Write(UnicodeEncoding.Unicode.GetBytes(gameVersion));
                writer.Write(checksumTypeId);
                writer.Write(checkSumData);
                writer.Write(blockCount);
                writer.Write(encryptionTable);
                writer.Write(dataEncrypted);
            }
            oStream.Close();
        }
    }
}
