using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Generics
{
    public interface IGeneric<T> where T : class
    {
        Task Add(T Objeto);

        Task Update(T Objeto);

        Task Delete(T Objeto);



        Task<T> GetById(Expression<Func<T, bool>> predicate);

        Task<List<T>> List();
    }
}
