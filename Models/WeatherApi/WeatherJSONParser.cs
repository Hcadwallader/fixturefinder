using FixtureFinder.Models;
using FixtureFinder.Models.DistanceApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Net;
using System.Text;
using FixtureFinder.Models.WeatherApi;


namespace FixtureFinder.Models.WeatherApi
{
    public class WeatherJSONParser
    {
        // declare a method within that which converts the string to data.  This will be unique for this website, hence why I’ve put that in the name.
        // you’ll have to make a new method like this for each api you want to call.
        public List<Event> GetdistanceinfoJSONstring(String originalJsonData)
        {
            List<Event> events = new List<Event>();

            // this line is using the Json.Net classes to convert to a list of Strings
            GoogleApiStructure google = JsonConvert.DeserializeObject<GoogleApiStructure>(originalJsonData);

            foreach (Row row in google.rows)
            {
                foreach (Element element in row.elements)
                {
                    events.Add(this.BuildEvent(element));
                }
            }

            return events;
        }

        // declaring another method to handle a single string array – put each task in a separate method and group similar methods into classes
        public Event BuildEvent(Element element)
        {
            Event newEvent = new Event();

            newEvent.distance = Convert.ToInt32(element.distance["value"]);
            newEvent.duration = Convert.ToInt32(element.duration["value"]);
            newEvent.durationFriendly = Convert.ToString(element.duration["text"]);

            return newEvent;
        }
    }
}