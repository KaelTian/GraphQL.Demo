using GraphQL.Movies.Models;
using GraphQL.Types;
using LearnGraph.Movies.Schema;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Movies.Schema
{
    public class MovieInputType:InputObjectGraphType<MovieInput>
    {
        public MovieInputType()
        {
            Name = "MovieInput";
            Field(x => x.Name);
            Field(x => x.ReleaseDate);
            Field(x => x.Company);
            Field(x => x.ActorId);
            Field(x => x.MovieRating,type: typeof(MovieRatingEnum));
        }
    }
}
