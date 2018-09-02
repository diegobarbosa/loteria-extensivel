using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Itix.Loteria.Core.Infra.IocContainer
{
    public class ReflectionUtils
    {
        public List<Type> AllImplementationsFrom<IType>(List<Assembly> assemblies)
        {
            var containerType = typeof(IType);

            return assemblies
                .SelectMany(s => s.GetTypes())
                .Where(p => containerType.IsAssignableFrom(p) && p.IsClass && !p.IsAbstract)
                .ToList();

        }
    }
}
