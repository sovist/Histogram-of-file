using System;
using System.IO;
using System.Threading;

namespace Gisto
{
    static public class Entropy
    {
        public delegate void Progress(int progres);

        static public UInt64[] Calculate(string file, Progress progress)
        {
            UInt64[] masCountBytes = new UInt64[256];
            try
            {
                using (BinaryReader fileRead = new BinaryReader(File.Open(file, FileMode.Open, FileAccess.Read)))
                {
                    Int64 length = fileRead.BaseStream.Length;

                    while (fileRead.BaseStream.Position != length)
                    {
                        byte[] temp1 = fileRead.ReadBytes(3200000);

                        progress((int)(((double)fileRead.BaseStream.Position / fileRead.BaseStream.Length) * 100));

                        foreach (byte b in temp1)
                            masCountBytes[b]++;
                    }
                }
            }
            catch (IOException) { }

            return masCountBytes;
        }

        static public double Calculate(string file, out UInt64[] masBytes, Progress progress)
        {
            masBytes = Calculate(file, progress);
            Int64 length = 1;
            try
            {
                using (BinaryReader fileRead = new BinaryReader(File.Open(file, FileMode.Open, FileAccess.Read)))
                    length = fileRead.BaseStream.Length;
            }
            catch (IOException) { }

            double entropi = 0;
            for (int i = 0; i < masBytes.Length; i++)
                if (masBytes[i] != 0)
                {
                    double temp = (double)masBytes[i] / length;
                    entropi += -temp * Math.Log(temp, 2);
                }
            progress(100);
            Thread.Sleep(300);
            return entropi;
        }

        static public UInt64[] Calculate(string file)
        {
            UInt64[] masCountBytes = new UInt64[256];
            try
            {
                using (BinaryReader fileRead = new BinaryReader(File.Open(file, FileMode.Open, FileAccess.Read)))
                {
                    Int64 length = fileRead.BaseStream.Length;

                    while (fileRead.BaseStream.Position != length)
                    {
                        byte[] temp1 = fileRead.ReadBytes(3200000);
                        foreach (byte b in temp1)
                            masCountBytes[b]++;
                    }
                }
            }
            catch (IOException) { }

            return masCountBytes;
        }

        static public double Calculate(string file, out UInt64[] masBytes)
        {
            masBytes = Calculate(file);
            Int64 length = 1;
            try
            {
                using (BinaryReader fileRead = new BinaryReader(File.Open(file, FileMode.Open, FileAccess.Read)))
                    length = fileRead.BaseStream.Length;
            }
            catch (IOException) { }

            double entropi = 0;
            for (int i = 0; i < masBytes.Length; i++)
                if (masBytes[i] != 0)
                {
                    double temp = (double)masBytes[i] / length;
                    entropi += -temp * Math.Log(temp, 2);
                }
            return entropi;
        }
    }
}
