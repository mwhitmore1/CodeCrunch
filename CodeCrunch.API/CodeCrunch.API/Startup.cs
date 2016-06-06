using Owin;
using System;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Formatting;
using Microsoft.Owin.Security.OAuth;
using CodeCrunch.API.Provider;
using Microsoft.Owin;
using Newtonsoft.Json;

[assembly: OwinStartup(typeof(CodeCrunch.API.Startup))]
namespace CodeCrunch.API
{
    public class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                HttpConfiguration httpConfig = new HttpConfiguration();
                ConfigureOAuth(app);
                ConfigureWebApi(httpConfig);
                app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
                app.UseWebApi(httpConfig);
            }

            private void ConfigureOAuth(IAppBuilder app)
            {
                var authenticationOptions = new OAuthBearerAuthenticationOptions();
                app.UseOAuthBearerAuthentication(authenticationOptions);

                OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
                {
                    // for dev environment only 
                    AllowInsecureHttp = true,
                    TokenEndpointPath = new PathString("/oauth/token"),
                    AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                    Provider = new CustomOAuthProvider()
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

           

            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);


            ///code to setup your camel case conversion
            var formatters = config.Formatters;
            var jsonFormatter = formatters.JsonFormatter;
            var settings = jsonFormatter.SerializerSettings;
            settings.Formatting = Formatting.Indented;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            json.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        }
        }
    }
