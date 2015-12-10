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

namespace FixtureFinder.Models
{
	public class DistanceMatrix
	{

        public List<Event> distancefromLocation(List<Event> events, string location) //adding in the events to the parameter
        {
            ApiCaller api = new ApiCaller();
            JSONparser jsonParser = new JSONparser();

            // calls the API and gets a String
            //String jsonString = api.GET(apiAddress + urlParameters(location)); //PS 2/12/2015: commented this out as it's in the for loop now

            // convert the string to a list of events – see below for this method
            //List<Event> events = jsonParser.GetInfoFromWholeFootballDataComJSONstring(jsonString);


         
            // right, so: location is the current location of the user
            // so we're going to go through each event in the 'events' list and work out the location from the event to the current location
            foreach(Event currentEvent in events)
            {
                //currentEvent.distance = getDistanceFromAtoB(location, currentEvent.locationLatitude, currentEvent.locationLongitude);
                PopulateEventWithDistances(currentEvent, location);
            }

            // returns the events
            return events;
        }

        // new method . Uses the GoogleAPI to work out the distance from A to B
        //might want to swap this, so that it gets the location and time taken, in which case you'll want to pass in the object instead of locationB...
        //public int getDistanceFromAtoB(String locationA, String locationB)
        public int getDistanceFromAtoB(String locationA, String locationBLatitude, String locationBLongitude)
        {
            // setting up the variables
            ApiCaller api = new ApiCaller();
            JSONparserdistances jsonParser = new JSONparserdistances(); // Changed this too the new JSON parser
            String apiAddress = "https://maps.googleapis.com/maps/api/distancematrix/json";

            // calling the api
            String jsonString = api.GET(apiAddress + "?" + origin(locationA) + "&" + destination(locationBLatitude, locationBLongitude) + "&" + apiKey());

            // parse and return the result
            return jsonParser.extractDistanceFromGoogleMapsJsonString(jsonString);
        }

        public Event PopulateEventWithDistances(Event currentEvent, String locationA)
        {
            // setting up the variables
            ApiCaller api = new ApiCaller();
            JSONparserdistances jsonParser = new JSONparserdistances(); // Changed this too the new JSON parser
            String apiAddress = "https://maps.googleapis.com/maps/api/distancematrix/json";

            // calling the api
            String jsonString = api.GET(apiAddress + "?" + origin(locationA) + "&" + destination(currentEvent.locationLatitude, currentEvent.locationLongitude) + "&" + apiKey());

            currentEvent.distance = jsonParser.extractDistanceFromGoogleMapsJsonString(jsonString);
            currentEvent.duration = jsonParser.extractTimeTakenFromGoogleMapsJsonString(jsonString);
            currentEvent.durationFriendly = jsonParser.extractFriendlyTimeTakenFromGoogleMapsJsonString(jsonString);
            currentEvent.distanceFriendly = convertFromMetersToMiles(currentEvent.distance);

            return currentEvent;
        }

        public String origin(string userLocation)
        {
            return "origins=" + userLocation;
        }

        public String destination(string StadiumLocation)
        {
            return "destinations=" + StadiumLocation;
        }

        public String destination(string latitude, string longitude)
        {
            return "destinations=" + latitude + "," + longitude;
        }
       
        public String apiKey()
        {
            string apiKey = "AIzaSyCGKm0iFBxIIIhc9rUlW5ATIIgKW6d - wkQ";
            return "key=" + apiKey;
        }

        public string convertFromMetersToMiles(int distance)
        {
            string distanceFriendly;
            double distanceTemporary = distance / 1609.34;
            distanceFriendly = "" + Math.Round(distanceTemporary, 2) + " miles";
            return distanceFriendly;
        }
    }
}

	
