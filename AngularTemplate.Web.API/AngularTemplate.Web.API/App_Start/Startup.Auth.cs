using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin.Security.ActiveDirectory;
using Owin;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens;

namespace AngularTemplate.Web.API
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseWindowsAzureActiveDirectoryBearerAuthentication(new WindowsAzureActiveDirectoryBearerAuthenticationOptions
            {
                Tenant = ConfigurationManager.AppSettings["AzureAD:Tenant"],
                TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidAudiences = GetValidAudiences(),
                    ValidIssuers = GetValidIssuers()
                }
            });
        }
        private string GetValidAudience(string number = "")
        {
            var environment = ConfigurationManager.AppSettings["AzureEnvironment"].ToString();
            var audienceKey = "ADFS:" + environment + "ValidAudience" + number;
            return ConfigurationManager.AppSettings[audienceKey].ToString();
        }

        private IEnumerable<string> GetValidAudiences()
        {
            IEnumerable<string> result = new string[]
            {
                ConfigurationManager.AppSettings["AzureAD:ValidAudience"]
            };

            return result;
        }

        private IEnumerable<string> GetValidIssuers()
        {
            IEnumerable<string> result = new string[]{
                ConfigurationManager.AppSettings["AzureAD:ValidIssuer"]
            };

            return result;

        }
    }
}