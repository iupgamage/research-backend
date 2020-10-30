// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Neo4j.Driver;
using Neo4JSample.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Neo4JSample.Serializer;
using Neo4JSample.Settings;

namespace Neo4JSample
{
    public class Neo4JClient : IDisposable
    {
        private readonly IDriver driver;

        public Neo4JClient(IConnectionSettings settings)
        {
            this.driver = GraphDatabase.Driver(settings.Uri, settings.AuthToken);
        }

        //public async Task CreateIndices()
        //{
        //    string[] queries = {
        //        "CREATE INDEX ON :Movie(title)",
        //        "CREATE INDEX ON :Movie(id)",
        //        "CREATE INDEX ON :Person(id)",
        //        "CREATE INDEX ON :Person(name)",
        //        "CREATE INDEX ON :Genre(name)"
        //    };

        //    using (var session = driver.Session())
        //    {
        //        foreach(var query in queries)
        //        {
        //            session.Run(query);
        //        }
        //    }
        //}

        public async Task CreateRelationships_Service(IList<ServiceInformation> metadatas)
        {
            string cypher = new StringBuilder()
                .AppendLine("UNWIND $metadatas AS metadata")
                 // Find the Service:
                 .AppendLine("MERGE (m:Service { name: metadata.service.name, traceid: metadata.service.traceid })")
                 .AppendLine("SET m = metadata.service")
                 // Create FromService Relationships:
                 .AppendLine("WITH metadata, m")
                 .AppendLine("UNWIND metadata.fromservices AS fromservice")
                 .AppendLine("MERGE (a:Service { name: fromservice.name, traceid: fromservice.traceid })")
                 .AppendLine("SET a = fromservice")
                 .AppendLine("MERGE (a)-[r:calls]->(m)")
                 // Create ToService Relationships:
                 .AppendLine("WITH metadata, m")
                 .AppendLine("UNWIND metadata.toservices AS toservice")
                 .AppendLine("MERGE (c:Service { name: toservice.name, traceid: toservice.traceid })")
                 .AppendLine("SET c = toservice")
                 .AppendLine("MERGE (m)-[r:calls]->(c)")
                .ToString();

            using (var session = driver.Session())
            {
                session.Run(cypher, new Dictionary<string, object>() { { "metadatas", ParameterSerializer.ToDictionary(metadatas) } });
            }
        }

        public async Task DeleteGraph()
        {
            string cypher = new StringBuilder()
                .AppendLine("MATCH (n)")
                 .AppendLine("DETACH DELETE n")
                .ToString();

            using (var session = driver.Session())
            {
                session.Run(cypher);
            }
        }

        public List<ServiceDegreeInfo> GetDegrees()
        {
            List<ServiceDegreeInfo> serviceDegreeInfos = new List<ServiceDegreeInfo>();

            string cypher = new StringBuilder()
                .AppendLine("MATCH (s:Service)")
                 // Find the Service:
                 .AppendLine("WHERE s.traceid = 'null'")
                // Create FrontEnd relationship:
                .AppendLine("WITH s AS service, SIZE((s)<-[]-()) AS degree_in, SIZE((s)-[]->()) AS degree_out, SIZE((s) -[] - ()) AS degree")
                .AppendLine("RETURN service, degree_in, degree_out, degree")
                .ToString();

            using (var session = driver.Session())
            {
                //session.Run(cypher, new Dictionary<string, object>() { { "metadatas", ParameterSerializer.ToDictionary(metadatas) } });
                var results = session.Run(cypher);
                foreach (var record in results)
                {
                    ServiceDegreeInfo serviceDegreeInfo = new ServiceDegreeInfo();
                    var ServiceInfo = record["service"].As<INode>();
                    serviceDegreeInfo.Id = ServiceInfo.Properties["traceid"].As<string>();
                    serviceDegreeInfo.Name = ServiceInfo.Properties["name"].As<string>();

                    serviceDegreeInfo.Degree_out = record["degree_out"].As<int>();
                    serviceDegreeInfo.Degree_in = record["degree_in"].As<int>();
                    serviceDegreeInfo.Degree = record["degree"].As<int>();

                    //servicesInfo.serviceDegreeInfos.Add(serviceDegreeInfo);
                    serviceDegreeInfos.Add(serviceDegreeInfo);
                }
            }
            return serviceDegreeInfos;
        }

        public List<PathLengths> GetPathLengths()
        {
            List<PathLengths> pathLengthInfos = new List<PathLengths>();

            string cypher = new StringBuilder()
                .AppendLine("match p=(par:Service)-[r:calls*1..10]->(ch:Service)")
                 .AppendLine("where par.traceid<>'null' and ch.traceid<>'null'")
                .AppendLine("return DISTINCT  par.traceid as traceid, max(length(p)) as length")
                .ToString();

            using (var session = driver.Session())
            {
                var results = session.Run(cypher);
                foreach (var record in results)
                {
                    PathLengths pathLengthInfo = new PathLengths();
                    //var ServiceInfo = record["service"].As<INode>();
                    pathLengthInfo.traceid = record["traceid"].As<string>();
                    pathLengthInfo.length = record["length"].As<string>();

                    pathLengthInfos.Add(pathLengthInfo);
                }
            }
            return pathLengthInfos;
        }

        //Not working due to Neo4j update
        //public List<ServiceCCInfo> GetCC()
        //{
        //    List<ServiceCCInfo> serviceCCInfos = new List<ServiceCCInfo>();

        //    //create graph
        //    string cypher1 = new StringBuilder()
        //        .AppendLine("CALL gds.graph.create('cc_graph','Service', {calls: {orientation: 'UNDIRECTED'}})")
        //        .ToString();

        //    //get cc of all nodes in main graph and chains - using linq we filter it
        //    string cypher2 = new StringBuilder()
        //        .AppendLine("CALL gds.localClusteringCoefficient.stream('cc_graph')")
        //         .AppendLine("YIELD nodeId, localClusteringCoefficient")
        //        //.AppendLine("RETURN gds.util.asNode(nodeId).id as id, gds.util.asNode(nodeId).name AS name, localClusteringCoefficient")
        //        .AppendLine("RETURN gds.util.asNode(nodeId).traceid as traceid, gds.util.asNode(nodeId).name AS name, localClusteringCoefficient")
        //        .AppendLine("ORDER BY localClusteringCoefficient DESC")
        //        .ToString();

        //    //delete graph
        //    string cypher3 = new StringBuilder()
        //        .AppendLine("CALL gds.graph.drop('cc_graph') YIELD graphName")
        //        .ToString();

        //    using (var session = driver.Session())
        //    {
        //        session.Run(cypher1);
        //        var results = session.Run(cypher2);
        //        foreach (var record in results)
        //        {
        //            ServiceCCInfo serviceCCInfo = new ServiceCCInfo();
        //            serviceCCInfo.GUID = record["traceid"].As<string>();
        //            serviceCCInfo.Name = record["name"].As<string>();
        //            serviceCCInfo.CC = record["localClusteringCoefficient"].As<float>();

        //            serviceCCInfos.Add(serviceCCInfo);
        //        }
        //        session.Run(cypher3);
        //    }
        //    return serviceCCInfos;
        //}

        //Working currently
        public List<ServiceCCInfo> GetCC()
        {
            List<ServiceCCInfo> serviceCCInfos = new List<ServiceCCInfo>();

            string cypher = new StringBuilder()
                .AppendLine("CALL algo.triangleCount.stream('Service', 'calls', {concurrency:4})")
                 .AppendLine("YIELD nodeId, triangles, coefficient")
                .AppendLine("RETURN algo.asNode(nodeId).traceid as traceid, algo.asNode(nodeId).name AS name, triangles, coefficient")
                .AppendLine("ORDER BY coefficient DESC")
                .ToString();

            using (var session = driver.Session())
            {
                var results = session.Run(cypher);
                foreach (var record in results)
                {
                    ServiceCCInfo serviceCCInfo = new ServiceCCInfo();
                    serviceCCInfo.GUID = record["traceid"].As<string>();
                    serviceCCInfo.Name = record["name"].As<string>();
                    serviceCCInfo.CC = record["coefficient"].As<float>();

                    serviceCCInfos.Add(serviceCCInfo);
                }
            }
            return serviceCCInfos;
        }

        public void Dispose()
        {
            driver?.Dispose();
        }

        public class ServiceDegreeInfo
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public int Degree_out { get; set; }
            public int Degree_in { get; set; }
            public int Degree { get; set; }
            public float CC { get; set; }
        }

        public class ServiceCCInfo
        {
            public string GUID { get; set; }
            public string Name { get; set; }
            public float CC { get; set; }
        }

        public class PathLengths
        {
            public string traceid { get; set; } 
            public string length { get; set; } 
        }

    }
}