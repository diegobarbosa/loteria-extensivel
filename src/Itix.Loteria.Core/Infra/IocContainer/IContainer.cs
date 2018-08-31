using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Itix.Agenda.Core.Infra.IocContainer
{
    public interface IContainer
    {
        T GetInstance<T>() where T : class;

        IEnumerable<T> GetAllInstances<T>() where T : class;


        bool IsTypeRegistered<T>() where T : class;

        object GetInstance(Type type);

        SimpleInjector.Container GetSimpleInjectorContainer();

    }
}
