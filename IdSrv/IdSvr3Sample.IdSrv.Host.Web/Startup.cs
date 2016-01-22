using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdSvr3Sample.IdSvr.Configuration;
using Owin;

namespace IdSvr3Sample.Host.Web
{
  public class Startup
  {
    public void Configuration(IAppBuilder app)
    {
      app.UseIdentityServer();
    }
  }
}