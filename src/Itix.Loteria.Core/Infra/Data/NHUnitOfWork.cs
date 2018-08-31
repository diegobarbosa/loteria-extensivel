using System.Collections.Generic;
using System.Diagnostics;
using NHibernate;
using NHibernate.Linq;
using System.Linq;

namespace Itix.Agenda.Core.Data
{
    public class NHUnitOfWork : IUnitOfWork
    {
        #region Session

        public ISession Session { get; protected set; }

        ITransaction transaction;

        public NHUnitOfWork()
        {

        }

        public void StartTransaction()
        {
            Session = NHSessionFactory.ISessionFactory.OpenSession();
            transaction = Session.BeginTransaction();

        }

        public void Commit()
        {
            transaction.Commit();
            Session.Close();

        }

        public void RollBack()
        {

            if (transaction != null)
            {
                transaction.Rollback();
            }

            if (Session != null)
            {
                Session.Close();
            }

        }

        #endregion



        public IQueryable<T> QueryByLinq<T>() { return Session.Query<T>(); }


        public T GetById<T>(object id)
        {
            return Session.Get<T>(id);
        }


        public void Insert(object obj)
        {
            Session.Save(obj);
        }



        public void Remove<T>(object id)
        {
            var obj = Session.Get<T>(id);

            Session.Delete(obj);
        }


        public IList<T> QueryBySql<T>(string sql, string entity = null, Dictionary<string, object> parametros = null)
        {
            var query = Session.CreateSQLQuery(sql);

            if (entity != null)
            {
                query.AddEntity(entity, typeof(T));
            }

            if (parametros != null)
            {
                foreach (var item in parametros)
                {
                    query.SetParameter(item.Key, item.Value);
                }

            }

            return query.List<T>();


        }
    }
}
