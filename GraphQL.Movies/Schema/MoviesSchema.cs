using GraphQL.Movies.Schema;
using GraphQL.Utilities;
using System;

namespace LearnGraph.Movies.Schema
{
    public class MoviesSchema : GraphQL.Types.Schema
    {
        public MoviesSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<MoviesQuery>();
            Mutation = serviceProvider.GetRequiredService<MoviesMutation>();
            Subscription= serviceProvider.GetRequiredService<MoviesSubscription>();
        }
    }
}
