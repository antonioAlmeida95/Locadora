using Graphql.Loja.Model;
using GraphQL.Types;

namespace Graphql.Loja.QueryInputType
{
    public class CarroQueryInput: InputObjectGraphType<Carro>
    {
        public CarroQueryInput()
        {
            Name = nameof(CarroQueryInput);

            Field<int>(c => c.Id).Description("Identificador do carro");
        }
    }
}
