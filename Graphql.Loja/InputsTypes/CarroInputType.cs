using Graphql.Loja.Model;
using GraphQL.Types;

namespace Graphql.Loja.InputsTypes
{
    public class CarroInputType: InputObjectGraphType<Carro>
    {
        public CarroInputType()
        {
            Name = nameof(CarroInputType);

            Field<int>(c => c.Id);
            Field<string>(c => c.Modelo);
            Field<int>(c => c.Ano);
            Field<int>(c => c.Diaria);
            Field<int>(c => c.Velocidade);

            Field<ListGraphType<LocacoesInputType>>(name: "locados");
        }
    }
}
