using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Neo4JSample.ConsoleApp.Services;
using Neo4JSample.Settings;
using static Neo4JSample.Neo4JClient;

namespace Neo4JSample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        [HttpGet("degrees")]
        public ActionResult GetDegree()
        {
            var settings = ConnectionSettings.CreateBasicAuth("bolt://localhost:7687/db/actors", "neo4j", "test_pwd");

            using (var client = new Neo4JClient(settings))
            {
                return Ok(client.GetDegrees());
            }
        }

        [HttpGet("cc")]
        public ActionResult GetCC()
        {
            var settings = ConnectionSettings.CreateBasicAuth("bolt://localhost:7687/db/actors", "neo4j", "test_pwd");

            using (var client = new Neo4JClient(settings))
            {
                var result = client.GetCC();
                var result2 = result.GroupBy(x => x.Id).Select(y => new
                {
                    id = y.First().Id,
                    name = y.First().Name,
                    cc = y.OrderByDescending(c => c.CC).First().CC
                });

                return Ok(result2);
            }
        }

        // POST api/values
        [HttpPost]
        public async Task Post(/*[FromBody] string value*/)
        {
            var service = new MovieDataService();

            var settings = ConnectionSettings.CreateBasicAuth("bolt://localhost:7687/db/actors", "neo4j", "test_pwd");

            using (var client = new Neo4JClient(settings))
            {

                // Create Indices for faster Lookups:
                //await client.CreateIndices();

                //// Create Base Data:
                //await client.CreateMovies(service.Movies);
                //await client.CreatePersons(service.Persons);
                //await client.CreateGenres(service.Genres);

                //// Create Relationships:
                //await client.CreateRelationships(service.Metadatas);

                await client.CreateServices(service.Services);
                await client.CreateFrontEnds(service.FrontEnds);
                await client.CreateDatabases(service.Databases);
                await client.CreateRelationships_Service(service.Metadatas_service);
                await client.CreateRelationships_Database(service.Metadatas_database);
                await client.CreateRelationships_FrontEnd(service.Metadatas_frontend);

                await client.CreateServices(service.Services_sc1);
                await client.CreateRelationships_Service(service.Metadatas_service_sc1);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
