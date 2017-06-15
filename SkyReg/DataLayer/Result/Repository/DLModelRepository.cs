using DataLayer.Result.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;

namespace DataLayer.Result.Repository
{
    public class DLModelRepository<T> : DbContext ,IDLModel<T> where T : class, new() //TODO zmienić obsługę błędów
    {
        private readonly DLModelContainer context = new DLModelContainer();
        private IDbSet<T> Entity;

        string errorMessage = string.Empty;

        public DLModelRepository()
        {
            
        }

        public T GetById(object id)
        {
            return Entities.Find(id);
        }

        /// <summary>
        /// Attach with FALSE :Insert new Entity data object with references and associations class,
        /// attach with TRUE :Add new Entity data where references and associations class does not exists
        /// 
        /// </summary>

        public ResultType<T> InsertEntity(T entity, bool Attach = true)
        {
            try
            {
                if (entity == null)
                {
                    return new ResultType<T>() { Value = null };
                }

                if (Attach)
                    this.Entities.Attach(entity);
                this.Entities.Add(entity);

                this.context.SaveChanges();

                return new ResultType<T>() { Value = entity };
            }
            catch (DbUpdateException ex)
            {
                errorMessage = ex.InnerException?.Message;
                return new ResultType<T>() { Value = null, Error = errorMessage };
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

        /// <summary>
        ///  Insert multi Entity objects at one
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ColletionResult<T> InsertMany(List<T> entity)
        {
            try
            {
                if (entity?.Count == 0)
                {
                    return new ColletionResult<T>() { Value = null };
                }
                entity.ForEach(p =>
                {
                    this.Entities.Attach(p);
                    this.Entities.Add(p);
                    });
                this.context.SaveChanges();

                return new ColletionResult<T>() { Value = entity };
            }
            catch (DbUpdateException ex)
            {
                errorMessage = ex.InnerException?.Message;
                return new ColletionResult<T>() { Value = null, Error = errorMessage };
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
            catch (DbUpdateException ex)
            {
                errorMessage = ex.InnerException?.Message;
                return new ColletionResult<T>() { Value = null, Error = errorMessage };
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
            catch (DbUpdateException ex)
            {
                errorMessage = ex.InnerException?.Message;
                return new ResultType<T>() { Value = null, Error = errorMessage };
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
            catch (DbUpdateException ex)
            {
                errorMessage = ex.InnerException?.Message;
                return new ResultType<T>() { Value = null, Error = errorMessage };
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
