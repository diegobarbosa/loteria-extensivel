using System;
using System.Linq;
using System.Collections.Generic;
using NHibernate;

namespace Itix.Agenda.Core.Data
{
    public interface IUnitOfWork
    {
        void Insert(object obj);

        void StartTransaction();
        void Commit();
        void RollBack();

        ISession Session { get; }

        IQueryable<T> QueryByLinq<T>();

        T GetById<T>(object id);

        void Remove<T>(object id);


        IList<T> QueryBySql<T>(string sql, string entity = null, Dictionary<string, object> parametros = null);


    }
}
