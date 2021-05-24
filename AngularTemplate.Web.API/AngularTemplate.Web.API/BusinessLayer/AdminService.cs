using AngularTemplate.Web.API.Common.Interfaces;
using AngularTemplate.Web.API.DataLayer;
using AngularTemplate.Web.API.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularTemplate.Web.API.BusinessLayer
{
    public class AdminService
    {
        private DemoUnitOfWork demoUnitOfWork;

        public AdminService()
        {
            if (demoUnitOfWork == null)
            {
                demoUnitOfWork = new DemoUnitOfWork();
            }
        }

        public bool Demo()
        {
            AdminRepository adminRepository = new AdminRepository(demoUnitOfWork);
            return adminRepository.Demo();
        }

        #region User

        public UserInfo GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        internal UserInfo GetUserByBadge(string badge)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}