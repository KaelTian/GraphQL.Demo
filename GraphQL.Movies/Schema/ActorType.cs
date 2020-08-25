using GraphQL.Types;
using LearnGraph.Movies.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnGraph.Movies.Schema
{
  public  class ActorType:ObjectGraphType<Actor>
    {
        public ActorType()
        {
            Name = "Actor";
            Description = "It is a actor!!!";
            Field(a => a.Id);
            Field(a => a.Name);
        }
    }
}
