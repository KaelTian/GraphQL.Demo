using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GraphQL.Movies.Profiles;
using GraphQL.Movies.Schema;
using GraphQL.Movies.Services;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using LearnGraph.Movies.Schema;
using LearnGraph.Movies.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GraphQL.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //// If using Kestrel:
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            services.AddSingleton<IMovieService, MovieService>();
            services.AddSingleton<IActorService, ActorService>();

            AutoMapper.IConfigurationProvider config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MovieProfile>();
            });
            services.AddSingleton(config);
            services.AddSingleton<IMapper, Mapper>();
            services.AddSingleton<MoviesQuery>();
            services.AddSingleton<MovieType>();
            services.AddSingleton<ActorType>();
            services.AddSingleton<MovieRatingEnum>();
            services.AddSingleton<MovieInputType>();
            services.AddSingleton<MoviesMutation>();
            services.AddSingleton<MovieEventType>();
            services.AddSingleton<MoviesSubscription>();
            services.AddSingleton<IMovieEventService, MovieEventService>();
            services.AddSingleton<MoviesSchema>();
            services.AddLogging(builder => builder.AddConsole());
            services.AddHttpContextAccessor();

            services.AddGraphQL(options =>
            {
                options.EnableMetrics = true;
                options.ExposeExceptions = true;
            })
            .AddSystemTextJson()
            .AddNewtonsoftJson() // or use AddSystemTextJson for .NET Core 3+
            .AddWebSockets() // Add required services for web socket support
            .AddDataLoader()
            .AddGraphTypes(typeof(MoviesSchema))
            .AddUserContextBuilder(httpContext => new GraphQLUserContext { User = httpContext.User });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            // this is required for websockets support
            app.UseWebSockets();

            // use websocket middleware for MoviesSchema at path /graphql
            app.UseGraphQLWebSockets<MoviesSchema>("/graphql");

            // use HTTP middleware for MoviesSchema at path /graphql
            app.UseGraphQL<MoviesSchema>("/graphql");


            // use graphql-playground middleware at default url /ui/playground
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());

            //// add http for Schema at default url /graphql
            //app.UseGraphQL<ISchema>();

            //// use graphql-playground at default url /ui/playground
            //app.UseGraphQLPlayground();

        }
    }
}
