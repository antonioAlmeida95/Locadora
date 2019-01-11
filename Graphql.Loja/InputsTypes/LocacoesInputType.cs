using Graphql.Loja.Model;
using GraphQL.Types;

namespace Graphql.Loja.InputsTypes
{
    public class LocacoesInputType : InputObjectGraphType<Locacoes>
    {
        public LocacoesInputType()
        {
            Name = nameof(LocacoesInputType);

            Field<int>(lc => lc.CarroId, nullable: true);
            Field<int>(lc => lc.ClienteId, nullable: true);

            Field<CarroInputType>(name: nameof(Locacoes.Carro));
            Field<ClienteInputType>(name: nameof(Locacoes.Cliente));

        }
    }
}
