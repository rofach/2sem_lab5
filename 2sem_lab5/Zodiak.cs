using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab
{

	[Serializable]
	public struct Zodiak : IComparable<Zodiak>
	{
		public string name;
		public string surname;
		public string zodiak;
		public int[] birthday;
		
		
		public Zodiak(string input)
		{
			string[] data = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
			name = data[0];
			surname = data[1];
			zodiak = "";
			int i = 2;
			if (data.Length == 4) i++;
			while (true)
			{
				try
				{
					birthday = Array.ConvertAll(data[i].Trim().Split("."), int.Parse);
					break;
				}
				catch (Exception ex)
				{
					Console.WriteLine("Неправильний формат! Введіть дату ще раз!");
					data[i] = Console.ReadLine();
				}
			}
			while (!isValidDate(birthday))
			{
				Console.WriteLine("Введіть дату ще раз");
				birthday = Array.ConvertAll(Console.ReadLine().Trim().Split("."), int.Parse);
				
			}
			zodiak = CheckZodiak(birthday);

		}
		string CheckZodiak(int[] date)
		{
			string[] zodiakSigns = new string[]
		{
			"Козеріг",
			"Водолій",
			"Риби",
			"Овен",
			"Телець",
			"Близнюки",
			"Рак",
			"Лев",
			"Діва",
			"Терези",
			"Скорпіон",
			"Стрілець"
		};
			int[] datesOfZodiak = { 20, 18, 20, 19, 20, 21, 22, 22, 22, 23, 22, 21 };
			return date[0] > datesOfZodiak[date[1] - 1] ? zodiakSigns[date[1] % 12] : zodiakSigns[date[1] - 1];
		}
		static bool isValidDate(int[] birthday)
		{
			try
			{
				DateTime dt = new DateTime(birthday[2], birthday[1], birthday[0]);
				DateTime currentDate = DateTime.Now;
				int isExistDate = DateTime.Compare(currentDate, dt);
				if (isExistDate >= 0)
					return true;
				else
				{
					Console.WriteLine("Така дата ще не настала!");
					return false;
				}
			}
			catch
			{
				Console.WriteLine($"Неправильна дата! ");
				return false;
			}
		}
		public int CompareTo(Zodiak that)
		{
			return this.surname.CompareTo(that.surname);
		}
	}
}
