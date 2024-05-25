using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Security.Principal;

namespace Lab
{
	partial class Programm
	{
		static void SerializeZodiakIntoXML(List<Zodiak> zodiak, string filename)
		{
			try
			{
				XmlSerializer serializer = new XmlSerializer(typeof(List<Zodiak>));
				using (TextWriter writer = new StreamWriter(filename))
				{
					serializer.Serialize(writer, zodiak);					
				}
				Console.WriteLine("Серіалізовано в xml");
				//writer.Close();
			}
			catch (Exception e) { Console.WriteLine($"Помилка: {e}"); }
		}
		static List<Zodiak> DeserializeZodiacFromXml(string filename)
		{
			List<Zodiak> deserializedZodiak = new();
			try
			{
				XmlSerializer serializer = new XmlSerializer(typeof(List<Zodiak>));
				FileStream fileStream = new FileStream(filename, FileMode.Open);
				deserializedZodiak = (List<Zodiak>)serializer.Deserialize(fileStream);
				Console.WriteLine("Десеріалізовано з XML:");
				fileStream.Close();
			}
			catch (Exception e) { Console.WriteLine($"Помилка: {e}"); }
			PrintStruct(deserializedZodiak);
			return deserializedZodiak;
		}
	}
}
