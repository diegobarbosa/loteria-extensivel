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

        public virtual string Jogador { get; protected set; }

        public virtual IVolante Volante { get; protected set; }

        public virtual IAcerto Acerto { get; protected set; }

        public virtual StatusAcerto AcertoStatus { get; protected set; }

        public virtual StatusProcessamentoAposta StatusProcessamento { get; protected set; }

        public virtual DateTime? DataComputou { get; protected set; }





        public Aposta(
                int idAposta,
                Concurso concurso,
                IJogo jogo,
                DateTime dataOcorrencia,
                string jogador,
                IVolante volante
                )
        {
            Assegure.Que(idAposta > 0, "idAposta inválida");

            Assegure.NaoNulo(concurso, "Informe o Concurso");

            Assegure.NaoNulo(jogo, "Informe o Jogo");

            Assegure.EhDataValida(dataOcorrencia, () => "Data da Ocorrência inválida");

            Assegure.NaoNulo(volante, "Informe o volante");


            jogo.ValidarVolante(volante);


            this.IdAposta = idAposta;

            this.IdConcurso = concurso.IdConcurso;

            this.IdJogo = jogo.IdJogo;

            this.DataOcorrencia = dataOcorrencia;

            this.Jogador = jogador;

            this.Volante = volante;

            this.StatusProcessamento = StatusProcessamentoAposta.FEITA;

            this.AcertoStatus = StatusAcerto.INIC;

        }

        public virtual void ComputarResultado(DateTime dataComputou, IResultado resultado, IJogo jogo)
        {
            Assegure.Que(this.IdJogo == jogo.IdJogo, "Jogo inválido");

            Assegure.NaoNulo(resultado, "Informe o resultado");

            Assegure.NaoNulo(jogo, "Informe o jogo");


            this.Acerto = jogo.ComputarAposta(resultado, Volante);

            this.AcertoStatus = this.Acerto == null ? StatusAcerto.ERR : StatusAcerto.VENC;


            this.StatusProcessamento = StatusProcessamentoAposta.COMP;

            this.DataComputou = dataComputou;
        }


    }

    public enum StatusProcessamentoAposta
    {
        FEITA,
        COMP
    }

    public enum StatusAcerto
    {
        INIC,
        VENC,
        ERR
    }
}
