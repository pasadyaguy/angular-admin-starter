
using AngularTemplate.Web.API.Models.DemoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularTemplate.Web.API.DataLayer.Repositories
{
    public class AdminRepository : Repository<AdminRepository>
    {
        DemoEntities db;
        public AdminRepository(IUnitOfWork DemoUOW) : base(DemoUOW)
        {
            db = ((DemoEntities)UOW.Context);
        }

        public bool Demo()
        {
            return true;
        }
    }
}