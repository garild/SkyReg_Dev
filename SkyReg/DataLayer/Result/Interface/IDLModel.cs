using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Result.Interface
{
    public interface IDLModel<TEntity> where TEntity : class,new()
    {
        ResultType<TEntity> Insert(TEntity entity);
        ResultType<TEntity> Delete(TEntity entity);
        ResultType<TEntity> Update(TEntity entity);
        TEntity GetById(object id);
    }
}
