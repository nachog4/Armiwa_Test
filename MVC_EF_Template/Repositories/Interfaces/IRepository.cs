using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MVC_EF_Template.Repositories.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class, new()
    {
        void Add(TEntity entity);

        void Remove(TEntity entity);

        void Update(TEntity entity, int id);

        TEntity GetByID(int id);

        IDbTransaction BeginTransaction();

        IDbTransaction BeginTransaction(IsolationLevel isolationLevel);

        void SetTransaction(IDbTransaction transaction);
    }
}
