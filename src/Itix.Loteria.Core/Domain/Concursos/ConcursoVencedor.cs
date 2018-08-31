using Itix.Agenda.Core.Infra.Utils;
using Itix.Loteria.Core.Domain.Apostas;
using Itix.Loteria.Core.Domain.Jogos.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Itix.Loteria.Core.Domain.Concursos
{
    public class ConcursoVencedor
    {
        public virtual int IdConcursoVencedor { get; protected set; }
        public virtual int IdConcurso { get; protected set; }

        public virtual int IdAposta { get; protected set; }

        public virtual IAcerto Acerto { get; protected set; }


        public ConcursoVencedor(
            int idConcursoVencedor,
            Concurso concurso,
            Aposta aposta,
            IAcerto acerto
            )
        {
            Assegure.Que(idConcursoVencedor > 0, "idConcursoVencedor inválido");

            Assegure.NaoNulo(concurso, "Concurso não informado");

            Assegure.NaoNulo(aposta, "Aposta não informada");

            Assegure.NaoNulo(acerto, "Acerto não informado");


            this.IdConcursoVencedor = idConcursoVencedor;

            this.IdConcurso = concurso.IdConcurso;

            this.IdAposta = aposta.IdAposta;

            this.Acerto = acerto;

        }
    }
}
