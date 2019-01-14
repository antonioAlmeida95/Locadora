using System.Collections.Generic;
using Graphql.Loja.InputsTypes;
using Graphql.Loja.Model;
using Graphql.Loja.Persistencia;
using Graphql.Loja.QueryInputType;
using Graphql.Loja.Types;
using GraphQL.Types;

namespace Graphql.Loja.QueryTypes
{
    public class ClienteQuery : ObjectGraphType, IQuery
    {
        private LocadouraDAO _locadouraDao;

        public ClienteQuery(LocadouraDAO dataDao)
        {
            _locadouraDao = dataDao;
        }

        public IEnumerable<FieldType> GetFields()
        {
            yield return Field<ClienteType>(
                name: "cliente",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ClienteQueryInput>>
                    {Name = nameof(Cliente), Description = "cliente a inserir"}),
                resolve: ctx => _locadouraDao.GetClienteById(ctx.GetArgument<Cliente>(nameof(Cliente).ToLower()))
            );

            yield return Field<ListGraphType<ClienteType>>(
                name: "clientes", resolve: ctx => _locadouraDao.GetClientes()
            );
        }
    }
}
