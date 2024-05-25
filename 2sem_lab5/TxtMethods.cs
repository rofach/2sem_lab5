using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
	static partial class Programm
	{
		public static List<Zodiak> ReadZodiakFromTXT(string filename)
		{
			string line;
			List<Zodiak> zodiak = new();
			try
			{
				StreamReader sr = new(filename);
				line = sr.ReadLine();
				while (line != null)
				{
					zodiak.Add(new Zodiak(line));
					line = sr.ReadLine();
				}
				sr.Close();
				Console.WriteLine("Прочитано з txt");
			}
			catch (Exception e) { Console.WriteLine($"Error {e.Message}"); }
			PrintStruct(zodiak);
			return zodiak;
		}
		public static void WriteZodiakIntoTXT(List<Zodiak> zodiak, string filename)
		{
			try
			{
				StreamWriter sw = new(filename);
				foreach (var item in zodiak)
				{
					sw.WriteLine($"{item.name} {item.surname} {item.zodiak} {string.Join(".", item.birthday)}");
				}
				sw.Close();
				Console.WriteLine("Записано в txt");
			}
			catch (Exception e) { Console.WriteLine($"Error {e.Message}"); }
			
		}
	}
}
