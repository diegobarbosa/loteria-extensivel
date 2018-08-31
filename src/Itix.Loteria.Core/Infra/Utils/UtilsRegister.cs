using Itix.Agenda.Core.Infra.IocContainer;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Text;

namespace Itix.Agenda.Core.Infra.Utils
{
    public class UtilsRegister : IContainerRegister
    {
        public override void Register(Container container)
        {
            container.Register<ITimeProvider, TimeProvider>();
        }
    }
}
