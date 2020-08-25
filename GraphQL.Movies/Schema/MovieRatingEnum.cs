using GraphQL.Instrumentation;
using GraphQL.Types;
using LearnGraph.Movies.Models;
using System;

namespace LearnGraph.Movies.Schema
{
    public class MovieRatingEnum : EnumerationGraphType<MovieRating>
    {
        public MovieRatingEnum()
        {
            Name = "MovieRatings";
            Description = "Enum Movie Rating";
            //AddValue(MovieRating.Unrated.ToString(), MovieRating.Unrated.ToString(), MovieRating.Unrated);
            //AddValue(MovieRating.G.ToString(), MovieRating.G.ToString(), MovieRating.G);
            //AddValue(MovieRating.PG.ToString(), MovieRating.PG.ToString(), MovieRating.PG);
            //AddValue(MovieRating.PG13.ToString(), MovieRating.PG13.ToString(), MovieRating.PG13);
            //AddValue(MovieRating.R.ToString(), MovieRating.R.ToString(), MovieRating.R);
            //AddValue(MovieRating.NC17.ToString(), MovieRating.NC17.ToString(), MovieRating.NC17);
            AddGraphQLEnumValue(typeof(MovieRating));

            void AddGraphQLEnumValue(System.Type type)
            {
                foreach (var enumValue in Enum.GetValues(type))
                {
                    var enumName = Enum.GetName(type, enumValue);
                    AddValue(enumName, enumName, (int)enumValue);
                }
            }
        }
    }
}
