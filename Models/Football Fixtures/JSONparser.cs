using FixtureFinder.Models;
using FixtureFinder.Models.Feed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Net;
using System.Text;


namespace FixtureFinder.Models
{
    // declare a new class called JsonParser
    public class JSONparser
    {

        
        // declare a method within that which converts the string to data.  This will be unique for this website, hence why I’ve put that in the name.
        // you’ll have to make a new method like this for each api you want to call.
        public List<Event> GetInfoFromWholeFootballDataComJSONstring(String originalJsonData)
        {
            List<Event> events = new List<Event>();

            // this line is using the Json.Net classes to convert to a list of Strings
            FeedResult data = JsonConvert.DeserializeObject<FeedResult> (originalJsonData);

            foreach (FeedFixture fixture in data.fixtures)
            {
                // build an event object, and add to our collection...
                events.Add( this.BuildEvent(fixture) );
            }

            return events;
        }

        // declaring another method to handle a single string array – put each task in a separate method and group similar methods into classes
        public Event BuildEvent(FeedFixture fixture)
        {


            // in the array, each position will be one bit of data
            // i.e. originalJson[0] might be the home team
            // originalJson[1] might be the away team etc.
            // you’ll have to work all this out and populate the event, then return that event
            Event newEvent = new Event();

            newEvent.date = convertdate(fixture.date);
            newEvent.hometeam = fixture.homeTeamName;
            newEvent.href = fixture._links.self["href"];
            newEvent.awayteam = fixture.awayTeamName;
            
            // etc. etc.
            return newEvent;
        }

        public DateTime convertdate(string originaldate)
        {
            DateTime newdate; //don't need to add public as it is a local variable so only exists within this method 
            newdate=Convert.ToDateTime(originaldate);
            return newdate;
        }

    }
}

//            "id": 147011,
//            "soccerseasonId": 398,
//            "date": "2015-10-03T11:45:00Z",
//            "matchday": 8,
//            "homeTeamName": "Crystal Palace FC",
//            "homeTeamId": 354,
//            "awayTeamName": "West Bromwich Albion FC",
//            "awayTeamId": 74,
//            "result":
//            {
//                "goalsHomeTeam": 2,
//                "goalsAwayTeam": 0
//            }