using System;
using System.Collections.Generic;
using System.Text;

namespace Neo4JSample.Model
{
    public class Trace
    {
        public Trace()
        {
            //services = new List<Service>();
            serviceinformation = new List<ServiceInformation>();
        }

        //public List<Service> services { get; set; }
        public List<ServiceInformation> serviceinformation { get; set; }
    }
}
