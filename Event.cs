using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{

    // Class representing an event
    internal class Event
    {

        // Properties of the event
        public int EventNumber { get; set; }
        public string Location { get; set; }


        // Custom JSON serialization logic
        public string ToJson()
        {
            return $"{{\"EventNumber\":{EventNumber},\"Location\":\"{Location}\"}}";
        }

        // Custom JSON deserialization logic
        public static Event FromJson(string json)
        {
            if (string.IsNullOrEmpty(json))
                throw new ArgumentException("JSON string is null or empty");

            int eventNumberStartIndex = json.IndexOf("\"EventNumber\":") + "\"EventNumber\":".Length;
            int eventNumberEndIndex = json.IndexOf(',', eventNumberStartIndex);
            string eventNumberStr = json.Substring(eventNumberStartIndex, eventNumberEndIndex - eventNumberStartIndex);
            int eventNumber = int.Parse(eventNumberStr);

            int locationStartIndex = json.IndexOf("\"Location\":\"") + "\"Location\":\"".Length;
            int locationEndIndex = json.IndexOf('"', locationStartIndex);
            string location = json.Substring(locationStartIndex, locationEndIndex - locationStartIndex);

            return new Event { EventNumber = eventNumber, Location = location };
        }
    }
}
