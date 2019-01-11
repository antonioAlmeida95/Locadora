using Graphql.Loja.Model;
using GraphQL.Types;

namespace Graphql.Loja.Types
{
    public class ClienteType: ObjectGraphType<Cliente>
    {
        public ClienteType()
        {
            Name = nameof(Cliente);
            Field<int>(c => c.Id);
            Field<string>(c => c.Nome);
            Field<string>(c => c.Perfil);
            

            Field<ListGraphType<LocacoesType>>(name: nameof(Cliente.Locados), 
                resolve: ctx => ctx.Source.Locados);


        }
    }
}
