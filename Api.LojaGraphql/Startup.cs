using System;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Graphql.Loja;
using Graphql.Loja.InputsTypes;
using Graphql.Loja.Mutation;
using Graphql.Loja.Persistencia;
using Graphql.Loja.QueryInputType;
using Graphql.Loja.QueryTypes;
using Graphql.Loja.Types;
using GraphQL;
using GraphQL.DataLoader;
using GraphQL.Http;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Api.LojaGraphql
{
    public class Startup
    {
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var builder = new ContainerBuilder();

            builder.RegisterInstance(new DocumentExecuter()).As<IDocumentExecuter>();
            builder.RegisterInstance(new DocumentWriter()).As<IDocumentWriter>();

            services.AddSingleton<IDataLoaderContextAccessor, DataLoaderContextAccessor>();
            services.AddSingleton<DataLoaderDocumentListener>();

            builder.RegisterType<LojaSchema>().As<ISchema>();

            builder.RegisterType<RootQuery>().AsSelf();
            builder.RegisterType<RootMutation>().AsSelf();

            builder.Register<IDependencyResolver>(c =>
            {
                var context = c.Resolve<IComponentContext>();
                return new FuncDependencyResolver(type => context.Resolve(type));
            });

            builder.RegisterType<LocadouraDAO>().AsSelf();

            var graphQlCoreClienteType = typeof(ClienteType).GetTypeInfo();
            var graphQlCoreClienteInputType = typeof(ClienteInputType).GetTypeInfo();
            var graphQlCoreClienteQueryType = typeof(ClienteQueryInput).GetTypeInfo();

            builder.RegisterAssemblyTypes(graphQlCoreClienteType.Assembly)
                .Where(t => t.IsClass && t.Namespace == graphQlCoreClienteType.Namespace)
                .AsSelf();

            builder.RegisterAssemblyTypes(graphQlCoreClienteInputType.Assembly)
                .Where(t => t.IsClass && t.Namespace == graphQlCoreClienteInputType.Namespace)
                .AsSelf();
            
            builder.RegisterAssemblyTypes(graphQlCoreClienteQueryType.Assembly)
                .Where(t => t.IsClass && t.Namespace == graphQlCoreClienteQueryType.Namespace)
                .AsSelf();

            builder.Populate(services);
            var container = builder.Build();
            return container.Resolve<IServiceProvider>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
