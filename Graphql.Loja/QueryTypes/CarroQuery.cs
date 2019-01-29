using System.Collections.Generic;
using Graphql.Loja.InputsTypes;
using Graphql.Loja.Model;
using Graphql.Loja.Persistencia;
using Graphql.Loja.QueryInputType;
using Graphql.Loja.Types;
using GraphQL.Types;

namespace Graphql.Loja.QueryTypes
{
    public class CarroQuery : ObjectGraphType, IQuery
    {
        private LocadoraDAO _locadouraDao; 

        public CarroQuery(LocadoraDAO dataDao)
        {
            _locadouraDao = dataDao;
        }

        public IEnumerable<FieldType> GetFields()
        {
            yield return Field<CarroType>(name: "carro",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<CarroQueryInput>>
                    { Name = nameof(CarroQueryInput) }),
                resolve: ctx => _locadouraDao.GetCarroById(ctx.GetArgument<Carro>(nameof(Carro).ToLower())));

            yield return Field<ListGraphType<CarroType>>(name: "carros",
                resolve: ctx => _locadouraDao.GetCarros());
        }
    }
}
