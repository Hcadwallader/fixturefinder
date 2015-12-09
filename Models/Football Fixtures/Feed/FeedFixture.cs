using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FixtureFinder.Models.Feed
{
    public class FeedFixture
    {
        public Dictionary<string, Dictionary<string, string>> _links;
        public string date;
        public string status;
        public int matchday;
        public string homeTeamName;
        public string awayTeamName;
        public Dictionary<string, object> result;
    }
}