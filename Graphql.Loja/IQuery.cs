using System.Collections.Generic;
using GraphQL.Types;

namespace Graphql.Loja
{
    public interface IQuery
    {
        IEnumerable<FieldType> GetFields();
    }
}