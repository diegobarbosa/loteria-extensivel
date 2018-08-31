using Sic.Core.Model.DAL;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itix.Agenda.Core.Infra.IocContainer
{
    public static class SimpleInjectorExtensions
    {
        /// <summary>
        /// Registra um tipo para ser retornado baseado no SiteModo atual.
        /// 
        /// IMumpsClient retornada IMumpsClient_Serasa ou IMumpsClient_Paralelo
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static void Register_SiteModo_Based<T>(this Container container) where T : class
        {
            StaticContainer.SiteModoContainer.RegisterType<T>();


            container.Register<T>(() =>
                StaticContainer.SiteModoContainer.GetInstance<T>()
            );
        }




    }
}
