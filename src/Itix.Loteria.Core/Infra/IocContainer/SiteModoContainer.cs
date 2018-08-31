using Sic.Core.Model.DAL;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itix.Agenda.Core.Infra.IocContainer
{
    public class SiteModoContainer
    {
        public List<Type> Tipos { get; set; } = new List<Type>();

        AssembliesAPP assembliesSIC;

        Container container;

        public SiteModoContainer(AssembliesAPP assembliesSIC, Container container)
        {
            this.assembliesSIC = assembliesSIC;

            this.container = container;
        }

        public void RegisterType<T>() where T : class
        {

            var tipoDaInterface = typeof(T);

            var types = assembliesSIC.GetAssembliesSIC()
              .SelectMany(s => s.GetTypes())
              .Where(p => tipoDaInterface.IsAssignableFrom(p) && p.IsClass && !p.IsAbstract);

            Tipos.AddRange(types);
        }

        public T GetInstance<T>()
        {
            var siteModo = container.GetInstance<IConfiguracaoRepository>().SiteModo();

            var tipoDaInterface = typeof(T);

            var classeConcreta = Tipos
             .Where(p => tipoDaInterface.IsAssignableFrom(p) && p.Name.EndsWith($"_{siteModo}", StringComparison.OrdinalIgnoreCase))
             .Single();


            return (T)container.GetInstance(classeConcreta);
        }
    }
}
