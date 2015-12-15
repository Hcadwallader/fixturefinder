using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using System.Web;
using FixtureFinder.Models;
using FixtureFinder.Models.Feed;
using FixtureFinder.Models.DistanceApi;


namespace FixtureFinder.Models
{
    public class FixtureRetriever
    {
        // 
        public const int REALLY_REALLY_BIG_NUMBER    = 100000001;
        public const int SLIGHTLY_SMALLER_BIG_NUMBER = 100000000;
        public const string WHEN_NO_VALUE = "unknown";

        public List<Event> getPremierLeagueFixtures(string days, string location, string travelmode) //  Added in a location string to the parameters
        {
            DatabaseCaller databaseCaller = new DatabaseCaller();
            DistanceMatrix distanceMatrix = new DistanceMatrix();
            Eventsorter eventSorter = new Eventsorter();

            // need to get the api results for the given days
            List<Event> events = this.GetEvents(days);


            // Maybe make a method like this too alter names of teams to less formal ones
            //events = standardizeEvents(events);

            // add in the stadium information from the database
            events = databaseCaller.populateStadiumInformation(events);

            // looking up the distance from current location to the stadiums
            events = distanceMatrix.distancefromLocation(events, location, travelmode); // Added in the events to the parameters

            events = eventSorter.SortByTravelTime(events);

            // returns the events
            return events;
        }

        public List<Event> GetEvents(string days)
        {
            String apiAddress = "http://api.football-data.org/v1/soccerseasons/398/fixtures";
            string apiAddressWithParams = apiAddress + urlParameters(days);

            ApiCaller api = new ApiCaller();
            String jsonString = api.GET(apiAddressWithParams);

            // calls the API and gets a String

            // convert the string to a list of events – see below for this method
            JSONparser jsonParser = new JSONparser();
            return jsonParser.GetInfoFromWholeFootballDataComJSONstring(jsonString);
        }

        public String urlParameters(string numberOfDaysToGetFixturesFor)
        {
            
            if (numberOfDaysToGetFixturesFor != null)
            {
                return "?timeFrame=n" + numberOfDaysToGetFixturesFor;
            } else
            {
                // if it was null, it means the user didn't enter any day's values
                return "";
            }
        }
    }
}


