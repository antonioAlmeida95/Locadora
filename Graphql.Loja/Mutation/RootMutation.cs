using Graphql.Loja.Persistencia;
using GraphQL.Types;

namespace Graphql.Loja.Mutation
{
    public class RootMutation : ObjectGraphType
    {
        public RootMutation(LocadoraDAO locadouraDao)
        {
            foreach (var field in new ClienteMutation(locadouraDao).GetFields())
            {
                AddField(field);
            }

            foreach (var field in new CarroMutation(locadouraDao).GetFields())
            {
                AddField(field);
            }
        }
    }
}
