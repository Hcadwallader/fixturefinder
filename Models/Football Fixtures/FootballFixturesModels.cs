using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FixtureFinder.Models
{
    public class FootballFixturesModels
    {
        public List<string> GetPremierLeagueFixtures()
        {
            List<String> results = new List<String>();
            results.Add("Liverpool vs City");
            results.Add("Arsenal vs West Brom");
            results.Add("Chelsea vs Norwich");
            return results;
        }
    }
}