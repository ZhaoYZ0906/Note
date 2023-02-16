using HybridClient.Requirements;
using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HybridClient.Handler
{
    public class AHandler : AuthorizationHandler<ARequire>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ARequire requirement)
        {
            var FamilyName = context.User.Claims.FirstOrDefault(x=> (x.Type == JwtClaimTypes.FamilyName) )?.Value;
            var Location = context.User.Claims.FirstOrDefault(x => x.Type == "location")?.Value;

            if (FamilyName== "Smith" && Location== "somewhere" && context.User.Identity.IsAuthenticated)
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }            

            context.Fail();
            return Task.CompletedTask;
        }
    }
}
