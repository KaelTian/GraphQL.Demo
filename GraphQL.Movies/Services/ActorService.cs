using LearnGraph.Movies.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnGraph.Movies.Services
{
    public class ActorService : IActorService
    {
        private readonly IList<Actor> _actors;

        public ActorService()
        {
            #region Movies
            _actors = new List<Actor> {
            new Actor{Id=1,Name="Tom Hanks",},
            new Actor{Id=2,Name="Brad Pitt",},
            new Actor{Id=3,Name="Tom Cruise",},
            new Actor{Id=4,Name="Emma Stone",},
            new Actor{Id=5,Name="Rachel MCAdams",},
            new Actor{Id=6,Name="Kael Tian",},
            };
            #endregion
        }

        public Task<IEnumerable<Actor>> GetAsync()
        {
            return Task.FromResult(_actors.AsEnumerable());
        }

        public Task<Actor> GetByIdAsync(int id)
        {
            return Task.FromResult(_actors.SingleOrDefault(x => x.Id == id));
        }
    }
}
