using Formula1.Common;

using Formula1.DataAccessLayer.Abstract;
using Formula1.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.DataAccessLayer.EntityFramework
{
    public class Repository<T> : RepositoryBase, Interface1<T> where T : class
    {
        
        private DbSet<T> _objectsect;

        public Repository()
        {  
            _objectsect = context.Set<T>();
        }

        public List<T> List()
        {
            return context.Set<T>().ToList();
        }

        public IQueryable<T> ListQuaryable()
        {
            return _objectsect.AsQueryable<T>();
        }

        public List<T> List(Expression<Func<T,bool>> where)
        {
            return _objectsect.Where(where).ToList();
        }

        public int Insert(T obj)
        {
            

            if(obj is MyEntityBase)
            {
                MyEntityBase o = obj as MyEntityBase;
                DateTime now = DateTime.Now;

                o.CreatedOn = now;
                o.ModifiedOn = now;
                o.ModifiedUserName = App.Common.GetUsername() == null ? "System": App.Common.GetUsername();
            }
            _objectsect.Add(obj);

            return Save();
        }

        public int Update(T obj) 
        {
            if (obj is MyEntityBase)
            {
                MyEntityBase o = obj as MyEntityBase;
               
                o.ModifiedOn = DateTime.Now;
                o.ModifiedUserName = App.Common.GetUsername();
            }


            return Save();
        }

        public int Delete(T obj)
        {
            _objectsect.Remove(obj);
            return Save();
        }

        public int Save()
        {
            try
            {
                return context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                string strErrors = "";
                foreach (var eve in e.EntityValidationErrors)
                {
                    strErrors +=
                    string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        strErrors +=
                        string.Format("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }

                int i = 1;
                throw;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return _objectsect.FirstOrDefault(where);
        }
    }

}
