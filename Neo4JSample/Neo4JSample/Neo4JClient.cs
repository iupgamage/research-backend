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
            string cypher = new StringBuilder()
                .AppendLine("UNWIND $services AS service")
                .AppendLine("MERGE (s:Service {name: service.name})")
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
            string cypher = new StringBuilder()
                .AppendLine("UNWIND $metadatas AS metadata")
                 // Find the Service:
                 .AppendLine("MATCH (m:Service { name: metadata.service.name })")
                 // Create FromService Relationships:
                 .AppendLine("UNWIND metadata.fromservices AS fromservice")
                 .AppendLine("MATCH (a:Service { name: fromservice.name })")
                 .AppendLine("MERGE (a)-[r:S_INVOKES_S]->(m)")
                 // Create ToService Relationships:
                 .AppendLine("WITH metadata, m")
                 .AppendLine("UNWIND metadata.toservices AS toservice")
                 .AppendLine("MATCH (c:Service { name: toservice.name })")
                 .AppendLine("MERGE (m)-[r:S_INVOKES_S]->(c)")
                // Create FrontEnd Relationship:
                //.AppendLine("WITH metadata, m")
                //.AppendLine("MATCH (d:FrontEnd { name: metadata.frontend.name })")
                //.AppendLine("MERGE (d)-[r:F_INVOKES_S]->(m)")
                // Create Database relationships:
                //.AppendLine("WITH metadata, m")
                //.AppendLine("UNWIND metadata.databases AS database")
                //.AppendLine("MATCH (g:Database { name: database.name})")
                //.AppendLine("MERGE (m)-[r3:S_INVOKES_D]->(g)")
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

        public void Dispose()
        {
            driver?.Dispose();
        }
    }
}