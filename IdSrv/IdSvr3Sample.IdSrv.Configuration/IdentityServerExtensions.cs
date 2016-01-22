using IdentityServer3.Core.Configuration;
using IdSvr3Sample.IdSvr.Configuration.Mockups;
using Microsoft.Owin.Security.Google;
using Owin;

namespace IdSvr3Sample.IdSvr.Configuration
{
  public static class IdentityServerExtensions
  {
    #region Apis
    
    public static IAppBuilder UseIdentityServer(this IAppBuilder app)
    {
      app.Map("/core", coreApp => {
        var factory = new IdentityServerServiceFactory()
          .UseInMemoryUsers(Users.Get())
          .UseInMemoryClients(Clients.Get())
          .UseInMemoryScopes(Scopes.Get());

        var idsrvOptions = new IdentityServerOptions {
          Factory = factory,
          SigningCertificate = Certificate.Load(),

          Endpoints = new EndpointOptions {
            // replaced by the introspection endpoint in v2.2
            EnableAccessTokenValidationEndpoint = false
          },

          AuthenticationOptions = new AuthenticationOptions {
            IdentityProviders = ConfigureIdentityProviders,
            //EnablePostSignOutAutoRedirect = true
          },

          //LoggingOptions = new LoggingOptions
          //{
          //    EnableKatanaLogging = true
          //},

          //EventsOptions = new EventsOptions
          //{
          //    RaiseFailureEvents = true,
          //    RaiseInformationEvents = true,
          //    RaiseSuccessEvents = true,
          //    RaiseErrorEvents = true
          //}
        };

        coreApp.UseIdentityServer(idsrvOptions);
      });

      return app;
    } 

    #endregion

    #region Internals
    
    static void ConfigureIdentityProviders(IAppBuilder app, string signInAsType)
    {
      var google = new GoogleOAuth2AuthenticationOptions {
        AuthenticationType = "Google",
        Caption = "Google",
        SignInAsAuthenticationType = signInAsType,

        ClientId = "767400843187-8boio83mb57ruogr9af9ut09fkg56b27.apps.googleusercontent.com",
        ClientSecret = "5fWcBT0udKY7_b6E3gEiJlze"
      };
      app.UseGoogleAuthentication(google);
    } 

    #endregion
  }
}
