using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Graphql.Loja;
using Graphql.Loja.InputsTypes;
using Graphql.Loja.Mutation;
using Graphql.Loja.Persistencia;
using Graphql.Loja.QueryInputType;
using Graphql.Loja.QueryTypes;
using Graphql.Loja.Types;
using GraphQL;
using GraphQL.Http;
using GraphQL.Server;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Api.LojaGraphql
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));

            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<IDocumentWriter, DocumentWriter>();

            services.AddSingleton<LocadouraDAO>();

            services.AddSingleton<ClienteQuery>();
            services.AddSingleton<ClienteMutation>();
            services.AddSingleton<ClienteType>();
            services.AddSingleton<ClienteInputType>();
            services.AddSingleton<ClienteQueryInput>();

            services.AddSingleton<CarroQuery>();
            services.AddSingleton<CarroMutation>();
            services.AddSingleton<CarroType>();
            services.AddSingleton<CarroInputType>();
            services.AddSingleton<CarroQueryInput>();

            services.AddSingleton<LocacoesInputType>();
            services.AddSingleton<LocacoesType>();
            
            services.AddSingleton<ISchema, LojaSchema>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddGraphQL(_ =>
            {
                _.EnableMetrics = true;
                _.ExposeExceptions = true;
            })
            .AddUserContextBuilder(httpContext => new GraphQLUserContext { User = httpContext.User });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            app.UseDeveloperExceptionPage();

            // add http for Schema at default url /graphql
            app.UseGraphQL<ISchema>("/graphql");

            /*// use graphql-playground at default url /ui/playground
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions
            {
                Path = "/ui/playground"
            });*/
        }
    }
}
