using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_EF_Template.Repositories.Interfaces;
using MVC_EF_Template.DAL;
using System.Data;

namespace MVC_EF_Template.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        #region Properties

        DatabaseContext _context = new DatabaseContext();

        internal IDbConnection Connection
        {
            get;
            private set;
        }

        internal IDbTransaction Transaction
        {
            get;
            private set;
        }

        #endregion

        #region Constructor

        public Repository()
        {
            //this.Connection = connection;
        }

        #endregion

        #region Methods

        public virtual void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public virtual void Update(TEntity entity, int id)
        {
            if (entity == null)
                return;

            TEntity existing = _context.Set<TEntity>().Find(id);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(entity);
                _context.SaveChanges();
            }
            return;
        }

        public virtual void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }

        public virtual TEntity GetByID(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        protected virtual IDbConnection GetConnection()
        {
            IDbConnection conn = Connection;
            if (conn != null && conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }

        public virtual IDbTransaction BeginTransaction()
        {
            if (Transaction == null)
            {
                IDbConnection conn = GetConnection();
                Transaction = conn.BeginTransaction();
            }
            return Transaction;
        }

        public virtual IDbTransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            if (Transaction == null)
            {
                IDbConnection conn = GetConnection();
                Transaction = conn.BeginTransaction(isolationLevel);
            }
            return Transaction;
        }

        public virtual void SetTransaction(IDbTransaction transaction)
        {
            if (transaction != null)
            {
                Transaction = transaction;
                Connection = transaction.Connection;
            }
        }

        public void Dispose()
        {
            if (Transaction != null)
                Transaction.Dispose();

            if (Connection != null && Connection.State != ConnectionState.Closed)
            {
                Connection.Close();
            }

            Transaction = null;
        }

        #endregion

    }
}