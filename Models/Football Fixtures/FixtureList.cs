using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FixtureFinder.Models
{
    public class FixtureList
    {
        public List<Event> GetFixtures()
        {
            List<Event> games = new List<Event>();
            games.Add(new Event("Liverpool", "Manchester City", "Anfield", "15:00"));
            games.Add(new Event("Norwich City", "Leicester City", "Carrow Road", "12:45"));
            return games;

        }
    }
}