using GraphQL.Movies.Models;
using GraphQL.Types;
using LearnGraph.Movies.Schema;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Movies.Schema
{
    public class MovieEventType : ObjectGraphType<MovieEvent>
    {
        public MovieEventType()
        {
            Name = "MovieEvent";

            Field(a => a.Id);
            Field(a => a.MovieId);
            Field(a => a.Name);
            Field(a => a.TimeStamp);
            Field(a => a.MovieRating, type: typeof(MovieRatingEnum));
        }
    }
}
