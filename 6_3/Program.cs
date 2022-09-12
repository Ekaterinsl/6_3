using System;
using System.IO;
using System.Text;

namespace _6_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo Key;
            do
            {
                Console.WriteLine("Введите 1 - чтобы вывести данные на экран");
                Console.WriteLine("Введите 2 - чтобы заполнить данные");
                Key = Console.ReadKey();
                Console.WriteLine();
                switch (Key.KeyChar)
                {
                    case '1':
                        Print();
                        break;
                    case '2':
                        Input();
                        break;
                    default:
                        Console.WriteLine("Выберите 1 или 2");
                        break;
                }
            }
            while (Key.Key != ConsoleKey.Escape);
        }
        static void Input()
        {
            if (!File.Exists(@"e:\rabs.csv"))
            {
                File.Create(@"e:\rabs.csv").Close();
                Console.WriteLine("Файл создан");
            }
            using (StreamWriter sw = new StreamWriter(@"e:\rabs.csv", true, Encoding.Unicode))
            {
                char Key = 'y';
                do
                {
                    string file = string.Empty;
                    Console.Write("\nВведите ID:  ");
                    file += $"{Console.ReadLine()}\t";
                    string now = DateTime.Now.ToString();
                    Console.Write($"Дата и время добавления записи: {now} ");
                    file += $"{now}\t";
                    Console.Write("\nВведите ФИО:   ");
                    file += $"{Console.ReadLine()}\t";
                    Console.Write("\nВведите возраст:   ");
                    file += $"{Console.ReadLine()}\t";
                    Console.Write("\nВведите рост:   ");
                    file += $"{Console.ReadLine()}\t";
                    Console.Write("\nВведите дату рождения:   ");
                    file += $"{Console.ReadLine()}\t";
                    Console.Write("\nВведите место рождения:   ");
                    file += $"{Console.ReadLine()}\t";
                    sw.WriteLine(file);
                    Console.Write("Продолжить n/y"); Key = Console.ReadKey(true).KeyChar;
                } while (char.ToLower(Key) == 'y');
            }
        }
        static void Print()
        {
            using (StreamReader sr = new StreamReader(@"e:\rabs.csv", Encoding.Unicode))
            {
                string line;
                Console.WriteLine($"{"ID",5}{"Дата и время",20}{"ФИО",15}{"Возраст",15}{"Рост",15}{"Дата рождения",15}{"Место рождения",20}");
                while ((line = sr.ReadLine()) != null)
                {
                    string[] data = line.Split('\t');
                    Console.WriteLine($"{data[0],5}{data[1],20}{data[2],15}{data[3],15}{data[4],15}{data[5],15}{data[6],20}");
                }
            }
        }
    }
}
