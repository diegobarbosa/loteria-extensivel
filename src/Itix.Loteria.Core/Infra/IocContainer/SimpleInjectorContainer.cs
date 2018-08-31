using System;
using System.Collections.Generic;

namespace Itix.Agenda.Core.Infra.IocContainer
{
    public class SimpleInjectorContainer : IContainer
    {
        SimpleInjector.Container container;

        public SimpleInjectorContainer(SimpleInjector.Container container)
        {
            this.container = container;
        }

        public T GetInstance<T>() where T : class
        {
            return container.GetInstance<T>();
        }

        public IEnumerable<T> GetAllInstances<T>() where T : class
        {
            return container.GetAllInstances<T>();
        }


        public bool IsTypeRegistered<T>() where T : class
        {
            return container.GetRegistration(typeof(T), false) != null;
        }

        public object GetInstance(Type type)
        {
            return container.GetInstance(type);
        }

        public SimpleInjector.Container GetSimpleInjectorContainer()
        {
            return container;
        }
    }
}
