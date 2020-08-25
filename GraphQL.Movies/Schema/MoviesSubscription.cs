using GraphQL.Movies.Models;
using GraphQL.Movies.Services;
using GraphQL.Resolvers;
using GraphQL.Subscription;
using GraphQL.Types;
using GraphQL.Utilities.Federation;
using LearnGraph.Movies.Models;
using LearnGraph.Movies.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Movies.Schema
{
   public class MoviesSubscription:ObjectGraphType
    {
        private readonly IMovieEventService _movieEventService;

        public MoviesSubscription(IMovieEventService movieEventService)
        {
            Name = "Subscription";
            this._movieEventService = movieEventService;

            base.AddField(new EventStreamFieldType
            {
                Name = "movieEvent",
                Arguments=new QueryArguments(new QueryArgument<ListGraphType<MovieRatingEnum>>
                {
                    Name="movieRating"
                }),
                Type = typeof(MovieEventType),
                Resolver = new FuncFieldResolver<MovieEvent>((context)=>(context.Source as MovieEvent)),
                Subscriber = new EventStreamResolver<MovieEvent>(Subscribe)
            });
        }



        private IObservable<MovieEvent> Subscribe(IResolveEventStreamContext context)
        {
            var ratingList = context.GetArgument<IList<MovieRating>>("movieRating", new List<MovieRating>());
            if (ratingList.Any())
            {
                MovieRating ratings = 0;
                foreach(var rating in ratingList)
                {
                    ratings = rating | rating;
                }

                return _movieEventService.EventStream().Where(a => (a.MovieRating & ratings) == a.MovieRating);
            }
            else
            {
                return _movieEventService.EventStream();
            }
        }

    }
}
