using GraphQL.Movies.Models;
using GraphQL.Movies.Services;
using LearnGraph.Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnGraph.Movies.Services
{
    public class MovieService : IMovieService
    {

        private IList<Movie> __movies;
        private IList<Movie> _movies
        {
            get
            {
                if (__movies == null)
                {
                    #region Movies
                    __movies = new List<Movie> {
            new Movie
            {
                Id=1,
                Name="Forrest Gump",
                ActorId=1,
                Company="Paramount Pictures",
                MovieRating=MovieRating.PG13,
                ReleaseDate=new DateTime(1994,7,6)
            },
            new Movie
            {
                Id=2,
                Name="Se7en",
                ActorId=2,
                Company="New Line Cinema",
                MovieRating=MovieRating.R,
                ReleaseDate=new DateTime(1995,9,22)
            },
            new Movie
            {
                Id=3,
                Name="Top Gun",
                ActorId=3,
                Company="Paramount Pictures",
                MovieRating=MovieRating.PG,
                ReleaseDate=new DateTime(1986,5,16)
            },
            new Movie
            {
                Id=4,
                Name="La La Land",
                ActorId=4,
                Company="Submit Entertainment",
                MovieRating=MovieRating.PG13,
                ReleaseDate=new DateTime(2016,12,25)
            },
            new Movie
            {
                Id=5,
                Name="The Notebook",
                ActorId=5,
                Company="New Line Cinema",
                MovieRating=MovieRating.PG13,
                ReleaseDate=new DateTime(2004,6,25)
            },
            };
                    #endregion
                }
                return __movies;
            }
        }
        private readonly IMovieEventService _movieEventService;

        public MovieService(IMovieEventService movieEventService)
        {
            this._movieEventService = movieEventService;
        }

        public MovieService()
        {
            #region Movies
            //_movies = new List<Movie> {
            //new Movie
            //{
            //    Id=1,
            //    Name="Forrest Gump",
            //    ActorId=1,
            //    Company="Paramount Pictures",
            //    MovieRating=MovieRating.PG13,
            //    ReleaseDate=new DateTime(1994,7,6)
            //},
            //new Movie
            //{
            //    Id=2,
            //    Name="Se7en",
            //    ActorId=2,
            //    Company="New Line Cinema",
            //    MovieRating=MovieRating.R,
            //    ReleaseDate=new DateTime(1995,9,22)
            //},
            //new Movie
            //{
            //    Id=3,
            //    Name="Top Gun",
            //    ActorId=3,
            //    Company="Paramount Pictures",
            //    MovieRating=MovieRating.PG,
            //    ReleaseDate=new DateTime(1986,5,16)
            //},
            //new Movie
            //{
            //    Id=4,
            //    Name="La La Land",
            //    ActorId=4,
            //    Company="Submit Entertainment",
            //    MovieRating=MovieRating.PG13,
            //    ReleaseDate=new DateTime(2016,12,25)
            //},
            //new Movie
            //{
            //    Id=5,
            //    Name="The Notebook",
            //    ActorId=5,
            //    Company="New Line Cinema",
            //    MovieRating=MovieRating.PG13,
            //    ReleaseDate=new DateTime(2004,6,25)
            //},
            //};
            #endregion
        }

        public Task<Movie> CreateAsync(Movie movie)
        {
            if (movie == null)
            {
                throw new ArgumentNullException("Create movie is null.");
            }
            movie.Id = _movies.Max(a => a.Id) + 1;
            _movies.Add(movie);
            var movieEvent = new MovieEvent
            {
                Name = $"Add Movie",
                MovieId = movie.Id,
                TimeStamp = DateTime.Now,
                MovieRating = movie.MovieRating
            };
            _movieEventService.AddEvent(movieEvent);
            return Task.FromResult(movie); ;
        }

        public Task<IEnumerable<Movie>> GetAsync()
        {
            return Task.FromResult(_movies.AsEnumerable());
        }

        public Task<Movie> GetByIdAsync(int id)
        {
            var movie = _movies.SingleOrDefault(x => x.Id == id);
            if (movie == null)
            {
                throw new ArgumentNullException($"Movie ID {id} 不正确");
            }
            return Task.FromResult(movie);
        }
    }
}
