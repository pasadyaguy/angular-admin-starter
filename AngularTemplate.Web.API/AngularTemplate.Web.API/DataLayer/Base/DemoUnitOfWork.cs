using AngularTemplate.Web.API.Models.DemoModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AngularTemplate.Web.API.DataLayer
{
    public class DemoUnitOfWork : UnitOfWork, IDisposable
    {
        /// <summary>
        /// Gets the odin context.
        /// </summary>
        /// <value>
        /// The odin context.
        /// </value>
        public DemoEntities DemoContext
        {
            get { return Context as DemoEntities; }
        }

        public DemoUnitOfWork() : this(new DemoEntities())
        {

        }

        public DemoUnitOfWork(DbContext context) : base(context)
        {
            if (context == null)
            {
                context = new DemoEntities();
            }

        }
    }
}