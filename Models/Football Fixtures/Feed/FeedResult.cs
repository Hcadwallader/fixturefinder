using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FixtureFinder.Models.Feed
{
    // represents the top-level object returned from the football api feed
    // E.g.: http://api.football-data.org/v1/soccerseasons/398/fixtures
    public class FeedResult
    {
        public Dictionary<String, String>[] _links;
        public int count;
        public List<FeedFixture> fixtures;
    }
}