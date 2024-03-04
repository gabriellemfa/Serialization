using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Serialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Instantiate Event Object
            Event myEvent = new Event
            {
                EventNumber = 1,
                Location = "Calgary"
            };

            // 3. Serialize Object to JSON File
            SerializeToJsonFile(myEvent, "event.json");

            // 4. Deserialize Object from JSON File
            Event deserializedEvent = DeserializeFromJsonFile("event.json");

            // Display values on the console
            Console.WriteLine($"Event Number: {deserializedEvent.EventNumber}");
            Console.WriteLine($"Location: {deserializedEvent.Location}");

            // 5. Read Characters from File
            ReadFromFile("event.json");

            Console.ReadLine();
        }

        // Method to serialize Event object to JSON file
        static void SerializeToJsonFile(Event myEvent, string filePath)
        {
            string json = myEvent.ToJson();
            File.WriteAllText(filePath, json);
        }

        // Method to deserialize Event object from JSON file
        static Event DeserializeFromJsonFile(string filePath)
        {
            string json = File.ReadAllText(filePath);
            return Event.FromJson(json);
        }

        // Method to read characters from file and display first, middle, and last characters
        static void ReadFromFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Write "Hackathon" to the file
                writer.Write("Hackathon");
            }

            // Read characters from the file
            using (StreamReader reader = new StreamReader(filePath))
            {
                // Utilize StreamReader and Seek method to read and display the first, middle, and last characters from the file
                reader.BaseStream.Seek(0, SeekOrigin.Begin);
                char firstChar = (char)reader.Read();

                reader.BaseStream.Seek(-1, SeekOrigin.End);
                char lastChar = (char)reader.Read();

                reader.BaseStream.Seek(-1, SeekOrigin.Current);
                char middleChar = (char)reader.Read();


                // Display characters on the console
                Console.WriteLine($"The First Character is: \"{firstChar}\"");
                Console.WriteLine($"The Middle Character is: \"{middleChar}\"");
                Console.WriteLine($"The Last Character is: \"{lastChar}\"");
            }
        }
    }
 
}

