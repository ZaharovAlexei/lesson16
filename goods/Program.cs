using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.IO;

namespace goods
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             1.    Необходимо разработать программу для записи информации о товаре в текстовый файл в формате json.

            Разработать класс для моделирования объекта «Товар». Предусмотреть члены класса «Код товара» (целое число), «Название товара» (строка), «Цена товара» (вещественное число).
            Создать массив из 5-ти товаров, значения должны вводиться пользователем с клавиатуры.
            Сериализовать массив в json-строку, сохранить ее программно в файл «Products.json».

            2.    Необходимо разработать программу для получения информации о товаре из json-файла.
            Десериализовать файл «Products.json» из задачи 1. Определить название самого дорогого товара.
             */
            Console.WriteLine("Введите информацию по товарам: Код, Название, Цена");
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string[] goods = new string [5];
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Введите информацию по {0}-му товару",i+1);
                Goods product = new Goods()
                {
                    CodeProduct = Convert.ToInt32(Console.ReadLine()),
                    NameProduct = Console.ReadLine(),
                    PriceProduct = Convert.ToDecimal(Console.ReadLine())
                };
                goods[i] = JsonSerializer.Serialize(product, options);
            }
            string file = "G:/Рабочий стол/Повышение квалификации/Products.json";
            using (StreamWriter sw = new StreamWriter(file))
            {
                for (int i = 0; i < 5; i++)
                {
                    sw.WriteLine(goods[i]);
                }
            }
            Console.ReadKey();
        }
    }
    class Goods
    {
        [JsonPropertyName("Код товара")]
        public int CodeProduct { get; set; }
        [JsonPropertyName("Наименование товара")]

        public string NameProduct { get; set; }
        [JsonPropertyName("Цена товара")]

        public decimal PriceProduct { get; set; }
    }
}
