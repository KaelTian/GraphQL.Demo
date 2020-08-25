using LearnGraph.Movies.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Movies.Models
{
   public class MovieInput
    {

        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public String Company { get; set; }

        public int ActorId { get; set; }

        public MovieRating MovieRating { get; set; }
    }
}
