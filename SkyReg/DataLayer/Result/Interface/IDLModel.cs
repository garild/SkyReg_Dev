using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Result.Interface
{
    public interface IDLModel<TEntity> where TEntity : class,new()
    {
        ResultType<TEntity> Add(TEntity data);
        ResultType<TEntity> Delete(TEntity data);
        ResultType<TEntity> Update(TEntity data);
    }
}
