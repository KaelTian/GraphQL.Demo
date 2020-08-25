using System.Collections.Generic;
using System.Security.Claims;

namespace GraphQL.Web
{
    public class GraphQLUserContext : Dictionary<string, object>
    {
        public ClaimsPrincipal User { get; set; }
    }
}
