using AutoMapper;
using GraphQL.Movies.Models;
using GraphQL.Types;
using LearnGraph.Movies.Models;
using LearnGraph.Movies.Schema;
using LearnGraph.Movies.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Movies.Schema
{
    public class MoviesMutation : ObjectGraphType
    {
        public MoviesMutation(IMovieService movieService, IMapper mapper)
        {
            Name = "Mutation";
            FieldAsync<MovieType>("createMovie",
                arguments:
                new QueryArguments(new QueryArgument<NonNullGraphType<MovieInputType>> { Name = "movie" }),
                resolve: async context =>
                 {
                     var movieInput = context.GetArgument<MovieInput>("movie");
                     var movie = mapper.Map<Movie>(movieInput);
                     var result = await movieService.CreateAsync(movie);
                     return result;
                 });
        }
    }
}
