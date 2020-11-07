using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Neo4JSample.ConsoleApp.Services;
using Neo4JSample.Model.DTOs;
using Neo4JSample.Settings;
using Newtonsoft.Json;

namespace Neo4JSample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraceFeedController : ControllerBase
    {
        private readonly IHttpClientFactory _factory;
        private readonly IConfiguration _configuration;
        //string url = "bolt://localhost:7687/db/actors";
        //string username = "neo4j";
        //string password = "test_pwd";

        string url = "";
        string username = "";
        string password = "";

        public TraceFeedController(IHttpClientFactory factory, IConfiguration configuration)
        {
            _factory = factory;
            _configuration = configuration;
            url = _configuration["Neo4jDetails:Server"];
            username = _configuration["Neo4jDetails:Username"];
            password= _configuration["Neo4jDetails:Password"];
        }

        [HttpGet("gettraces")]
        public async Task<ActionResult> GetTraces()
        {
            using (var client = _factory.CreateClient())
            {
                var requestMsg = new HttpRequestMessage(HttpMethod.Get, "http://localhost:9411/api/v2/traces");

                var responseMsg = await client.SendAsync(requestMsg);

                var data = await responseMsg.Content.ReadAsStringAsync();

                var traces = JsonConvert.DeserializeObject<List<List<SpanDto>>>(data);

                //write to json
                System.IO.File.WriteAllText("traces.json", JsonConvert.SerializeObject(traces));

                return Ok(traces);

            }
        }

        [HttpPost("inserttraces")]
        public async Task<ActionResult> InsertTraces()
        {
            var dataService = new MovieDataService();

            var settings = ConnectionSettings.CreateBasicAuth(url, username, password);


            using (var client = _factory.CreateClient())
            {
                //read from json
                var tracesfromFile = JsonConvert.DeserializeObject<List<List<SpanDto>>>(System.IO.File.ReadAllText("traces.json"));

                var traces_model = dataService.Create(tracesfromFile);

                using (var client_2 = new Neo4JClient(settings))
                {
                    //delete the existing graph first
                    await client_2.DeleteGraph();

                    foreach (var trace in traces_model)
                    {
                        //await client_2.CreateServices(trace.services);
                        //await client.CreateFrontEnds(service.FrontEnds);
                        //await client.CreateDatabases(service.Databases);


                        //if (traces_model[0] == trace)
                        //    System.IO.File.WriteAllText("traces_1.json", JsonConvert.SerializeObject(trace.serviceinformation));
                        //if (traces_model[1] == trace)
                        //    System.IO.File.WriteAllText("traces_2.json", JsonConvert.SerializeObject(trace.serviceinformation));
                        //if (traces_model[2] == trace)
                        //    System.IO.File.WriteAllText("traces_3.json", JsonConvert.SerializeObject(trace.serviceinformation));
                        //if (traces_model[3] == trace)
                        //    System.IO.File.WriteAllText("traces_4.json", JsonConvert.SerializeObject(trace.serviceinformation));
                        await client_2.CreateRelationships_Service(trace.serviceinformation);


                        //await client.CreateRelationships_Database(service.Metadatas_database);
                        //await client.CreateRelationships_FrontEnd(service.Metadatas_frontend);

                        //await client.CreateServices(service.Services_sc1);
                        //await client.CreateRelationships_Service(service.Metadatas_service_sc1);
                    }
                }

                return Ok(traces_model);

            }

        }
    }
}