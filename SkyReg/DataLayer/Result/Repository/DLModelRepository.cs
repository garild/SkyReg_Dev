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
        private readonly DLModelContainer _context;

        private DbSet<T> entity;

        public DLModelRepository()
        {
            _context = new DLModelContainer();
        }

        public ResultType<T> Add(T data)
        {
            Entities.Add(data);
            SaveChanges();
            return new ResultType<T>() { Value = data };
        }

        public ResultType<T> Delete(T data)
        {
            throw new NotImplementedException();
        }

        public ResultType<T> Update(T data)
        {
            _context.Entry(data).State = EntityState.Modified;
            SaveChanges();
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
