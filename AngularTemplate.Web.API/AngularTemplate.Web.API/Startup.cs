﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(AngularTemplate.Web.API.Startup))]

namespace AngularTemplate.Web.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            ConfigureAuth(app);
        }
    }
}
