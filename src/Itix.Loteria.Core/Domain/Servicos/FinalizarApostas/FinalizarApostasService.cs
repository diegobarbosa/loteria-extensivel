using Itix.Agenda.Core.Infra.Utils;
using Itix.Loteria.Core.Domain.Apostas;
using Itix.Loteria.Core.Domain.Concursos;
using Itix.Loteria.Core.Domain.Jogos.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Itix.Loteria.Core.Domain.Servicos
{
    public class FinalizarApostasService
    {
        IConcursoRepo concursoRepo;

        IJogoRepo jogoRepo;

        IApostaRepo apostaRepo;

        ISequenceGenerator sequenceGenerator;

        public FinalizarApostasService(
            IConcursoRepo concursoRepo,
            IJogoRepo jogoRepo,
            IApostaRepo apostaRepo,
            ISequenceGenerator sequenceGenerator
            )
        {
            this.concursoRepo = concursoRepo;

            this.jogoRepo = jogoRepo;

            this.apostaRepo = apostaRepo;

            this.sequenceGenerator = sequenceGenerator;
        }

        public void Executar(Command command)
        {

            Assegure.Que(command.IdJogo > 0, "Informe o Jogo");

            Assegure.NaoNulo(command.Apostas, "Nenhuma Aposta");


            var concurso = concursoRepo.AtivoByIdJogo(command.IdJogo);

            Assegure.NaoNulo(concurso, "Concurso não encontrado");


            var jogo = jogoRepo.GetByIdJogo(command.IdJogo);

           

            var dataOcorrencia = DateTime.Now;
            var type = typeof(Aposta);

            foreach (var apostaDto in command.Apostas)
            {
                var idAposta = sequenceGenerator.NextIdFor(type);

                var newAposta = new Aposta(
                             idAposta,
                             concurso,
                             jogo,
                             dataOcorrencia,
                             apostaDto.Jogador,
                             apostaDto.Volante
                         );


                apostaRepo.Insert(newAposta);
            }



        }


        public class Command
        {
            public int IdJogo { get; set; }

            public List<ApostaDto> Apostas { get; set; }


            public class ApostaDto
            {
                public string Jogador { get; set; }

                public IVolante Volante { get; set; }
            }

        }

    }


}
