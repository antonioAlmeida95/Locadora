using Graphql.Loja.InputsTypes;
using Graphql.Loja.Model;
using Graphql.Loja.Persistencia;
using Graphql.Loja.QueryInputType;
using Graphql.Loja.Types;
using GraphQL.Types;

namespace Graphql.Loja.QueryTypes
{
    public class CarroQuery : ObjectGraphType<object>
    {
        public CarroQuery(LocadouraDAO dataDao)
        {
            Name = "QueryCarro";

            Field<CarroType>(name: "carro",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<CarroQueryInput>>
                    {Name = nameof(CarroQueryInput)}),
                resolve: ctx => dataDao.GetCarroById(ctx.GetArgument<Carro>(nameof(Carro).ToLower())));

            Field<ListGraphType<CarroType>>(name: "carros",
                resolve: ctx => dataDao.GetCarros());
        }
    }
}
