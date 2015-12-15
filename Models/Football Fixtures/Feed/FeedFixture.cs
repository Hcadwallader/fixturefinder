using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FixtureFinder.Models.Football_Fixtures.Feed;

namespace FixtureFinder.Models.Feed
{
    public class FeedFixture
    {
        public Link _links;
        public string date;
        public string status;
        public int matchday;
        public string homeTeamName;
        public string awayTeamName;
        public Dictionary<string, object> result;
    }
}