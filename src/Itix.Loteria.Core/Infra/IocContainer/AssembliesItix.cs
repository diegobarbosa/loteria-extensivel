using Itix.Agenda.Core.Infra.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Itix.Agenda.Core.Infra.IocContainer
{
    public interface IAssembliesItix
    {
        List<Assembly> GetAssemblies();
    }

    public class AssembliesItix : IAssembliesItix
    {
        private List<Assembly> assemblyCache;

        private List<string> appAssemblyesNames;


        public const string CoreAssemblyName = "Itix.Loteria.Core";

        private const string SiteAssemblyName = "Itix.Loteria.UI";


        IAppDomainAdapter appDomainAdapter;


        private AssembliesItix(IAppDomainAdapter appDomainAdapter)
        {
            this.appDomainAdapter = appDomainAdapter;


            assemblyCache = new List<Assembly>();

            appAssemblyesNames = new List<string>
            {
                SiteAssemblyName
               

            };

        }


        public AssembliesItix()
            : this(new AppDomainAdapter())
        {

        }

     
        public List<Assembly> GetAssemblies()
        {
            if (assemblyCache.Any())
            {
                return assemblyCache;
            }


            this.assemblyCache.Add(GetAssemblyDoSiteAtual());

            this.assemblyCache.Add(GetCoreAssembly());


            /// OU Core e Admin
            /// OU Core e Boleto
            /// OU Core e Ecommerce 

            /// Depende do Site que está executando


            Assegure.Que(appAssemblyesNames.Contains(this.assemblyCache[0].GetName().Name), "Assembly Principal do Site atual não encontrado");

            Assegure.Que(this.assemblyCache[1].GetName().Name == CoreAssemblyName, string.Format("O Assembly {0} não foi encontrado", CoreAssemblyName));


            return this.assemblyCache;
        }


        /// <summary>
        /// Deve retornar Core
        /// </summary>
        /// <returns></returns>
        private Assembly GetCoreAssembly()
        {
            var coreAsssembly = appDomainAdapter
             .GetAssemblies()
             .Where(a => a.GetName().Name == CoreAssemblyName)
             .Single();

            return coreAsssembly;
        }


        /// <summary>
        /// Deve retornar Admin ou Boleto ou ECommerce
        /// </summary>
        /// <returns></returns>
        private Assembly GetAssemblyDoSiteAtual()
        {
            var appAsssembly = appDomainAdapter
             .GetAssemblies()
             .Where(a => appAssemblyesNames.Contains(a.GetName().Name))
             .Single();


            return appAsssembly;
        }

      
    }


    

}
