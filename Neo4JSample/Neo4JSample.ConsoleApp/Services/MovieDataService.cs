// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Neo4JSample.Enums;
using Neo4JSample.Model;
using Neo4JSample.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Neo4JSample.ConsoleApp.Services
{
    public interface IMovieDataService
    {
        //IList<Genre> Genres { get; }

        //IList<Person> Persons { get; }

        //IList<Movie> Movies { get; }

        //IList<MovieInformation> Metadatas { get; }

        //IList<Service> Services { get; }

        //IList<Service> Services_sc1 { get; }

        //IList<FrontEnd> FrontEnds { get; }

        //IList<Database> Databases { get; }

        //IList<ServiceInformation> Metadatas_service { get; }

        //IList<ServiceInformation> Metadatas_service_sc1 { get; }

        //IList<ServiceInformation> Metadatas_frontend { get; }

        //IList<ServiceInformation> Metadatas_database { get; }
    }

    public class MovieDataService : IMovieDataService
    {
        #region Hard coded values

        //private static Movie Movie0 = new Movie
        //{
        //    Id = "1",
        //    Title = "Kill Bill"
        //};

        //private static Movie Movie1 = new Movie
        //{
        //    Id = "2",
        //    Title = "Running Man"
        //};

        //private static Service Service1 = new Service
        //{
        //    Id = "1",
        //    Name = "Service1",
        //    IsInChain = "f"
        //};

        //private static Service Service1_sc1 = new Service
        //{
        //    Id = "1",
        //    Name = "Service1",
        //    IsInChain = "t"
        //};

        //private static Service Service1_sc2 = new Service
        //{
        //    Id = "1",
        //    Name = "Service1",
        //    IsInChain = "t"
        //};

        //private static Service Service2 = new Service
        //{
        //    Id = "2",
        //    Name = "Service2",
        //    IsInChain = "f"
        //};

        //private static Service Service3 = new Service
        //{
        //    Id = "3",
        //    Name = "Service3",
        //    IsInChain = "f"
        //};

        //private static Service Service3_sc1 = new Service
        //{
        //    Id = "3",
        //    Name = "Service3",
        //    IsInChain = "t"
        //};

        //private static Service Service4 = new Service
        //{
        //    Id = "4",
        //    Name = "Service4",
        //    IsInChain = "f"
        //};

        //private static Service Service5 = new Service
        //{
        //    Id = "5",
        //    Name = "Service5",
        //    IsInChain = "f"
        //};

        //private static Service Service5_sc1 = new Service
        //{
        //    Id = "5",
        //    Name = "Service5",
        //    IsInChain = "t"
        //};

        //private static Person Actor0 = new Person
        //{
        //    Id = "1",
        //    Name = "Uma Thurman"
        //};

        //private static Person Actor1 = new Person
        //{
        //    Id = "2",
        //    Name = "Arnold Schwarzenegger"
        //};

        //private static Person Director0 = new Person
        //{
        //    Id = "3",
        //    Name = "Quentin Tarantino"
        //};

        //private static Person Director1 = new Person
        //{
        //    Id = "3",
        //    Name = "Sergio Leone"
        //};

        private static FrontEnd FrontEnd1 = new FrontEnd
        {
            Id = "1",
            Name = "FrontEnd1"
        };

        //private static Genre Genre0 = new Genre
        //{
        //    Name = "Romantic"
        //};

        //private static Genre Genre1 = new Genre
        //{
        //    Name = "Action"
        //};

        private static Database Database1 = new Database
        {
            Id = "1",
            Name = "Database1"
        };

        //private static MovieInformation Metadata0 = new MovieInformation
        //{
        //    Cast = new[] { Actor0 },
        //    Director = Director0,
        //    Genres = new[] { Genre0, Genre1 },
        //    Movie = Movie0
        //};

        //private static MovieInformation Metadata1 = new MovieInformation
        //{
        //    Cast = new[] { Actor1 },
        //    Director = Director1,
        //    Genres = new[] { Genre1 },
        //    Movie = Movie1
        //};

        //S1
        //private static ServiceInformation Metadata1 = new ServiceInformation
        //{
        //    //FromServices = new[] {  },
        //    FrontEnd = FrontEnd1,
        //    ToServices = new[] { Service2, Service3, Service4 },
        //    Service = Service1
        //};

        ////S1_sc1
        //private static ServiceInformation Metadata1_sc1 = new ServiceInformation
        //{
        //    //FromServices = new[] {  },
        //    //FrontEnd = FrontEnd1,
        //    ToServices = new[] { Service3_sc1 },
        //    Service = Service1_sc1
        //};

        ////S2
        //private static ServiceInformation Metadata2 = new ServiceInformation
        //{
        //    FromServices = new[] { Service1, Service4 },
        //    //FrontEnd = "",
        //    ToServices = new[] { Service5 },
        //    Service = Service2
        //};

        ////S3
        //private static ServiceInformation Metadata3 = new ServiceInformation
        //{
        //    FromServices = new[] { Service1, Service4 },
        //    //FrontEnd = "",
        //    ToServices = new[] { Service5 },
        //    Service = Service3
        //};

        ////S3_sc1
        //private static ServiceInformation Metadata3_sc1 = new ServiceInformation
        //{
        //    FromServices = new[] { Service1_sc1 },
        //    //FrontEnd = "",
        //    ToServices = new[] { Service5_sc1 },
        //    Service = Service3_sc1
        //};

        ////S4
        //private static ServiceInformation Metadata4 = new ServiceInformation
        //{
        //    FromServices = new[] { Service1 },
        //    //FrontEnd = "",
        //    ToServices = new[] { Service2, Service3, Service5 },
        //    Service = Service4
        //};

        ////S5
        //private static ServiceInformation Metadata5 = new ServiceInformation
        //{
        //    FromServices = new[] { Service2, Service3, Service4 },
        //    //FrontEnd = "",
        //    //ToServices = new[] { Service5 },
        //    Databases = new[] { Database1 },
        //    Service = Service5
        //};

        ////S5_sc1
        //private static ServiceInformation Metadata5_sc1 = new ServiceInformation
        //{
        //    FromServices = new[] { Service3_sc1 },
        //    //FrontEnd = "",
        //    //ToServices = new[] { Service5 },
        //    //Databases = new[] { Database1 },
        //    Service = Service5_sc1
        //};

        //public IList<Genre> Genres
        //{
        //    get
        //    {
        //        return new[] { Genre0, Genre1 };
        //    }
        //}

        //public IList<Person> Persons
        //{
        //    get
        //    {
        //        return new[] { Actor0, Actor1, Director0, Director1 };
        //    }
        //}

        //public IList<Movie> Movies
        //{
        //    get
        //    {
        //        return new[] { Movie0, Movie1 };
        //    }
        //}

        //public IList<MovieInformation> Metadatas
        //{
        //    get
        //    {
        //        return new[] { Metadata0, Metadata1 };
        //    }
        //}

        //public IList<Service> Services
        //{
        //    get
        //    {
        //        return new[] { Service1, Service2, Service3, Service4, Service5 };
        //    }
        //}

        //public IList<Service> Services_sc1
        //{
        //    get
        //    {
        //        return new[] { Service1_sc1, Service3_sc1, Service5_sc1 };
        //    }
        //}

        //public IList<FrontEnd> FrontEnds
        //{
        //    get
        //    {
        //        return new[] { FrontEnd1 };
        //    }
        //}

        //public IList<Database> Databases
        //{
        //    get
        //    {
        //        return new[] { Database1 };
        //    }
        //}

        //public IList<ServiceInformation> Metadatas_service
        //{
        //    get
        //    {
        //        return new[] { Metadata1, Metadata2, Metadata3, Metadata4, Metadata5 };
        //    }
        //}

        //public IList<ServiceInformation> Metadatas_service_sc1
        //{
        //    get
        //    {
        //        return new[] { Metadata1_sc1, Metadata3_sc1, Metadata5_sc1 };
        //    }
        //}

        //public IList<ServiceInformation> Metadatas_database
        //{
        //    get
        //    {
        //        return new[] { Metadata5 };
        //    }
        //}

        //public IList<ServiceInformation> Metadatas_frontend
        //{
        //    get
        //    {
        //        return new[] { Metadata1 };
        //    }
        //}

        #endregion

        public List<Trace> trace_data = new List<Trace>();
        Trace newTrace = new Trace();

        public List<Trace> Create(List<List<SpanDto>> traces)
        {
            foreach (var trace in traces)
            {
                var traceInfo = CreateRoot(trace);
                trace_data.Add(traceInfo);
            }
            return trace_data;
        }

        public Trace CreateRoot(List<SpanDto> trace)
        {
            var traceInfo = new Trace();
            var rootSpan = trace.Where(x => x.parentId == null).FirstOrDefault();
            var childrenOfRootSpan = trace.Where(x => x.parentId == rootSpan.id && x.kind == Kind.SERVER.ToString()).ToList();

            CreateInfo(rootSpan, null, childrenOfRootSpan, trace);

            return newTrace;
        }

        public void CreateInfo(SpanDto span, SpanDto parentSpan, List<SpanDto> childSpans, List<SpanDto> trace)
        {
            var serviceInfo = new ServiceInformation();
            var serviceInfo_ch = new ServiceInformation(); 

            if (span != null)
            {
                var service = new Service
                {
                    Name = span.localEndpoint.ServiceName,
                    TraceId = "null",
                    EndPoint = "null"
                };
                serviceInfo.Service = service;

                var service_ch = new Service
                {
                    Name = span.localEndpoint.ServiceName,
                    TraceId = span.traceId,
                    EndPoint = span.Tags.httpPath
                };
                serviceInfo_ch.Service = service_ch;
            }

            if (parentSpan != null)
            {
                var parentService = new Service
                {
                    Name = parentSpan.localEndpoint.ServiceName,
                    TraceId = "null",
                    EndPoint = "null"
                };
                serviceInfo.FromServices.Add(parentService);

                var parentService_ch = new Service
                {
                    Name = parentSpan.localEndpoint.ServiceName,
                    TraceId = parentSpan.traceId,
                    EndPoint = parentSpan.Tags.httpPath
                };
                serviceInfo_ch.FromServices.Add(parentService_ch);
            }

            if (childSpans != null && childSpans.Count() > 0)
            {
                var childServices = childSpans.Select(x => new Service
                {
                    Name = x.localEndpoint.ServiceName,
                    TraceId = "null",
                    EndPoint = "null"
                }).ToList();
                serviceInfo.ToServices = childServices;

                var childServices_ch = childSpans.Select(x => new Service
                {
                    Name = x.localEndpoint.ServiceName,
                    TraceId = x.traceId,
                    EndPoint = x.Tags.httpPath
                }).ToList();
                serviceInfo_ch.ToServices = childServices_ch;
            }

            newTrace.serviceinformation.Add(serviceInfo);
            newTrace.serviceinformation.Add(serviceInfo_ch);

            foreach (var childSpan in childSpans)
            {
                var parentSpan2= trace.Where(x => x.id == childSpan.parentId && x.kind == Kind.SERVER.ToString()).FirstOrDefault();
                var childSpans2= trace.Where(x => x.parentId == childSpan.id && x.kind == Kind.SERVER.ToString()).ToList();

                CreateInfo(childSpan, parentSpan2, childSpans2, trace);
            }
        }


        //public List<Trace> CreateServiceList(List<List<SpanDto>> traces)
        //{
        //    try
        //    {
        //        foreach (var trace in traces)
        //        {
        //            string parentId = string.Empty;
        //            Trace tracedata = new Trace(); //insert all the services for the trace
        //            ServiceInformation serviceInformation = null;

        //            var rootSpan = trace.Where(x => x.parentId == null).FirstOrDefault();
        //            var childrenOfRootSpan = trace.Where(x => x.parentId == rootSpan.id && x.kind == Kind.SERVER.ToString());

        //            if (rootSpan != null)
        //            {
        //                //set the parent span id to start the loop
        //                parentId = rootSpan.id;

        //                #region root service and relationships - common graph
        //                //create the root service object - common graph
        //                var rootservice = new Service
        //                {
        //                    Name = rootSpan.localEndpoint.ServiceName,
        //                    TraceId = "null",
        //                    EndPoint = "null"
        //                };
        //                serviceInformation = new ServiceInformation
        //                {
        //                    Service = rootservice
        //                };

        //                if (childrenOfRootSpan.Count() > 0)
        //                {
        //                    foreach (var child in childrenOfRootSpan)
        //                    {
        //                        var childservice = new Service
        //                        {
        //                            Name = child.localEndpoint.ServiceName,
        //                            TraceId = "null",
        //                            EndPoint = "null"
        //                        };
        //                        serviceInformation.ToServices.Add(childservice);
        //                    }
        //                }

        //                //add the root service and relationships - common graph
        //                tracedata.serviceinformation.Add(serviceInformation);
        //                #endregion

        //                #region root service and relationships - chain

        //                //create the root service object - chain
        //                var rootserviceForChain = new Service
        //                {
        //                    Name = rootSpan.localEndpoint.ServiceName,
        //                    TraceId = rootSpan.traceId,
        //                    EndPoint = rootSpan.Tags.httpPath
        //                };
        //                serviceInformation = new ServiceInformation
        //                {
        //                    Service = rootserviceForChain
        //                };

        //                if (childrenOfRootSpan.Count() > 0)
        //                {
        //                    foreach (var child in childrenOfRootSpan)
        //                    {
        //                        var childservice = new Service
        //                        {
        //                            Name = child.localEndpoint.ServiceName,
        //                            TraceId = child.traceId,
        //                            EndPoint = child.Tags.httpPath
        //                        };
        //                        serviceInformation.ToServices.Add(childservice);
        //                    }
        //                }

        //                //add the root service and relationships - chain
        //                tracedata.serviceinformation.Add(serviceInformation);

        //                #endregion

        //                //no of child services invloved in the chain
        //                var childServiceCount = trace.Where(x => x.kind == Kind.SERVER.ToString()).Count() - 1;

        //                if (childServiceCount > 0)
        //                {
        //                    for (int i = 1; i <= childServiceCount; i++)
        //                    {
        //                        var childSpans = trace.Where(x => x.parentId == parentId && x.kind == Kind.SERVER.ToString());

        //                        if (childSpans != null && childSpans.Count()>0)
        //                        {
        //                            foreach (var childSpan in childSpans)
        //                            {
        //                                var childrenOfchildSpan = trace.Where(x => x.parentId == childSpan.id && x.kind == Kind.SERVER.ToString());
        //                                var parentsOfchildSpan = trace.Where(x => x.id == childSpan.parentId && x.kind == Kind.SERVER.ToString());

        //                                #region child service and relationships - common graph
        //                                //create the child service object - common graph
        //                                var childservice = new Service
        //                                {
        //                                    Name = childSpan.localEndpoint.ServiceName,
        //                                    TraceId = "null",
        //                                    EndPoint = "null"
        //                                };
        //                                serviceInformation = new ServiceInformation
        //                                {
        //                                    Service = childservice
        //                                };

        //                                //to services
        //                                if (childrenOfchildSpan.Count() > 0)
        //                                {
        //                                    foreach (var child in childrenOfchildSpan)
        //                                    {
        //                                        var childservice_2 = new Service
        //                                        {
        //                                            Name = child.localEndpoint.ServiceName,
        //                                            TraceId = "null",
        //                                            EndPoint = "null"
        //                                        };
        //                                        serviceInformation.ToServices.Add(childservice_2);
        //                                    }
        //                                }

        //                                //from services
        //                                if (parentsOfchildSpan.Count() > 0)
        //                                {
        //                                    foreach (var parent in parentsOfchildSpan)
        //                                    {
        //                                        var parentservice = new Service
        //                                        {
        //                                            Name = parent.localEndpoint.ServiceName,
        //                                            TraceId = "null",
        //                                            EndPoint = "null"
        //                                        };
        //                                        serviceInformation.FromServices.Add(parentservice);
        //                                    }
        //                                }

        //                                //add the child service and relationships - common graph
        //                                tracedata.serviceinformation.Add(serviceInformation);

        //                                #endregion

        //                                #region child service and relationships - chain

        //                                //create the root service object - chain
        //                                var childserviceForChain = new Service
        //                                {
        //                                    Name = childSpan.localEndpoint.ServiceName,
        //                                    TraceId = childSpan.traceId,
        //                                    EndPoint = childSpan.Tags.httpPath
        //                                };
        //                                serviceInformation = new ServiceInformation
        //                                {
        //                                    Service = childserviceForChain
        //                                };

        //                                //to services
        //                                if (childrenOfchildSpan.Count() > 0)
        //                                {
        //                                    foreach (var child in childrenOfchildSpan)
        //                                    {
        //                                        var childservice_2 = new Service
        //                                        {
        //                                            Name = child.localEndpoint.ServiceName,
        //                                            TraceId = child.traceId,
        //                                            EndPoint = child.Tags.httpPath
        //                                        };
        //                                        serviceInformation.ToServices.Add(childservice_2);
        //                                    }
        //                                }

        //                                //from services
        //                                if (parentsOfchildSpan.Count() > 0)
        //                                {
        //                                    foreach (var parent in parentsOfchildSpan)
        //                                    {
        //                                        var parentservice = new Service
        //                                        {
        //                                            Name = parent.localEndpoint.ServiceName,
        //                                            TraceId = parent.traceId,
        //                                            EndPoint = parent.Tags.httpPath
        //                                        };
        //                                        serviceInformation.FromServices.Add(parentservice);
        //                                    }
        //                                }

        //                                //add the child service and relationships - chain
        //                                tracedata.serviceinformation.Add(serviceInformation);

        //                                #endregion

        //                            }

        //                            //set the new parent span id
        //                            parentId = childSpan.id;
        //                        }                            
        //                    }
        //                }

        //                //add trace data to the global variable
        //                trace_data.Add(tracedata);

        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //    return trace_data;

        //}
             
    }
}
