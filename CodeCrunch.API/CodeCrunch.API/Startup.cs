using Owin;
using System;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Formatting;
using Microsoft.Owin.Security.OAuth;
using CodeCrunch.API.Provider;
using Microsoft.Owin;
using CodeCrunch.API.Infrastructure;
using SimpleInjector.Integration.WebApi;
using SimpleInjector;
using CodeCrunch.Data.Infrastructure;
using CodeCrunch.Core.Infrastructure;
using CodeCrunch.Core.Repository;
using CodeCrunch.Data.Repository;
using SimpleInjector.Extensions.ExecutionContextScoping;
using CodeCrunch.Core.Domain;
using Microsoft.AspNet.Identity;

[assembly: OwinStartup(typeof(CodeCrunch.API.Startup))]
namespace CodeCrunch.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var container = ConfigureSimpleInjector(app);

            HttpConfiguration httpConfig = new HttpConfiguration
            {
                DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container)
            };
            ConfigureOAuth(app, container);
            ConfigureWebApi(httpConfig);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(httpConfig);
        }

        private void ConfigureOAuth(IAppBuilder app, Container container)
        {
            var authenticationOptions = new OAuthBearerAuthenticationOptions();
            app.UseOAuthBearerAuthentication(authenticationOptions);

            Func<IAuthorizationRepository> authRepositoryFactory = container.GetInstance<IAuthorizationRepository>;

            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                // for dev environment only 
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/oauth/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new CustomOAuthProvider(authRepositoryFactory)
            };

            app.UseOAuthAuthorizationServer(OAuthServerOptions);
        }

        private void ConfigureWebApi(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }

        private Container ConfigureSimpleInjector(IAppBuilder app)
        {
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new ExecutionContextScopeLifestyle();

            container.Register<IDatabaseFactory, DatabaseFactory>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>();

            // Infrastructure
            container.Register<IUserStore<User, int>, UserStore>(Lifestyle.Scoped);
            container.Register<IAuthorizationRepository, AuthorizationRepository>(Lifestyle.Scoped);

            // Repositories
            container.Register<IBootcampRepository, BootcampRepository>();
            container.Register<IChapterRepository, ChapterRepository>();
            container.Register<IModuleRepository, ModuleRepository>();
            container.Register<IProfilePictureRepository, ProfilePictureRepository>();
            container.Register<IRoleRepository, RoleRepository>();
            container.Register<IStudentRepository, StudentRepository>();
            container.Register<ITrackRepository, TrackRepository>();
            container.Register<IUserRepository, UserRepository>();
            container.Register<IUserRoleRepository, UserRoleRepository>();

            app.Use(async (context, next) => {
                using (container.BeginExecutionContextScope())
                {
                    await next();
                }
            });

            container.Verify();

            return container;
        }
    }
}
