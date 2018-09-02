using Itix.Agenda.Core.Infra.IocContainer;
using Itix.Loteria.Core.Domain.Apostas;
using Itix.Loteria.Core.Domain.Concursos;
using Itix.Loteria.Core.Domain.Jogos.Core;
using Itix.Loteria.Core.Domain.Servicos;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Text;

namespace Itix.Loteria.Core.Domain
{
    public class DomainRegister : IContainerRegister
    {
        public override void Register(Container container)
        {
            container.RegisterSingleton<IApostaRepo, ApostaRepo>();

            container.RegisterSingleton<IConcursoRepo, ConcursoRepo>();

            container.RegisterSingleton<IConcursoVencedorRepo, VencedorDoConcursoRepo>();

            container.RegisterSingleton<IJogoRepo, JogoRepo>();

            container.RegisterSingleton<ISequenceGenerator, SequenceGenerator>();
        }
    }
}
