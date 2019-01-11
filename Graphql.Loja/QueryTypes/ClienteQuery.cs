using Graphql.Loja.InputsTypes;
using Graphql.Loja.Model;
using Graphql.Loja.Persistencia;
using Graphql.Loja.QueryInputType;
using Graphql.Loja.Types;
using GraphQL.Types;

namespace Graphql.Loja.QueryTypes
{
    public class ClienteQuery : ObjectGraphType<object>
    {
        public ClienteQuery(LocadouraDAO dataDao)
        {
            Name = "QueryCliente";

            Field<ClienteType>(name: "cliente",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ClienteQueryInput>>
                    {Name = nameof(Cliente), Description = "cliente a inserir"}),
                resolve: ctx => dataDao.GetClienteById(ctx.GetArgument<Cliente>(nameof(Cliente).ToLower())));

            Field<ListGraphType<ClienteType>>(name: "clientes", resolve: ctx => dataDao.GetClientes());
        }
    }
}
