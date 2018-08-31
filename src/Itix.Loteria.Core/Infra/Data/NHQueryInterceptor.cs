using NHibernate;
using NHibernate.SqlCommand;
using System.Data.SqlTypes;
using System.Diagnostics;

namespace Itix.Agenda.Core.Data
{
    public class LoggingInterceptor : EmptyInterceptor
    {
        public override NHibernate.SqlCommand.SqlString OnPrepareStatement(NHibernate.SqlCommand.SqlString sql)
        {
            Debug.WriteLine(sql);

            return base.OnPrepareStatement(sql);
        }

    }
}