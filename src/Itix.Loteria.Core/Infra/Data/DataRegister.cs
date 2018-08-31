using Itix.Agenda.Core.Data;
using Itix.Agenda.Core.Infra.IocContainer;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Text;

namespace Itix.Agenda.Core.Infra.Data
{
    public class DataRegister : IContainerRegister
    {
        public override void Register(SimpleInjector.Container container)
        {
            container.Register<IUnitOfWork, NHUnitOfWork>(Lifestyle.Scoped);

            NHSessionFactory.Configure();
        }
    }
}