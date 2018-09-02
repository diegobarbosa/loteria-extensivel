using Itix.Agenda.Core.Infra.Utils;
using Itix.Loteria.Core.Domain.Apostas;
using Itix.Loteria.Core.Domain.Concursos;
using Itix.Loteria.Core.Domain.Jogos.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Itix.Loteria.Core.Domain.Servicos.ProcessarConcursos
{
    public class ProcessarConcursoService
    {
        IConcursoRepo concursoRepo;

        IApostaRepo apostaRepo;

        IJogoRepo jogoRepo;

        IResultadoService resultadoService;


        public ProcessarConcursoService(
            IConcursoRepo concursoRepo,
            IApostaRepo apostaRepo,
            IJogoRepo jogoRepo,
            IResultadoService resultadoService
            )
        {
            this.concursoRepo = concursoRepo;

            this.apostaRepo = apostaRepo;

            this.jogoRepo = jogoRepo;

            this.resultadoService = resultadoService;
        }


        public void Executar(int idConcurso)
        {
            var concurso = concursoRepo.AtivoByIdConcurso(idConcurso);

            Assegure.NaoNulo(concurso, "idConcurso não encontrado");


            var apostas = apostaRepo.ByIdConcurso(concurso.IdConcurso);

            var jogo = jogoRepo.GetByIdJogo(concurso.IdJogo);

            var resultado = resultadoService.GetResultado(jogo);


            var finalizarCommand = new Concurso.FinalizarCommand
            {
                Apostas = apostas,
                DataConclusao = DateTime.Now,
                Resultado = resultado
            };

            /// em um cenário real a implementação seria outra.
            /// Primeiro que não seria em uma thread web e sim em uma fila...

            concurso.Finalizar(finalizarCommand);


        }
    }
}
