using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FixtureFinder.Models.Football_Fixtures.Feed
{
    public class Link
    {
        public Dictionary<string, string> self;
        public Dictionary<string, string> soccerseason;
        public Dictionary<string, string> homeTeam;
        public Dictionary<string, string> awayTeam;
    }
}