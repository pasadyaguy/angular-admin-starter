using AngularTemplate.Web.API.BusinessLayer;
using AngularTemplate.Web.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AngularTemplate.Web.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = false)]
    [Authorize]
    public class AdminController : BaseController
    {
        AdminService adminService = new AdminService();

        [HttpGet, Route("api/Admin")]
        public GenericResult<bool> Demo()
        {
            try
            {
                var Payload = adminService.Demo();

                return new GenericResult<bool>(Payload, true);
            }
            catch (Exception ex)
            {
                return new GenericResult<bool>(false, false, ex.Message, ex);
            }
        }
    }
}
