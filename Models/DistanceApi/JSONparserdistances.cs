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



namespace FixtureFinder.Models.DistanceApi
{
    public class JSONparserdistances
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
                foreach(Element element in row.elements)
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

            newEvent.distance = Convert.ToInt32( element.distance["value"] );
            newEvent.duration = Convert.ToInt32( element.duration["value"] );
            newEvent.durationFriendly = Convert.ToString( element.duration["text"] );   
          
            return newEvent;
        }

       //new method created to extract the distance from the whole JSON string
        internal int extractDistanceFromGoogleMapsJsonString(string jsonString)
        {
            // this line is using the Json.Net classes to convert to a list of Strings
            GoogleApiStructure google = JsonConvert.DeserializeObject<GoogleApiStructure>(jsonString);
            int result = FixtureRetriever.SLIGHTLY_SMALLER_BIG_NUMBER;

            foreach (Row row in google.rows)
            {
                foreach(Element element in row.elements)
                {
                    // should only be one!
                    if (element.distance != null)
                    {
                        result = Convert.ToInt32( element.distance["value"] );
                    }
                }
            }

            return result;
        }

        internal int extractTimeTakenFromGoogleMapsJsonString(string jsonString)
        {
            // this line is using the Json.Net classes to convert to a list of Strings
            GoogleApiStructure google = JsonConvert.DeserializeObject<GoogleApiStructure>(jsonString);
            int result = FixtureRetriever.SLIGHTLY_SMALLER_BIG_NUMBER;

            foreach (Row row in google.rows)
            {
                foreach (Element element in row.elements)
                {
                    // should only be one!
                    if (element.duration != null)
                    {
                        result = Convert.ToInt32( element.duration["value"]);
                    }
                }
            }

            return result;
        }

        internal string extractFriendlyTimeTakenFromGoogleMapsJsonString(string jsonString)
        {
            // this line is using the Json.Net classes to convert to a list of Strings
            GoogleApiStructure google = JsonConvert.DeserializeObject<GoogleApiStructure>(jsonString);
            string result = FixtureRetriever.WHEN_NO_VALUE;

            foreach (Row row in google.rows)
            {
                foreach (Element element in row.elements)
                {
                    // should only be one!
                    if (element.duration != null)
                    {
                        result = Convert.ToString(element.duration["text"]);
                    }
                }
            }

            return result;
        }
        }
}
