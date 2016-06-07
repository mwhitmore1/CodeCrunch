using CodeCrunch.Core.Repository;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CodeCrunch.API.Provider
{
    public class CustomOAuthProvider : OAuthAuthorizationServerProvider
    {
        private Func<IAuthorizationRepository> _authRepositoryFactory;
        private IAuthorizationRepository _authRepository => _authRepositoryFactory.Invoke();

        public CustomOAuthProvider(Func<IAuthorizationRepository> authRepositoryFactory)
        {
            _authRepositoryFactory = authRepositoryFactory;
            /*
                function getSomeObject() {
                    return { hey: 'there' };
                }

                function module(factory) {
                    var object = factory();
                }

                module(getSomeObject);
            */
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();

            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var allowOrigin = "*";

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowOrigin });

            
            var user = await _authRepository.FindUser(context.UserName, context.Password);

            if (user == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }

            var token = new ClaimsIdentity(context.Options.AuthenticationType);
            token.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            foreach (var role in user.Roles)
            {
                token.AddClaim(new Claim(ClaimTypes.Role, role.Role.Name));
            }

            context.Validated(token);
        }
    }
}