using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace lesson16
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonString = "{\"firstName\":\"Tom\",\"lastName\":\"Jackson\",\"gender\":\"male\",\"age\":29,\"online\":true,\"hobby\":[\"football\",\"reading\",\"swimming\"]}";
            Person person = JsonSerializer.Deserialize<Person>(jsonString);
            Person person1 = new Person()
            {
                FirstName = "Вася",
                LastName = "Васильев",
                Gender = "муж",
                Age = 30,
                Online = false,
                Hobby = new string[] { "футбол", "програмирование" }
            };
            JsonSerializerOptions options1 = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin),
                WriteIndented = true
            };
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            jsonString = JsonSerializer.Serialize(person,options1);
            string jsonString1 = JsonSerializer.Serialize(person1,options);
            Console.WriteLine(jsonString);
            Console.WriteLine(jsonString1);
            Console.WriteLine(person.FirstName);
            Console.ReadKey();
        }
    }
    class Person
    { 
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }
        [JsonPropertyName("gender")]
        public string Gender { get; set; }
        [JsonPropertyName("age")]
        public int Age { get; set; }
        [JsonIgnore]
        [JsonPropertyName("online")]
        public bool Online { get; set; }
        [JsonPropertyName("hobby")]
        public string[] Hobby { get; set; }
    }
}
