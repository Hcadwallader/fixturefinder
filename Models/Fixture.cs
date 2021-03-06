﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FixtureFinder.Models
{

    internal class Fixture
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("soccerseasonId")]
        public int SoccerseasonId { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("matchday")]
        public int Matchday { get; set; }

        [JsonProperty("homeTeamName")]
        public string HomeTeamName { get; set; }

        [JsonProperty("homeTeamId")]
        public int HomeTeamId { get; set; }

        [JsonProperty("awayTeamName")]
        public string AwayTeamName { get; set; }

        [JsonProperty("awayTeamId")]
        public int AwayTeamId { get; set; }

        [JsonProperty("result")]
        public Result Result { get; set; }
    }

}
