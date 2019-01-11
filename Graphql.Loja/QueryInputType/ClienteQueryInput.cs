using Graphql.Loja.Model;
using GraphQL.Types;

namespace Graphql.Loja.QueryInputType
{
    public class ClienteQueryInput : InputObjectGraphType<Cliente>
    {
        public ClienteQueryInput()
        {
            Name = nameof(ClienteQueryInput);

            Field<int>(c => c.Id).Description("Identificador do cliente");
        }
    }
}
