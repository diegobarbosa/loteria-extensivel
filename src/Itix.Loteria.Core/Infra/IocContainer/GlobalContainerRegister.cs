using Itix.Agenda.Core.Data;
using Itix.Agenda.Core.Infra.AppService;
using SimpleInjector;


namespace Itix.Agenda.Core.Infra.IocContainer
{
    public class GlobalContainerRegister : IContainerRegister
    {
        public override void Register(Container container)
        {

           
            container.Register<IAppDomainAdapter, AppDomainAdapter>();


            container.RegisterSingleton<IAssembliesItix, AssembliesItix>();

        }

    }

}