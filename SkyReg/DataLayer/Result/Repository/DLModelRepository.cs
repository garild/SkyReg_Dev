using DataLayer.Result.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DataLayer.Result.Repository
{
    public class DLModelRepository<T> : DbContext, IDLModel<T> where T : class, new()
    {
        private static readonly DLModelContainer _context = new DLModelContainer();

        private DbSet<T> entity;

        public DLModelRepository()
        {

        }

        public ResultType<T> Add(T data)
        {
            Entities.Add(data);
            _context.SaveChanges();
            return new ResultType<T>() { Value = data };
        }

        public ResultType<T> Delete(T data)
        {
            throw new NotImplementedException();
        }

        public ResultType<T> Update(T data)
        {
            _context.Entry(data).State = EntityState.Modified;
            _context.SaveChanges();
            return new ResultType<T>() { Value = data };
        }

        public List<T> GetAll()
        {
            var data = Entities.ToList();
            return data;
        }


        private IDbSet<T> Entities
        {
            get
            {
                if (entity == null)
                    return _context.Set<T>();

                return entity;
            }

        }
    }
}
