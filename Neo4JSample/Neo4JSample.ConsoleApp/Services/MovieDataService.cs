// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Neo4JSample.Model;
using System.Collections.Generic;

namespace Neo4JSample.ConsoleApp.Services
{
    public interface IMovieDataService
    {
        //IList<Genre> Genres { get; }

        //IList<Person> Persons { get; }

        //IList<Movie> Movies { get; }

        //IList<MovieInformation> Metadatas { get; }

        IList<Service> Services { get; }

        IList<Service> Services_sc1 { get; }

        IList<FrontEnd> FrontEnds { get; }

        IList<Database> Databases { get; }

        IList<ServiceInformation> Metadatas_service { get; }

        IList<ServiceInformation> Metadatas_service_sc1 { get; }

        IList<ServiceInformation> Metadatas_frontend { get; }

        IList<ServiceInformation> Metadatas_database { get; }
    }

    public class MovieDataService : IMovieDataService
    {
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

        private static Service Service1 = new Service
        {
            Id = "1",
            Name = "Service1",
            ServiceChain = "null"
        };

        private static Service Service1_sc1 = new Service
        {
            Id = "1",
            Name = "Service1",
            ServiceChain = "1,3,5"
        };

        private static Service Service1_sc2 = new Service
        {
            Id = "1",
            Name = "Service1",
            ServiceChain = "1,2,3,4,5"
        };

        private static Service Service2 = new Service
        {
            Id = "2",
            Name = "Service2",
            ServiceChain = "null"
        };

        private static Service Service3 = new Service
        {
            Id = "3",
            Name = "Service3",
            ServiceChain = "null"
        };

        private static Service Service3_sc1 = new Service
        {
            Id = "3",
            Name = "Service3",
            ServiceChain = "1,3,5"
        };

        private static Service Service4 = new Service
        {
            Id = "4",
            Name = "Service4",
            ServiceChain = "null"
        };

        private static Service Service5 = new Service
        {
            Id = "5",
            Name = "Service5",
            ServiceChain = "null"
        };

        private static Service Service5_sc1 = new Service
        {
            Id = "5",
            Name = "Service5",
            ServiceChain = "1,3,5"
        };

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
        private static ServiceInformation Metadata1 = new ServiceInformation
        {
            //FromServices = new[] {  },
            FrontEnd = FrontEnd1,
            ToServices = new[] { Service2, Service3, Service4 },
            Service = Service1
        };

        //S1_sc1
        private static ServiceInformation Metadata1_sc1 = new ServiceInformation
        {
            //FromServices = new[] {  },
            //FrontEnd = FrontEnd1,
            ToServices = new[] { Service3_sc1 },
            Service = Service1_sc1
        };

        //S2
        private static ServiceInformation Metadata2 = new ServiceInformation
        {
            FromServices = new[] { Service1, Service4 },
            //FrontEnd = "",
            ToServices = new[] { Service5 },
            Service = Service2
        };

        //S3
        private static ServiceInformation Metadata3 = new ServiceInformation
        {
            FromServices = new[] { Service1, Service4 },
            //FrontEnd = "",
            ToServices = new[] { Service5 },
            Service = Service3
        };

        //S3_sc1
        private static ServiceInformation Metadata3_sc1 = new ServiceInformation
        {
            FromServices = new[] { Service1_sc1 },
            //FrontEnd = "",
            ToServices = new[] { Service5_sc1 },
            Service = Service3_sc1
        };

        //S4
        private static ServiceInformation Metadata4 = new ServiceInformation
        {
            FromServices = new[] { Service1 },
            //FrontEnd = "",
            ToServices = new[] { Service2, Service3, Service5 },
            Service = Service4
        };

        //S5
        private static ServiceInformation Metadata5 = new ServiceInformation
        {
            FromServices = new[] { Service2, Service3, Service4 },
            //FrontEnd = "",
            //ToServices = new[] { Service5 },
            Databases = new[] { Database1 },
            Service = Service5
        };

        //S5_sc1
        private static ServiceInformation Metadata5_sc1 = new ServiceInformation
        {
            FromServices = new[] { Service3_sc1 },
            //FrontEnd = "",
            //ToServices = new[] { Service5 },
            //Databases = new[] { Database1 },
            Service = Service5_sc1
        };

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

        public IList<Service> Services
        {
            get
            {
                return new[] { Service1, Service2, Service3, Service4, Service5 };
            }
        }

        public IList<Service> Services_sc1
        {
            get
            {
                return new[] { Service1_sc1, Service3_sc1, Service5_sc1 };
            }
        }

        public IList<FrontEnd> FrontEnds
        {
            get
            {
                return new[] { FrontEnd1 };
            }
        }

        public IList<Database> Databases
        {
            get
            {
                return new[] { Database1 };
            }
        }

        public IList<ServiceInformation> Metadatas_service
        {
            get
            {
                return new[] { Metadata1, Metadata2, Metadata3, Metadata4, Metadata5 };
            }
        }

        public IList<ServiceInformation> Metadatas_service_sc1
        {
            get
            {
                return new[] { Metadata1_sc1, Metadata3_sc1, Metadata5_sc1 };
            }
        }

        public IList<ServiceInformation> Metadatas_database
        {
            get
            {
                return new[] { Metadata5 };
            }
        }

        public IList<ServiceInformation> Metadatas_frontend
        {
            get
            {
                return new[] { Metadata1 };
            }
        }
    }
}
