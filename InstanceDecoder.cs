using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Sims3ModLoader
{
    static class InstanceDecoder
    {
        private struct InstanceItem
        {
            public UInt64 Instance;
            public string Name;
            public  InstanceItem(UInt64 instance, string name)
            {
                this.Instance = instance;
                this.Name = name;
            }
        }
        private static List<InstanceItem> instanceList;

        public static void Initialize()
        {
            FillInsanceList();
        }

        private static void FillInsanceList()
        {
            instanceList = new List<InstanceItem>();

            InstanceItem i1 = new InstanceItem(17853304562301331301, "UI");
            instanceList.Add(i1);

            InstanceItem i2 = new InstanceItem(276629261527189132, "Sims3GameplaySystems");
            instanceList.Add(i2);

            InstanceItem i3 = new InstanceItem(13387248806640466954, "Sims3GameplayObjects");
            instanceList.Add(i3);

            InstanceItem i4 = new InstanceItem(913698793160290995, "Sims3StoreObjects");
            instanceList.Add(i4);

            InstanceItem i5 = new InstanceItem(14075683330528566594, "SimIFace");
            instanceList.Add(i5);

            InstanceItem i6 = new InstanceItem(8705296405063601231, "ScriptCore");
            instanceList.Add(i6);

            InstanceItem i7 = new InstanceItem(6921925570339643313, "Sims3Metadata");
            instanceList.Add(i7);

            InstanceItem i8 = new InstanceItem(7692430820452187889, "System.Xml");
            instanceList.Add(i8);

            InstanceItem i9 = new InstanceItem(3760189319211327004, "System");
            instanceList.Add(i9);

            InstanceItem i10 = new InstanceItem(2949467670798616126, "mscorlib");
            instanceList.Add(i10);
        }

        public static string GetName(UInt64 instance)
        {
            foreach(InstanceItem inst in instanceList)
            {
                if (inst.Instance == instance)
                    return inst.Name;
            }
            return "Uknown";
        }

        public static UInt64 GetInstance(string name)
        {
            foreach (InstanceItem inst in instanceList)
            {
                if (inst.Name == name)
                    return inst.Instance;
            }

            UInt64 prime = 0x00000100000001B3;
            UInt64 hash = 0xCBF29CE484222325;
       
            byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(name.ToLowerInvariant());
            foreach(byte b in data)
            {
                hash *= prime;
                hash ^= b;
            }

            return hash;
        }
    }
}
