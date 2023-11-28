using Integrate.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Integrate.Common
{
    public abstract class DbHandle<TModel> : IDbHandle<TModel> where TModel : class
    {
        protected DbContext DatabaseHandle;

        public virtual TModel Insert(TModel model)
        {
            EntityEntry entr = DatabaseHandle.Set<TModel>().Add(model);

            DatabaseHandle.SaveChanges();

            return (TModel)(entr.Entity);
        }

        public virtual IQueryable<TModel> Select(Expression<Func<TModel, bool>> filterCondition)
        {
            IQueryable<TModel> result = DatabaseHandle.Set<TModel>().Where(filterCondition);

            return result;
        }
    }
}
