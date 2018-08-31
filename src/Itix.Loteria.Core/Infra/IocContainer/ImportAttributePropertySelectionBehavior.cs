using SimpleInjector.Advanced;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Itix.Agenda.Core.Infra.IocContainer
{
    public class ImportAttributePropertySelectionBehavior : IPropertySelectionBehavior
    {
        public bool SelectProperty(Type serviceType, PropertyInfo propertyInfo)
        {
            // Makes use of the System.ComponentModel.Composition assembly
            return typeof(Page).IsAssignableFrom(serviceType) &&
                propertyInfo.GetCustomAttributes<ImportAttribute>().Any();
        }
    }
}
