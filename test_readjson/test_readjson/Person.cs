using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;


namespace test_readjson
{
    [DataContract]
    public class Person
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public IDictionary<string, string> Attributes { get; private set; }

        public Person()
        {
            this.Attributes = new Dictionary<string, string>();
        }

        public void Main()
        {
            // データの作成
            var p_1 = new Person()
            {
                ID = 0,
                Name = "Taka",
            };
            p_1.Attributes.Add("key1", "value1");
            p_1.Attributes.Add("key2", "value2");
            p_1.Attributes.Add("key3", "value3");

            var p_2 = new Person()
            {
                ID = 1,
                Name = "PG",
            };
            p_2.Attributes.Add("keyAA", "valueAA");
            p_2.Attributes.Add("keyBB", "valueBB");
            p_2.Attributes.Add("keyCC", "valueCC");

            // リストに設定する
            List<Person> pList = new List<Person>() { p_1, p_2 };

            // リストをデシリアライズ
            string json = JsonUtility.Serialize(pList);

            // 内容をコンソールへ表示
            Console.WriteLine(json);
        }


    }

    public static class JsonUtility
    {
        /// <summary>
        /// 任意のオブジェクトを JSON メッセージへシリアライズします。
        /// </summary>
        public static string Serialize(object graph)
        {
            using (var stream = new MemoryStream())
            {
                var serializer = new DataContractJsonSerializer(graph.GetType());
                serializer.WriteObject(stream, graph);
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }
    }

}
