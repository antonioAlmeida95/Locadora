using Graphql.Loja.Model;
using GraphQL.Types;

namespace Graphql.Loja.Types
{
    public class CarroType: ObjectGraphType<Carro>
    {
        public CarroType()
        {
            Name = nameof(Carro);

            Field<int>(c => c.Id);
            Field<string>(c => c.Modelo);
            Field<int>(c => c.Ano);
            Field<int>(c => c.Velocidade);

            Field<ListGraphType<LocacoesType>>(name: nameof(Carro.Locacoes),
                resolve: ctx => ctx.Source.Locacoes);
        }
    }
}
