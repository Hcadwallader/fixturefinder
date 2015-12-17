using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FixtureFinder;
using System.Data.SqlClient;
using System.Web.Mvc;
using FixtureFinder.Models;

namespace FixtureFinder.Models
{
    public class DatabaseCaller
    {


        public List<Event> populateStadiumInformation(List<Event> events)
        {            
            FixtureFinderEntities1 premierleaguegrounds = new FixtureFinderEntities1();

            // returns all of the stadiums
            //List<StadiumInfo> stadiums = premierleaguegrounds.StadiumInfos.ToList();

            // returns a list of stadiums where the home team is Liverpool
            //var liverpoolStadiums = premierleaguegrounds.StadiumInfos.Where(stadiumInfo => stadiumInfo.TeamName == "Liverpool");

            // returns a single stadium where the home team is Liverpool
            //StadiumInfo liverpoolstadium = premierleaguegrounds.StadiumInfos.Single(s => s.TeamName == "Liverpool");
            
            // scroll through and populate each event in the events list
            foreach(Event eventObject in events)
            {

                // start of the try block.  Any exceptions thrown in here ...
                try
                {
                    // searching for each stadium
                    System.Diagnostics.Debug.WriteLine("Searching for stadium of: " + eventObject.hometeam);
                    StadiumInfo stadium = premierleaguegrounds.StadiumInfos.Single(s => s.TeamName == eventObject.hometeam);
                    //StadiumInfo stadium = premierleaguegrounds.StadiumInfos.Single(s => s.TeamName.Contains(eventObject.hometeam));
                    //StadiumInfo stadium = premierleaguegrounds.StadiumInfos.Single(s => eventObject.hometeam.Contains(s.TeamName));
                    eventObject.location = stadium.StadiumName;
                    eventObject.locationLatitude = stadium.Latitude;
                    eventObject.locationLongitude = stadium.Longitude;
                    eventObject.homenickname = stadium.TeamNickName;
                    eventObject.stadiumcapacity = Convert.ToInt32(stadium.StadiumCapacity);
                    eventObject.description = stadium.StadiumDescription;
                    eventObject.picture = stadium.StadiumPicture;
                    eventObject.homecrest = stadium.ClubCrest;
                    eventObject.website = stadium.WebAddress;
                    eventObject.ticketoffice = stadium.TicketOffice;
                    eventObject.address = stadium.Address;


                    stadium = premierleaguegrounds.StadiumInfos.Single(s => s.TeamName == eventObject.awayteam);

                    eventObject.awaycrest = stadium.ClubCrest;
                    eventObject.awaynickname = stadium.TeamNickName;

                    // ... will be caught here ...
                } catch (InvalidOperationException e) // this is saying catch InvalidOperationExceptions and assign the error to 'e' within the code (so you can reference it)
                {
                    // catch block.  This code will only run if an exception was thrown in the try block
                    System.Diagnostics.Debug.WriteLine("failed to find stadium for team: " + eventObject.hometeam + ".  Are you sure that's how it's spelt in the database?");
                    eventObject.location = "Unknown"; // set the default stadium name here.  Maybe null instead of Unknown?
                }

            }
                   
            return events;
        }
    }
}
