using Graphql.Loja.Mutation;
using Graphql.Loja.QueryTypes;
using GraphQL;
using GraphQL.Types;

namespace Graphql.Loja
{
    public class LojaSchema : Schema
    {
        public LojaSchema(IDependencyResolver resolver)
            : base(resolver)
        {
            Query = resolver.Resolve<ClienteQuery>();
            //Query = resolver.Resolve<CarroQuery>();
            //Query = resolver.Resolve<EnderecoQuery>();
            
            Mutation = resolver.Resolve<ClienteMutation>();
            //Mutation = resolver.Resolve<CarroMutation>();
            //Mutation = resolver.Resolve<EnderecoMutation>();
        }
    }
}
