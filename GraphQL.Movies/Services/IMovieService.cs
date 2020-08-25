using LearnGraph.Movies.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearnGraph.Movies.Services
{
   public interface IMovieService
    {
        Task<Movie> GetByIdAsync(int id);
        Task<IEnumerable<Movie>> GetAsync();
        Task<Movie> CreateAsync(Movie movie);
    }
}
