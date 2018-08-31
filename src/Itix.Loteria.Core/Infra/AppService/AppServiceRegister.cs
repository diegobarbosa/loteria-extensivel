using Itix.Agenda.Core.Infra.IocContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itix.Agenda.Core.Infra.AppService
{
    public class AppServiceRegister : IContainerRegister
    {
        public override void Register(SimpleInjector.Container container)
        {

           new AssembliesItix()
      .GetAssemblies()
      .ForEach(assembly =>
      {

          container.Register(typeof(CommandHandler<>), new[] { assembly });

          container.Register(typeof(QueryHandler<>), new[] { assembly });

      });

        }
    }
}
