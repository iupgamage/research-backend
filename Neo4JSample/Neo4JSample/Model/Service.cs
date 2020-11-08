using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neo4JSample.Model
{
    public class Service
    {
        //[JsonProperty("id")]
        //public string Id { get; set; }

        [JsonProperty("traceid")]
        public string TraceId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        //[JsonProperty("servicechain")]
        //public string ServiceChain { get; set; }

        //[JsonProperty("isinchain")]
        //public string IsInChain { get; set; }

        [JsonProperty("endpoint")]
        public string EndPoint { get; set; }

        [JsonProperty("community")]
        public int Community { get; set; }
    }
}
