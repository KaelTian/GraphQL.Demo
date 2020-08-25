using GraphQL.Types;
using LearnGraph.Movies.Models;
using LearnGraph.Movies.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnGraph.Movies.Schema
{
    public class MovieType : ObjectGraphType<Movie>
    {

        public MovieType(IActorService actorService)
        {
            Name = "Movie";
            Description = "Kael Movie Description";
            Field(a => a.Id);
            Field(a => a.Company).Description("Company");
            Field(a => a.Name);
            Field(a => a.ReleaseDate);
            Field(a => a.ActorId);
            Field<MovieRatingEnum>("movieRatings", resolve: context => context.Source.MovieRating);

            Field<ActorType>("actor", resolve: context => actorService.GetByIdAsync(context.Source.ActorId));
            Field<StringGraphType>("customString", resolve: context => "Kael Custom String");
        }
    }
}
