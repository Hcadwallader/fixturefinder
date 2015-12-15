using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using System.Web;
using FixtureFinder.Models;
using FixtureFinder.Models.DistanceApi;
using FixtureFinder.Models.WeatherApi;

//namespace FixtureFinder.Models.WeatherApi
//{
//    public class WeatherForecaster
//    {
//        public List<Event> getWeatherForecast(events)
//        {
//            ApiCaller api = new ApiCaller();
//            WeatherJSONParser jsonParser = new WeatherJSONParser();

//            // calls the API and gets a String
//            //String jsonString = api.GET(apiAddress + urlParameters(location)); //PS 2/12/2015: commented this out as it's in the for loop now

//            // convert the string to a list of events – see below for this method
//            //List<Event> events = jsonParser.GetInfoFromWholeFootballDataComJSONstring(jsonString);



//            // right, so: location is the current location of the user
//            // so we're going to go through each event in the 'events' list and work out the location from the event to the current location
//            foreach (Event currentEvent in events)
//            {
//                //currentEvent.distance = getDistanceFromAtoB(location, currentEvent.locationLatitude, currentEvent.locationLongitude);
//                PopulateEventWithDistances(currentEvent, location, travelmode);
//            }

//            // returns the events
//            return events;
//        }

     

//        public Event PopulateEventWithDistances(Event currentEvent, String locationA, string travelmode)
//        {
//            // setting up the variables
//            ApiCaller api = new ApiCaller();
//            JSONparserdistances jsonParser = new JSONparserdistances(); // Changed this too the new JSON parser
//            String apiAddress = "http://datapoint.metoffice.gov.uk/public/data/val/wxfcs/all/json/";
//                3041?res=3hourly&time=2015-12-18T06:00:00Z&key=faf9aebc-4fe9-48fc-ac3b-38754b8ffec9";

//            String addressToCall = apiAddress + eventLocation + "?" + destination(currentEvent.locationLatitude, currentEvent.locationLongitude) + "&" + mode(travelmode) + "&" + apiKey();

//            // calling the api
//            String jsonString = api.GET(addressToCall);

//            currentEvent.distance = jsonParser.extractDistanceFromGoogleMapsJsonString(jsonString);
//            currentEvent.duration = jsonParser.extractTimeTakenFromGoogleMapsJsonString(jsonString);
//            currentEvent.durationFriendly = jsonParser.extractFriendlyTimeTakenFromGoogleMapsJsonString(jsonString);
//            currentEvent.distanceFriendly = convertFromMetersToMiles(currentEvent.distance);

//            return currentEvent;
//        }
//        public String location (string eventLocation)
//        {
//            return eventLocation;
//        }

//        public String apiKey ()
//        {
//            string apiKey = "faf9aebc-4fe9-48fc-ac3b-38754b8ffec9";
//            return "key=" + apiKey;
//        }
//    }
//}