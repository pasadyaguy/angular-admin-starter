using AngularTemplate.Web.API.DataLayer.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace AngularTemplate.Web.API.DataLayer
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected IUnitOfWork UOW
        {
            get
            {
                if (_unitofwork == null)
                    throw new Exception("Unit Of Work cannot be null");

                return _unitofwork;
            }
        }

        IUnitOfWork _unitofwork;

        public Repository(IUnitOfWork unitOfWork)
        {
            _unitofwork = unitOfWork;
        }

        public TEntity Get(int id)
        {
            return UOW.Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return UOW.Context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Find(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return UOW.Context.Set<TEntity>().Where(predicate);
        }

        public IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = UOW.Context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public void Add(TEntity entity)
        {
            UOW.Context.Set<TEntity>().Add(entity);
        }
        public void Update(TEntity entity)
        {
            UOW.Context.Set<TEntity>().Attach(entity);
            UOW.Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;

        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            UOW.Context.Set<TEntity>().AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            UOW.Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            UOW.Context.Set<TEntity>().RemoveRange(entities);
        }
    }
}