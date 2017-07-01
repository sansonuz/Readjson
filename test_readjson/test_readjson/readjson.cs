using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;
using System.Runtime.Serialization.Json;

namespace test_readjson
{
    class readjson
    {
        public void init()
        {
            var p = new person2();
            p.Name = "Kato Jun";
            p.Age = 31;

            using (var ms = new MemoryStream())
            using (var sr = new StreamReader(ms))
            {
                var serializer = new DataContractJsonSerializer(typeof(person2));
                serializer.WriteObject(ms, p);
                ms.Position = 0;

                var json = sr.ReadToEnd();

                WriteLine($"{json}"); // {"Age":31,"Name":"Kato Jun"}
            }
        }
    }

    public class person2
    {
        public  string Name { get; set; }
        public int Age { get; set; }
        
    }
}
