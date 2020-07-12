using System;
using System.Collections.Generic;
using System.Text;

namespace Neo4JSample.Model.DTOs
{
    public class TraceDto
    {
        public List<SpanDto> Spans { get; set; }
    }
}
