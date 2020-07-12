using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neo4JSample.Model.DTOs
{
    public class SpanDto
    {
        [JsonProperty(PropertyName = "id")]
        public string id { get; set; }

        [JsonProperty(PropertyName = "traceId")]
        public string traceId { get; set; }

        [JsonProperty(PropertyName = "parentId")]
        public string parentId { get; set; }

        [JsonProperty(PropertyName = "kind")]
        public string kind { get; set; }

        [JsonProperty(PropertyName = "localEndpoint")]
        public LocalEndpoint localEndpoint { get; set; }

        [JsonProperty(PropertyName = "tags")]
        public Tags Tags { get; set; }
    }

    public class LocalEndpoint
    {
        [JsonProperty(PropertyName = "serviceName")]
        public string ServiceName { get; set; }
    }

    public class Tags
    {
        [JsonProperty(PropertyName = "http.path")]
        public string httpPath { get; set; }
    }
}
