using System.Linq.Expressions;

namespace Integrate.Common.Interfaces
{
    public interface IDbHandle<TModel> where TModel : class
    {
        IQueryable<TModel> Select(Expression<Func<TModel, bool>> filterCondition);

        TModel Insert(TModel model);
    }
}
