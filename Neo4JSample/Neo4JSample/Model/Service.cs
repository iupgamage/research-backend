using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neo4JSample.Model
{
    public class Service
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
