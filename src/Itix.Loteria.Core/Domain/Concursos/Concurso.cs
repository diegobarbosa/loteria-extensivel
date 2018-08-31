using Itix.Agenda.Core.Infra.Utils;
using Itix.Loteria.Core.Domain.Jogos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Itix.Loteria.Core.Domain.Concursos
{
    public class Concurso
    {
        public virtual int IdConcurso { get;  set; }

        public virtual int IdJogo { get;  set; }

        public virtual int Codigo { get;  set; }

        public virtual EnumStatusConcurso Status { get;  set; }

        //public Concurso(int idConcurso, IJogo jogo, int codigo)
        //{
        //    Assegure.Que(idConcurso > 0, "idConcurso inválido");

        //    Assegure.NaoNulo(jogo, "Jogo não informado");

        //    Assegure.Que(codigo > 0, "Codigo inválido");


        //    this.IdConcurso = idConcurso;

        //    this.IdJogo = jogo.IdJogo;

        //    this.Codigo = codigo;

        //    this.Status = EnumStatusConcurso.ABT;

        //}
    }


    public enum EnumStatusConcurso
    {
        ABT,
        CONC
    }

}
