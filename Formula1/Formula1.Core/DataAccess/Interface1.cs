using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Core.DataAccess
{
    public interface Interface1<T>
    {
         List<T> List();

        IQueryable<T> ListQuaryable();


         List<T> List(Expression<Func<T, bool>> where);


         int Insert(T obj);


         int Update(T obj);


         int Delete(T obj);


         int Save();


         T Find(Expression<Func<T, bool>> where);
        
    }
}
