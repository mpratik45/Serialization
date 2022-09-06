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
    class XMLSerialization
    {

        [Serializable]
        public class product
        {
            public int pid { get; set; }
            public string pname { get; set; }
            public int pprice { get; set; }
        }


        static void XmlSerializationWrite(product prod)
        {
            try
            {
                FileStream fs = new FileStream(@"E:\New folder\XmlFile.xml", FileMode.Create, FileAccess.Write);
                XmlSerializer xs = new XmlSerializer(typeof(product));
                xs.Serialize(fs, prod);
                Console.WriteLine("Xml data added");
                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        static void XmlSerializationRead()
        {
            try
            {
                FileStream fs = new FileStream(@"E:\New folder\XmlFile.xml", FileMode.Open, FileAccess.Read);
                XmlSerializer xs = new XmlSerializer(typeof(product));
                product prod = (product)xs.Deserialize(fs);
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
            product prod = new product { pid = 101, pname = "Mobile", pprice = 20000 };
            XmlSerializationWrite(prod);
            XmlSerializationRead();
        }
    }
}
