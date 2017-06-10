using DataLayer.Result.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;

namespace DataLayer.Result.Repository
{
    public class DLModelRepository<T> : DbContext, IDLModel<T> where T : class, new()
    {
        private readonly DLModelContainer context = new DLModelContainer();
        private IDbSet<T> Entity;
        string errorMessage = string.Empty;

        public DLModelRepository()
        {

        }

        public T GetById(object id)
        {
            return this.Entities.Find(id);
        }

        public ResultType<T> Insert(T entity)
        {
            try
            {
                if (entity == null)
                {
                    return new ResultType<T>() { Value = null };
                }
                this.Entities.Add(entity);
                this.context.SaveChanges();

                return new ResultType<T>() { Value = entity };
            }
            catch (DbEntityValidationException dbEx)
            {

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        errorMessage += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                    }
                }

                return new ResultType<T>() { Value = null, Error = errorMessage };
            }

        }

        public ColletionResult<T> GetAll(string include = null)
        {
            try
            {
                List<T> result = new List<T>();
                if (!string.IsNullOrEmpty(include))
                    result = Table.Include(include).AsNoTracking().ToList();
                else
                    result = Table.AsNoTracking().ToList();

                return new ColletionResult<T>() { Value = result };
            }

            catch (DbEntityValidationException dbEx)
            {

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        errorMessage += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                    }
                }

                return new ColletionResult<T>() { Value = null, Error = errorMessage };
            }
        }


        public ResultType<T> Update(T entity)
        {
            try
            {
                if (entity == null)
                {
                    return new ResultType<T>() { Value = null };
                }
                context.Entry(entity).State = EntityState.Modified;
                this.context.SaveChanges();

                return new ResultType<T>() { Value = entity };
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        errorMessage += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }

                return new ResultType<T>() { Value = null, Error = errorMessage };
            }
        }

        public ResultType<T> Delete(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                context.Entry(entity).State = EntityState.Deleted;
                context.SaveChanges();

                return new ResultType<T>() { IsSuccess = true };
            }
            catch (DbEntityValidationException dbEx)
            {

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        errorMessage += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                return new ResultType<T>() { Value = null, Error = errorMessage };
            }
        }

        public virtual IQueryable<T> Table
        {
            get
            {
                return Entities;
            }
        }

        private IDbSet<T> Entities
        {
            get
            {
                if (Entity == null)
                {
                    context.Configuration.AutoDetectChangesEnabled = false;
                    context.Configuration.LazyLoadingEnabled = false;
                    context.Configuration.ProxyCreationEnabled = false;
                    context.Configuration.ValidateOnSaveEnabled = false;

                    Entity = context.Set<T>();

                }
                return Entity;
            }
        }
    }
}
