﻿using System.Web.Http;

namespace AngularTemplate.Web.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

        }
    }
}
