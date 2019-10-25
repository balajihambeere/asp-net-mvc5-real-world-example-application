using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GyandhaaraLibrary.Service.Interfaces
{
    public interface IServiceBase<T>
    {
        IEnumerable<T> GetAll();
        T FindBy(Expression<Func<T, bool>> predicate);
        int? Add(T entity);
        void Delete(T entity);
        int? Edit(T entity);
    }
}
