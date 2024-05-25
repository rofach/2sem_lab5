using System;
using System.Text;
using System.Xml.Serialization;

namespace Lab
{
	static partial class Programm
	{
		static public void PrintStruct(List<Zodiak> zzodiac)
		{
			foreach (var item in zzodiac)
			{
				Console.Write($"{item.name} {item.surname} {item.zodiak} {string.Join(" ", item.birthday)}\n");
			}
		}
		static void FindSurname(List<Zodiak> zodiac)
		{
			Console.WriteLine("Введіть прізвище яке потрібно знайти");
			string surname = Console.ReadLine();
			List<Zodiak> zodiacWithGivenSurname = zodiac.Where(x => x.surname == surname).ToList();
			if (zodiacWithGivenSurname.Count > 0) 
				PrintStruct(zodiacWithGivenSurname);
			else
				Console.WriteLine("Такого прізвища немає");
		}
		static void ReadStruct()
		{			
			Console.WriteLine("1 - xml\n" +
							  "2 - txt");
			int choice = int.Parse(Console.ReadLine());
			switch (choice)
			{
				case 1:
					{
						string filename = "Zodiak.xml";
						if (!File.Exists("Zodiak.xml")) { Console.WriteLine("Файлу не існує"); break; }
						List<Zodiak> zd = DeserializeZodiacFromXml(filename);
						FindSurname(zd);
						break;
					}
				case 2:
					{
						string filename = "Zodiak.txt";
						if (!File.Exists("Zodiak.txt")) { Console.WriteLine("Файлу не існує"); break; }
						List<Zodiak> zd = ReadZodiakFromTXT(filename);
						FindSurname(zd);
						break;
					}
				default:
					{
						Console.WriteLine("Неправильний ввід");
						break;
					}
			}
		}
		static List<Zodiak> WriteStructDataToList()
		{
			List<Zodiak> zodiak = new List<Zodiak>();
			if (File.Exists("input.txt"))
			{
				Console.WriteLine("Знайдено input.txt файл! Бажаєте зчитати з нього? t/f");
				string choice = Console.ReadLine();
				if (choice == "t")
				{
					zodiak = ReadZodiakFromTXT("input.txt");
					Console.WriteLine("Добавити свої дані? t/f");
					string choice2 = Console.ReadLine();
					if (choice2 != "t")
					{
						zodiak.Sort((a, b) => a.CompareTo(b));
						Console.WriteLine("Отримана структура: ");
						PrintStruct(zodiak);
						return zodiak;
					}
				}
				else Console.WriteLine("Не зчитуємо");
			}
			
			Console.WriteLine("Вводьте дані: ");
			
			string input = Console.ReadLine();
			while (input.Length != 0)
			{
				zodiak.Add(new Zodiak(input));
				input = Console.ReadLine();
			}
			
			zodiak.Sort();
			
			Console.WriteLine("Отримана структура: ");
			PrintStruct(zodiak);

			return zodiak;
			
		}
		static void WriteStructToFile()
		{
			List<Zodiak> zodiac = WriteStructDataToList();
			Console.WriteLine("Як записати структуру?\n" +
							  "1 - xml\n" +
							  "2 - txt\n" +
							  "3 - обидва");
			int choice = int.Parse(Console.ReadLine());
			switch (choice)
			{
				case 1:
					{
						string filename = "Zodiak.xml";
						SerializeZodiakIntoXML(zodiac, filename);
						break;
					}
				case 2:
					{
						string filename = "Zodiak.txt";
						WriteZodiakIntoTXT(zodiac, filename);
						break;
					}
				case 3:
					{
						string filename1 = "Zodiak.xml";
						string filename2 = "Zodiak.txt";
						SerializeZodiakIntoXML(zodiac, filename1);
						WriteZodiakIntoTXT(zodiac, filename2);
						break;
					}
				default:
					{
						Console.WriteLine("Неправильний ввід");
						break;
					}
			}
		}
		static void Main(string[] args)
		{
			Console.InputEncoding = System.Text.Encoding.GetEncoding("utf-16");
			Console.OutputEncoding = Encoding.UTF8;
			/*
			name1 csurname 12.10.2020
			name2 asurname 10.10.2010
			name3 bsurname 12.09.2016
			name4 bsurnamed 1.01.2016
			name5 zsurname 18.02.2016
			name6 zsurnameg 21.01.2016
			name7 ksurnameg 22.12.2016
			*/
			Console.WriteLine("1 - зчитати структуру\n" +
							  "2 - записати структуру");
			int choice = int.Parse(Console.ReadLine());
			switch(choice)
			{
				case 1: ReadStruct(); break;
				case 2: WriteStructToFile(); break;
				default:
					{
						Console.WriteLine("Неправильний ввід");
						break;
					}
			}
		}
	}
}