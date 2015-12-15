using FixtureFinder.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FixtureFinder.Models
{
    public class Event
    {
        public String hometeam { get; set; }
        public String awayteam { get; set; }
        public String location { get; set; }
        public String locationLatitude { get; set; }
        public String locationLongitude { get; set; }
        public String time;
        public DateTime date { get; set; }
        public int matchday { get; set; }
        public int hometeamID { get; set; }
        public int awayteamID { get; set; }
        public String home;
        public String away;
        public int distance { get; set; } // meters from user to event
        public String distanceFriendly { get; set; }
        public int duration { get; set; }// duration of journey time to get there...
        public String durationFriendly { get; set; }
        public String homecrest { get; set; }
        public String awaycrest { get; set; }
        public String homenickname { get; set; }
        public String awaynickname { get; set; }
        public int stadiumcapacity { get; set; }
        public String description { get; set; }
        public String picture { get; set; }
        public String href { get; set; }


        public Event()
        {

        }
        public Event(string home, string away, string location, string time)
        {
            this.home = home;
            this.away = away;
            this.location = location;
            this.time = time;

        }

        // expose a method for retrieving the StadiumInfo related to the home team
        public StadiumInfo GetStadium()
        {
            FixtureFinderEntities1 db = new FixtureFinderEntities1();
            return db.StadiumInfos.Where(s => s.TeamName == this.hometeam).First();
        }
    }
}