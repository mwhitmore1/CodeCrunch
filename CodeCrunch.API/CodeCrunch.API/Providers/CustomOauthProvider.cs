using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeCrunch.API.Infrastructure;
using CodeCrunch.API.Models;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security;

namespace CodeCrunch.API.Provider
{
    public class CustomOAuthProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();

            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var allowOrigin = "*";

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowOrigin });

            using (AuthorizationRepository authRepository = new AuthorizationRepository())
            {
                User user = await authRepository.FindUser(context.UserName, context.Password);

                if (user == null)
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return;
                }
            }

            var token = new ClaimsIdentity(context.Options.AuthenticationType);
            token.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            token.AddClaim(new Claim(ClaimTypes.Role, "user"));

            context.Validated(token);
        }
    }
}