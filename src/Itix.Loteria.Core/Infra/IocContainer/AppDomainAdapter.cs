using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Itix.Agenda.Core.Infra.IocContainer
{
    public interface IAppDomainAdapter
    {
        List<Assembly> GetAssemblies();
    }

    public class AppDomainAdapter : IAppDomainAdapter
    {
        public List<Assembly> GetAssemblies()
        {
            return AppDomain
                  .CurrentDomain
                  .GetAssemblies()
                  .ToList();
        }
    }
}
