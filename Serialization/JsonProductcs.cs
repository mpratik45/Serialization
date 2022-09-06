﻿using System;
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
    class JsonProductcs
    {

        [Serializable]
        public class product
        {
            public int pid { get; set; }
            public string pname { get; set; }
            public int pprice { get; set; }
        }



        static void JsonSerializationWrite(product prod)
        {
            try
            {
                FileStream fs = new FileStream(@"E:\New folder\JsonFile.json", FileMode.Create, FileAccess.Write);
                JsonSerializer.Serialize<product>(fs, prod);
                Console.WriteLine("Xml data added");
                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        static void JsonSerializationRead()
        {
            try
            {
                FileStream fs = new FileStream(@"E:\New Folder\JsonFile.json", FileMode.Open, FileAccess.Read);
                product prod = JsonSerializer.Deserialize<product>(fs);
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
            JsonSerializationWrite(prod);
            JsonSerializationRead();
        }

    }
}
