using System.Collections.Generic;
using Graphql.Loja.InputsTypes;
using Graphql.Loja.Model;
using Graphql.Loja.Persistencia;
using Graphql.Loja.Types;
using GraphQL.Types;

namespace Graphql.Loja.Mutation
{
    public class ClienteMutation: ObjectGraphType, IMutation
    {
        private LocadoraDAO _locadouraDao;

        public ClienteMutation(LocadoraDAO dataDao)
        {
            _locadouraDao = dataDao;
        }

        public IEnumerable<FieldType> GetFields()
        {
            yield return Field<ClienteType>(
                "createCliente",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ClienteInputType>> { Name = "cliente" }
                ),
                resolve: context =>
                {
                    var cliente = context.GetArgument<Cliente>("cliente");
                    return _locadouraDao.AddCliente(cliente);
                });
        }
    }
}
