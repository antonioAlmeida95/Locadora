
using System.Security.Claims;


namespace Api.LojaGraphql
{
    public class GraphQLUserContext
    {
        public ClaimsPrincipal User { get; set; }
    }
}
