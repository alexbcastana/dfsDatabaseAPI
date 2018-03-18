using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace dfsTest.Models
{
    public class Player
    {
        [JsonProperty(PropertyName = "id")]
        public String Id { get; set; }

        [JsonProperty(PropertyName = "fName")]
        public string FName { get; set; }

        [JsonProperty(PropertyName = "lName")]
        public string LName { get; set; }

        [JsonProperty(PropertyName = "salary")]
        public int Salary { get; set; }

        [JsonProperty(PropertyName = "position")]
        public string Position { get; set; }

        [JsonProperty(PropertyName = "inLineup")]
        public Boolean InLineup { get; set; }
    }
}