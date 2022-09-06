using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;
using System.Xml.Serialization;
using System.Text.Json;

namespace Serialization
{


    class BinaryFormatterProduct
    {
        [Serializable]
        public class product
        {
            public int pid { get; set; }
            public string pname { get; set; }
            public int pprice { get; set; }
        }

        static void BinarySerializationWrite(product prod)
        {
            try
            {
                FileStream fs = new FileStream(@"E:\New folder\BinaryFile.dat", FileMode.Create, FileAccess.Write);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, prod);
                Console.WriteLine("Binary data Added");
                fs.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void BinarySerializationRead()
        {
            try
            {
                FileStream fs = new FileStream(@"E:\New folder\BinaryFile.dat", FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                product prod = (product)bf.Deserialize(fs);
                Console.WriteLine(prod.pid);
                Console.WriteLine(prod.pname);
                Console.WriteLine(prod.pprice);
                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void Main(string[] args)
        {
            product prod = new product { pid = 101, pname = "Mobile", pprice = 20000};
            BinarySerializationWrite(prod);
            BinarySerializationRead();
        }
    }
}
