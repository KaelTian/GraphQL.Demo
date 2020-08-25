using LearnGraph.Movies.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Movies.Models
{
  public  class MovieEvent
    {
        public MovieEvent()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public int MovieId { get; set; }

        public string Name { get; set; }

        public DateTime TimeStamp { get; set; }

        public MovieRating MovieRating { get; set; }
    }
}
