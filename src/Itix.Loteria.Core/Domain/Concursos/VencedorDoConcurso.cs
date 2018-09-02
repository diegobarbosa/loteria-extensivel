using Itix.Agenda.Core.Infra.Utils;
using Itix.Loteria.Core.Domain.Apostas;
using Itix.Loteria.Core.Domain.Jogos.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Itix.Loteria.Core.Domain.Concursos
{
    public class VencedorDoConcurso
    {
        public virtual int IdVencedor { get; protected set; }
        public virtual int IdConcurso { get; protected set; }

        public virtual int IdAposta { get; protected set; }

        public virtual IAcerto Acerto { get; protected set; }


        public VencedorDoConcurso(
            int idVencedor,
            Concurso concurso,
            Aposta aposta,
            IAcerto acerto
            )
        {
            Assegure.Que(idVencedor > 0, "idVencedor inválido");

            Assegure.NaoNulo(concurso, "Concurso não informado");

            Assegure.NaoNulo(aposta, "Aposta não informada");

            Assegure.NaoNulo(acerto, "Acerto não informado");


            this.IdVencedor = idVencedor;

            this.IdConcurso = concurso.IdConcurso;

            this.IdAposta = aposta.IdAposta;

            this.Acerto = acerto;

        }
    }
}
