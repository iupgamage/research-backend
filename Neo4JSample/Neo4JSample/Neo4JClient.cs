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

        //public async Task CreatePersons(IList<Person> persons)
        //{
        //    string cypher = new StringBuilder()
        //        .AppendLine("UNWIND $persons AS person")
        //        .AppendLine("MERGE (p:Person {name: person.name})")
        //        .AppendLine("SET p = person")
        //        .ToString();

        //    using (var session = driver.Session())
        //    {
        //        session.Run(cypher, new Dictionary<string, object>() { { "persons", ParameterSerializer.ToDictionary(persons) } });
        //    }
        //}

        //public async Task CreateGenres(IList<Genre> genres)
        //{
        //    string cypher = new StringBuilder()
        //        .AppendLine("UNWIND $genres AS genre")
        //        .AppendLine("MERGE (g:Genre {name: genre.name})")
        //        .AppendLine("SET g = genre")
        //        .ToString();

        //    using (var session = driver.Session())
        //    {
        //        session.Run(cypher, new Dictionary<string, object>() { { "genres", ParameterSerializer.ToDictionary(genres) } });
        //    }
        //}

        //public async Task CreateMovies(IList<Movie> movies)
        //{
        //    string cypher = new StringBuilder()
        //        .AppendLine("UNWIND $movies AS movie")
        //        .AppendLine("MERGE (m:Movie {id: movie.id})")
        //        .AppendLine("SET m = movie")
        //        .ToString();

        //    using (var session = driver.Session())
        //    {
        //        session.Run(cypher, new Dictionary<string, object>() { { "movies", ParameterSerializer.ToDictionary(movies) } });
        //    }
        //}

        //public async Task CreateRelationships(IList<MovieInformation> metadatas)
        //{
        //    string cypher = new StringBuilder()
        //        .AppendLine("UNWIND $metadatas AS metadata")
        //        // Find the Movie:
        //         .AppendLine("MATCH (m:Movie { title: metadata.movie.title })")
        //         // Create Cast Relationships:
        //         .AppendLine("UNWIND metadata.cast AS actor")   
        //         .AppendLine("MATCH (a:Person { name: actor.name })")
        //         .AppendLine("MERGE (a)-[r:ACTED_IN]->(m)")
        //          // Create Director Relationship:
        //         .AppendLine("WITH metadata, m")
        //         .AppendLine("MATCH (d:Person { name: metadata.director.name })")
        //         .AppendLine("MERGE (d)-[r:DIRECTED]->(m)")
        //        // Add Genres:
        //        .AppendLine("WITH metadata, m")
        //        .AppendLine("UNWIND metadata.genres AS genre")
        //        .AppendLine("MATCH (g:Genre { name: genre.name})")
        //        .AppendLine("MERGE (m)-[r:GENRE]->(g)")
        //        .ToString();


        //    using (var session = driver.Session())
        //    {
        //        session.Run(cypher, new Dictionary<string, object>() { { "metadatas", ParameterSerializer.ToDictionary(metadatas) } });
        //    }
        //}

        public async Task CreateServices(IList<Service> services)
        {
            //string cypher = new StringBuilder()
            //    .AppendLine("UNWIND $services AS service")
            //    .AppendLine("MERGE (s:Service {name: service.name, servicechain: service.servicechain})")
            //    .AppendLine("SET s = service")
            //    .ToString();

            string cypher = new StringBuilder()
                .AppendLine("UNWIND $services AS service")
                .AppendLine("MERGE (s:Service {name: service.name, traceid: service.traceid})")
                .AppendLine("SET s = service")
                .ToString();

            using (var session = driver.Session())
            {
                session.Run(cypher, new Dictionary<string, object>() { { "services", ParameterSerializer.ToDictionary(services) } });
            }
        }

        public async Task CreateFrontEnds(IList<FrontEnd> frontends)
        {
            string cypher = new StringBuilder()
                .AppendLine("UNWIND $frontends AS frontend")
                .AppendLine("MERGE (f:FrontEnd {name: frontend.name})")
                .AppendLine("SET f = frontend")
                .ToString();

            using (var session = driver.Session())
            {
                session.Run(cypher, new Dictionary<string, object>() { { "frontends", ParameterSerializer.ToDictionary(frontends) } });
            }
        }

        public async Task CreateDatabases(IList<Database> databases)
        {
            string cypher = new StringBuilder()
                .AppendLine("UNWIND $databases AS database")
                .AppendLine("MERGE (d:Database {name: database.name})")
                .AppendLine("SET d = database")
                .ToString();

            using (var session = driver.Session())
            {
                session.Run(cypher, new Dictionary<string, object>() { { "databases", ParameterSerializer.ToDictionary(databases) } });
            }
        }

        public async Task CreateRelationships_Service(IList<ServiceInformation> metadatas)
        {
            //string cypher = new StringBuilder()
            //    .AppendLine("UNWIND $metadatas AS metadata")
            //     // Find the Service:
            //     .AppendLine("MATCH (m:Service { name: metadata.service.name, servicechain: metadata.service.servicechain })")
            //     // Create FromService Relationships:
            //     .AppendLine("UNWIND metadata.fromservices AS fromservice")
            //     .AppendLine("MATCH (a:Service { name: fromservice.name, servicechain: fromservice.servicechain })")
            //     .AppendLine("MERGE (a)-[r:S_INVOKES_S]->(m)")
            //     // Create ToService Relationships:
            //     .AppendLine("WITH metadata, m")
            //     .AppendLine("UNWIND metadata.toservices AS toservice")
            //     .AppendLine("MATCH (c:Service { name: toservice.name, servicechain: toservice.servicechain })")
            //     .AppendLine("MERGE (m)-[r:S_INVOKES_S]->(c)")
            //    // Create FrontEnd Relationship:
            //    //.AppendLine("WITH metadata, m")
            //    //.AppendLine("MATCH (d:FrontEnd { name: metadata.frontend.name })")
            //    //.AppendLine("MERGE (d)-[r:F_INVOKES_S]->(m)")
            //    // Create Database relationships:
            //    //.AppendLine("WITH metadata, m")
            //    //.AppendLine("UNWIND metadata.databases AS database")
            //    //.AppendLine("MATCH (g:Database { name: database.name})")
            //    //.AppendLine("MERGE (m)-[r3:S_INVOKES_D]->(g)")
            //    .ToString();

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
                 .AppendLine("MERGE (a)-[r:S_INVOKES_S]->(m)")
                 // Create ToService Relationships:
                 .AppendLine("WITH metadata, m")
                 .AppendLine("UNWIND metadata.toservices AS toservice")
                 .AppendLine("MERGE (c:Service { name: toservice.name, traceid: toservice.traceid })")
                 .AppendLine("SET c = toservice")
                 .AppendLine("MERGE (m)-[r:S_INVOKES_S]->(c)")
                .ToString();

            using (var session = driver.Session())
            {
                session.Run(cypher, new Dictionary<string, object>() { { "metadatas", ParameterSerializer.ToDictionary(metadatas) } });
            }
        }

        public async Task CreateRelationships_Database(IList<ServiceInformation> metadatas)
        {
            string cypher = new StringBuilder()
                .AppendLine("UNWIND $metadatas AS metadata")
                 // Find the Service:
                 .AppendLine("MATCH (m:Service { name: metadata.service.name })")
                // Create Database relationships:
                .AppendLine("UNWIND metadata.databases AS database")
                .AppendLine("MATCH (g:Database { name: database.name})")
                .AppendLine("MERGE (m)-[r:S_INVOKES_D]->(g)")
                .ToString();

            using (var session = driver.Session())
            {
                session.Run(cypher, new Dictionary<string, object>() { { "metadatas", ParameterSerializer.ToDictionary(metadatas) } });
            }
        }

        public async Task CreateRelationships_FrontEnd(IList<ServiceInformation> metadatas)
        {
            string cypher = new StringBuilder()
                .AppendLine("UNWIND $metadatas AS metadata")
                 // Find the Service:
                 .AppendLine("MATCH (m:Service { name: metadata.service.name })")
                // Create FrontEnd relationship:
                .AppendLine("MATCH (d:FrontEnd { name: metadata.frontend.name })")
                .AppendLine("MERGE (d)-[r:F_INVOKES_S]->(m)")
                .ToString();

            using (var session = driver.Session())
            {
                session.Run(cypher, new Dictionary<string, object>() { { "metadatas", ParameterSerializer.ToDictionary(metadatas) } });
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

        public List<ServiceCCInfo> GetCC()
        {
            List<ServiceCCInfo> serviceCCInfos = new List<ServiceCCInfo>();

            //create graph
            string cypher1 = new StringBuilder()
                .AppendLine("CALL gds.graph.create('cc_graph','Service', {S_INVOKES_S: {orientation: 'UNDIRECTED'}})")
                .ToString();

            //get cc of all nodes in main graph and chains - using linq we filter it
            string cypher2 = new StringBuilder()
                .AppendLine("CALL gds.localClusteringCoefficient.stream('cc_graph')")
                 .AppendLine("YIELD nodeId, localClusteringCoefficient")
                //.AppendLine("RETURN gds.util.asNode(nodeId).id as id, gds.util.asNode(nodeId).name AS name, localClusteringCoefficient")
                .AppendLine("RETURN gds.util.asNode(nodeId).traceid as traceid, gds.util.asNode(nodeId).name AS name, localClusteringCoefficient")
                .AppendLine("ORDER BY localClusteringCoefficient DESC")
                .ToString();

            //delete graph
            string cypher3 = new StringBuilder()
                .AppendLine("CALL gds.graph.drop('cc_graph') YIELD graphName")
                .ToString();

            using (var session = driver.Session())
            {
                session.Run(cypher1);
                var results = session.Run(cypher2);
                foreach (var record in results)
                {
                    ServiceCCInfo serviceCCInfo = new ServiceCCInfo();
                    serviceCCInfo.GUID = record["traceid"].As<string>();
                    serviceCCInfo.Name = record["name"].As<string>();
                    serviceCCInfo.CC = record["localClusteringCoefficient"].As<float>();

                    serviceCCInfos.Add(serviceCCInfo);
                }
                session.Run(cypher3);
            }
            return serviceCCInfos;
        }

        public void Dispose()
        {
            driver?.Dispose();
        }

        public class ServicesInfo
        {
            public List<ServiceDegreeInfo> serviceDegreeInfos { get; set; }
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

    }
}