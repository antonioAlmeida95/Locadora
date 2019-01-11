using Graphql.Loja.InputsTypes;
using Graphql.Loja.Model;
using Graphql.Loja.Persistencia;
using Graphql.Loja.Types;
using GraphQL.Types;

namespace Graphql.Loja.Mutation
{
    public class CarroMutation : ObjectGraphType
    {
        public CarroMutation(LocadouraDAO dataDao)
        {
            Name = "MutationCarro";

            Field<CarroType>(
                "createCarro",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<CarroInputType>> { Name = "carro" }
                ),
                resolve: context =>
                {
                    var carro = context.GetArgument<Carro>("carro");
                    return dataDao.AddCarro(carro);
                });

        }
    }
}
