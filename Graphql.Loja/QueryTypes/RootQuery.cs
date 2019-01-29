using Graphql.Loja.Persistencia;
using GraphQL.Types;

namespace Graphql.Loja.QueryTypes
{
    public class RootQuery : ObjectGraphType
    {
        public RootQuery(LocadoraDAO dataDao)
        {
            foreach (var field in new ClienteQuery(dataDao).GetFields())
            {
                AddField(field);
            }

            foreach (var field in new CarroQuery(dataDao).GetFields())
            {
                AddField(field);
            }
        }
    }
}
