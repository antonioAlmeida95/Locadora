using Graphql.Loja.Model;
using GraphQL.Types;

namespace Graphql.Loja.Types
{
    public class LocacoesType: ObjectGraphType<Locacoes>
    {
        public LocacoesType()
        {
            Name = nameof(Locacoes);

            Field(l => l.ClienteId);
            Field(l => l.CarroId);

            Field<ClienteType>(name: nameof(Locacoes.Cliente),
                resolve: ctx => ctx.Source.Cliente);
            Field<CarroType>(name: nameof(Locacoes.Carro),
                resolve: ctx => ctx.Source.Carro);
        }
    }
}
