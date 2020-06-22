using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neo4JSample.Model
{
    public class ServiceInformation
    {
        [JsonProperty("service")]
        public Service Service { get; set; }

        [JsonProperty("fromservices")]
        public IList<Service> FromServices { get; set; }

        [JsonProperty("toservices")]
        public IList<Service> ToServices { get; set; }

        [JsonProperty("frontend")]
        public FrontEnd FrontEnd { get; set; }

        [JsonProperty("databases")]
        public IList<Database> Databases { get; set; }
    }
}
