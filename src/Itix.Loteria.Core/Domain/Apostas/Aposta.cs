using Itix.Agenda.Core.Infra.Utils;
using Itix.Loteria.Core.Domain.Concursos;
using Itix.Loteria.Core.Domain.Jogos;
using Itix.Loteria.Core.Domain.Jogos.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Itix.Loteria.Core.Domain.Apostas
{
    public class Aposta
    {
        public virtual int IdAposta { get; protected set; }

        public virtual int IdConcurso { get; protected set; }

        public virtual int IdJogo { get; protected set; }

        public virtual DateTime DataOcorrencia { get; protected set; }

        public virtual IVolante Volante { get; protected set; }


        protected Aposta(
            int idAposta,
            Concurso concurso,
            IJogo jogo,
            DateTime dataOcorrencia,
            IVolante volante
            )
        {
            Assegure.Que(idAposta > 0, "idAposta inválida");

            Assegure.NaoNulo(concurso, "Informe o Concurso");

            Assegure.NaoNulo(jogo, "Informe o Jogo");

            Assegure.EhDataValida(dataOcorrencia, () => "Data da Ocorrência inválida");

            Assegure.NaoNulo(volante, "Informe o volante");


            this.IdAposta = idAposta;

            this.IdConcurso = concurso.IdConcurso;

            this.IdJogo = jogo.IdJogo;

            this.DataOcorrencia = dataOcorrencia;

            this.Volante = volante;


        }





    }
}
