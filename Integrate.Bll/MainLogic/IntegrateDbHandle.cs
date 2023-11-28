using Integrate.Common;
using Integrate.Database.Persistence.Models;

namespace Integrate.Bll.MainLogic
{
    public class IntegrateDbHandle<TModel> : DbHandle<TModel> where TModel : class
    {
        public IntegrateDbHandle() 
        {
            DatabaseHandle = new IntegrateContext();
        }
    }
}
