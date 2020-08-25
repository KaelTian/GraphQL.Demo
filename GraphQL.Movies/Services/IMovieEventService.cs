using GraphQL.Movies.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Movies.Services
{
    public interface IMovieEventService
    {
        ConcurrentStack<MovieEvent> AllEvents { get; }

        void AddError(Exception ex);

        MovieEvent AddEvent(MovieEvent e);

        IObservable<MovieEvent> EventStream();


    }
}
