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
    class SoapSerialization
    
    {
        [Serializable]
        public class product
        {
            public int pid { get; set; }
            public string pname { get; set; }
            public int pprice { get; set; }
        }


        static void SoapSerializationWrite(product prod)
    {
        try
        {
            FileStream fs = new FileStream(@"D:\.netCore\TestFolder\SoapFile.soap", FileMode.Create, FileAccess.Write);
            SoapFormatter sf = new SoapFormatter();
            sf.Serialize(fs, prod);
            Console.WriteLine("Xml data added");
            fs.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
    static void SoapSerializationRead()
    {
        try
        {
            FileStream fs = new FileStream(@"D:\.netCore\TestFolder\SoapFile.soap", FileMode.Open, FileAccess.Read);
            SoapFormatter sf = new SoapFormatter();
            product prod = (product)sf.Deserialize(fs);
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
            SoapSerializationWrite(prod);
            SoapSerializationRead();
        }

    }
}
