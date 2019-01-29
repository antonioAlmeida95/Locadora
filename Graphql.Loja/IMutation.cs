using System.Collections.Generic;
using GraphQL.Types;

namespace Graphql.Loja
{
    public interface IMutation
    {
        IEnumerable<FieldType> GetFields();
    }
}