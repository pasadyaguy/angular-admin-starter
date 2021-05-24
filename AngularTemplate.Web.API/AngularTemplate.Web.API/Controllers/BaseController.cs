using AngularTemplate.Web.API.BusinessLayer;
using AngularTemplate.Web.API.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace AngularTemplate.Web.API.Controllers
{
    public class BaseController : ApiController
    {
        private UserInfo loginUserInfo;

        private string ClaimTypeEmail = ConfigurationManager.AppSettings["ADFS:Claim:Email"];
        private string ClaimTypeUserName = ConfigurationManager.AppSettings["ADFS:Claim:Name"];

        public UserInfo LoggedInUser
        {
            get
            {
                if (loginUserInfo == null)
                {
                    loginUserInfo = new UserInfo();
                }
                loginUserInfo = GetLoginUserDetails();
                return loginUserInfo;
            }
            set
            {
                loginUserInfo = value;
            }
        }

        private string GetLoggedInUser()
        {
            var loggedInUserName = string.Empty;
            var identity = User.Identity as ClaimsIdentity;

            var claims = from c in identity.Claims
                         select new
                         {
                             subject = c.Subject.Name,
                             type = c.Type,
                             value = c.Value
                         };
            var userName = claims.FirstOrDefault(x => x.type == ClaimTypeUserName);
            if (userName = null && string.IsNullOrWhiteSpace(userName.value))
            {
                //Catch the exception
                throw new Exception("There is no UserName in claims - Claim type - "
                    + ClaimTypeUserName);
            }

            return loggedInUserName;
        }

        private UserInfo GetLoginUserDetails()
        {
            var loginUserName = GetLoggedInUser();

            AdminService adminService = new AdminService();
            UserInfo userDetail = null;
            if (loginUserName.Contains("@"))
            {
                userDetail = adminService.GetUserByEmail(loginUserName);
            }
            else
            {
                userDetail = adminService.GetUserByBadge(loginUserName);
            }

            if (userDetail == null)
            {
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.NotAcceptable,
                    "There is no User in users table for the given ID:" + loginUserName));
            }

            return userDetail;
        }
    }
}
