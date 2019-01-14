using Graphql.Loja.Mutation;
using Graphql.Loja.QueryTypes;
using GraphQL;
using GraphQL.Types;

namespace Graphql.Loja
{
    public class LojaSchema : Schema
    {
        public LojaSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<RootQuery>();
            Mutation = resolver.Resolve<RootMutation>();
        }
    }
}
