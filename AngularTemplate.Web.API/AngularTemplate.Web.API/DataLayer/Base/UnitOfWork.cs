using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AngularTemplate.Web.API.DataLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed;
        private DbContext _dataContext;

        public DbContext Context
        {
            get
            {
                if (_dataContext == null)
                    throw new Exception("DBContext cannot be null");

                return _dataContext;
            }
        }

        public UnitOfWork(DbContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void SaveChanges()
        {
            _dataContext.SaveChanges();
        }


        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        #region IDisposable Support
        public virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (!disposing) return;

            if (_dataContext != null)
            {
                _dataContext.Dispose();
                _dataContext = null;
            }

            _disposed = true;
        }
        #endregion

    }
}