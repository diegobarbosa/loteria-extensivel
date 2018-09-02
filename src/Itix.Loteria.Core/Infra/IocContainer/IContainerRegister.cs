using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itix.Agenda.Core.Infra.IocContainer
{
    public abstract class IContainerRegister
    {
        public IAssembliesItix Assemblies { get; set; }

        public abstract void Register(Container container);

        public virtual void OnRegisterCompleted(Container container)
        {

        }

    }
}
