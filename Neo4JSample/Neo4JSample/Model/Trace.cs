using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Neo4JSample.Model
{
    public class Trace
    {
        public Trace()
        {
            serviceinformation = new List<ServiceInformation>();
        }

        public List<ServiceInformation> serviceinformation { get; set; }

        public string EndpointsAsString
        {
            get
            {
                var str = string.Empty;
                var endpointsObj = this.serviceinformation.Where(x => x.Service.TraceId != "null").Select(y => new
                {
                    Endpoint = y.Service.EndPoint
                });

                foreach (var obj in endpointsObj)
                {
                    str = str + $",{obj.Endpoint}";
                }
                return str;
            }
        }
    }
}
