using IdSvr3Sample.IdSvr.Configuration;
using Owin;

namespace IdSvr3Sample.Host.Web
{
  public class Startup
  {
    /// <summary>
    /// Configure the application
    /// </summary>
    /// <param name="app">Application</param>
    public void Configuration(IAppBuilder app)
    {
      app.UseIdentityServer();
    }
  }
}