using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using System.Configuration;
using Itix.Agenda.Core.Infra;

namespace Itix.Agenda.Core.Data
{
    public class NHSessionFactory
    {
        public static ISessionFactory ISessionFactory { get; private set; }

        public static void Configure()
        {
            ISessionFactory = CreateSessionFactory();
        }


        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
              .Database(
                MsSqlConfiguration
                .MsSql2012
                .ConnectionString(AppConfig.ConnectionString)
                .ShowSql()
                .FormatSql()
              )
              .ExposeConfiguration(x => { x.SetInterceptor(new LoggingInterceptor()); })

              .Mappings(m => m.FluentMappings.AddFromAssemblyOf<NHSessionFactory>())

              .BuildSessionFactory();
        }




    }
}
