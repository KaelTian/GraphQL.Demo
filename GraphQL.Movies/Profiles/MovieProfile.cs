using GraphQL.Movies.Models;
using LearnGraph.Movies.Models;

namespace GraphQL.Movies.Profiles
{
  public  class MovieProfile:AutoMapper.Profile
    {
        public MovieProfile()
        {
            CreateMap<MovieInput, Movie>();
        }
    }
}
