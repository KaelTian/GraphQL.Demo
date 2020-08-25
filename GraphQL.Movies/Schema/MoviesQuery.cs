using GraphQL.Types;
using LearnGraph.Movies.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnGraph.Movies.Schema
{
    public class MoviesQuery : ObjectGraphType
    {
        public MoviesQuery(IMovieService movieService)
        {
            Name = "Query";
            Field<ListGraphType<MovieType>>("movies", resolve: context => movieService.GetAsync());

        }
    }
}
