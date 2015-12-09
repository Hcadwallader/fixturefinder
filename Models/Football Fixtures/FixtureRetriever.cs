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
        public List<Event> getPremierLeagueFixtures(string days, String location) //  Added in a location string to the parameters
        {
            ApiCaller api = new ApiCaller();
            JSONparser jsonParser = new JSONparser();
            DatabaseCaller databaseCaller = new DatabaseCaller();
            DistanceMatrix distanceMatrix = new DistanceMatrix();
            Eventsorter eventSorter = new Eventsorter();
           

            String apiAddress = "http://api.football-data.org/v1/soccerseasons/398/fixtures";

            // calls the API and gets a String
            String jsonString = api.GET(apiAddress + urlParameters(days));

            // convert the string to a list of events – see below for this method
            List<Event> events = jsonParser.GetInfoFromWholeFootballDataComJSONstring(jsonString);

            // Maybe make a method like this too alter names of teams to less formal ones
            //events = standardizeEvents(events);

            // add in the stadium information from the database
            events = databaseCaller.populateStadiumInformation(events);

            // looking up the distance from current location to the stadiums
            events = distanceMatrix.distancefromLocation(events, location); // Added in the events to the parameters

            events = eventSorter.SortByTravelTime(events);

            // returns the events
            return events;
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


