using Graphql.Loja.InputsTypes;
using Graphql.Loja.Model;
using Graphql.Loja.Persistencia;
using Graphql.Loja.Types;
using GraphQL.Types;

namespace Graphql.Loja.Mutation
{
    public class ClienteMutation: ObjectGraphType
    {
        public ClienteMutation(LocadouraDAO dataDao)
        {
            Name = "MutationCliente";

            Field<ClienteType>(
                "createCliente",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ClienteInputType>> { Name = "cliente" }
                ),
                resolve: context =>
                {
                    var cliente = context.GetArgument<Cliente>("cliente");
                    return dataDao.AddCliente(cliente);
                });

        }
    }
}
