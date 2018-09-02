using Itix.Agenda.Core.Infra.IocContainer;
using Itix.Loteria.Core.Domain.Jogos.MegaSena;
using System;
using System.Collections.Generic;
using System.Text;

namespace Itix.Loteria.Core.Domain.Jogos.Core
{
    public interface IResultadoService
    {
        IResultado GetResultado(IJogo jogo);
    }

    public class ResultadoService : IResultadoService
    {
        IContainer container;

        public ResultadoService(IContainer container)
        {
            this.container = container;
        }

        public IResultado GetResultado(IJogo jogo)
        {
            ///TODO implementar com reflection

            if (jogo is MegaSenaJogo)
            {
                return container.GetInstance<MegaSenaResultadoService>().GetResultado(jogo);
            }

            return null;
        }
    }
}
