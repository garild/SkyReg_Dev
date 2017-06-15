using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Result.Interface
{
    public interface IDLModel<TEntity> where TEntity : class,new()
    {
        ResultType<TEntity> InsertEntity(TEntity entity,bool Attach = true);
        ResultType<TEntity> Delete(TEntity entity);
        ResultType<TEntity> Update(TEntity entity);
        TEntity GetById(object id);
        
    }
}
