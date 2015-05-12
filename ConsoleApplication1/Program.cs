using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.IO;
using System.IO.Compression;

namespace DelimiterExtention
{
    class c1 { }
    class Program
    {
        static void Main2(string[] args)
        {
            c1 c = null;
            bool bo = c is c1;
            byte[] input = new byte[]{ 1, 2, 3,99, 4, 6,7,8,9,99,10,11,12 };
            var ie = input.Skip(3).Take(4);
            //input
            byte[] delimiter = new byte[] { 99 };
            //切割input array 定界符號 => 99
            IEnumerable<IEnumerable<byte>> qqq = input.Split(delimiter);
            foreach (var i in qqq)
            {
                var item = i;
            }
            string[] strAry = Encoding.ASCII.GetString(input).Split('c').Select(x => x).ToArray();
            //var splitBytes = FriendAccess.Extensions.Split<byte[]>();
        }

        /// <summary>
        /// GZip壓縮和解壓縮測試
        /// https://msdn.microsoft.com/zh-tw/library/system.io.compression.gzipstream.write.aspx
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            UnicodeEncoding uniEncode = new UnicodeEncoding();

            byte[] bytesToCompress = uniEncode.GetBytes("我example text to compress and decompress");
            //--------------------------
            byte[] byteEncoding1 = Encoding.Unicode.GetBytes("我example text to compress and decompress");
            byte[] byteEncoding2 = Encoding.ASCII.GetBytes("我example text to compress and decompress");
            byte[] byteEncoding3 = Encoding.BigEndianUnicode.GetBytes("我example text to compress and decompress");
            byte[] byteEncoding4 = Encoding.UTF8.GetBytes("我example text to compress and decompress");
            byte[] byteEncoding5 = Encoding.GetEncoding(950).GetBytes("我example text to compress and decompress");
            //----------------------------
            Console.WriteLine("starting with: " + uniEncode.GetString(bytesToCompress));

            using (FileStream fileToCompress = File.Create("examplefile.gz"))
            {
                using (GZipStream compressionStream = new GZipStream(fileToCompress, CompressionMode.Compress))
                {
                    compressionStream.Write(bytesToCompress, 0, bytesToCompress.Length);
                }
            }

            byte[] decompressedBytes = new byte[bytesToCompress.Length];
            using (FileStream fileToDecompress = File.Open("examplefile.gz", FileMode.Open))
            {
                using (GZipStream decompressionStream = new GZipStream(fileToDecompress, CompressionMode.Decompress))
                {
                    decompressionStream.Read(decompressedBytes, 0, bytesToCompress.Length);
                }
            }

            Console.WriteLine("ending with: " + uniEncode.GetString(decompressedBytes));
        }

    }
}
