using Graphql.Loja.Model;
using Graphql.Loja.Types;
using GraphQL.Types;

namespace Graphql.Loja.InputsTypes
{
    public class ClienteInputType: InputObjectGraphType<Cliente>
    {
        public ClienteInputType()
        {
            Name = nameof(ClienteInputType);

            Field<int>(c => c.Id);
            Field<string>(c => c.Nome);
            Field<string>(c => c.Perfil);

            Field<ListGraphType<LocacoesInputType>>(nameof(Cliente.Locados));

        }
    }
}
