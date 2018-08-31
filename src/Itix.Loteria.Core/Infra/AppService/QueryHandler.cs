using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Itix.Agenda.Core.Infra.AppService
{
    public abstract class QueryHandler<T> where T : IQueryCommand
    {

        public abstract void Query(T form);

        public abstract void Build(T form);

    }

    public interface IQueryCommand
    {


    }
}
