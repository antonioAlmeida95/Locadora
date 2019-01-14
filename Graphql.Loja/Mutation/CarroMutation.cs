using System.Collections.Generic;
using Graphql.Loja.InputsTypes;
using Graphql.Loja.Model;
using Graphql.Loja.Persistencia;
using Graphql.Loja.Types;
using GraphQL.Types;

namespace Graphql.Loja.Mutation
{
    public class CarroMutation : ObjectGraphType, IMutation
    {
        private LocadouraDAO _locadouraDao; 

        public CarroMutation(LocadouraDAO dataDao)
        {
            _locadouraDao = dataDao;
        }

        public IEnumerable<FieldType> GetFields()
        {
            yield return Field<CarroType>(
                "createCarro",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<CarroInputType>> { Name = "carro" }
                ),
                resolve: context =>
                {
                    var carro = context.GetArgument<Carro>("carro");
                    return _locadouraDao.AddCarro(carro);
                });
        }
    }
}
