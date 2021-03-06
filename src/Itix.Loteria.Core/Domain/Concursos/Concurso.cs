﻿using Itix.Agenda.Core.Infra.Utils;
using Itix.Loteria.Core.Domain.Apostas;
using Itix.Loteria.Core.Domain.Jogos;
using Itix.Loteria.Core.Domain.Jogos.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Itix.Loteria.Core.Domain.Concursos
{
    public class Concurso
    {
        public virtual int IdConcurso { get; set; }

        public virtual int IdJogo { get; set; }

        public virtual int Codigo { get; set; }

        public virtual EnumStatusConcurso Status { get; set; }

        public virtual DateTime DataConclusao { get; protected set; }

        public virtual IResultado Resultado { get; protected set; }


        public virtual void Finalizar(FinalizarCommand command)
        {
            Assegure.Que(this.IdJogo == command.Jogo.IdJogo, "Jogo inválido");

            Assegure.NaoNulo(command.Resultado, "Informe o Resultado");

            Assegure.NaoNulo(command.Apostas, "Apostas é null");

            Assegure.Que(command.Apostas.Count > 0, "Nenhuma aposta informada");


            command.Apostas.ForEach(aposta =>
                aposta.ComputarResultado(command.DataConclusao, command.Resultado, command.Jogo));


            this.Status = EnumStatusConcurso.CONC;

            this.DataConclusao = command.DataConclusao;

            this.Resultado = command.Resultado;
        }

        public class FinalizarCommand
        {
            public IJogo Jogo { get; set; }

            public DateTime DataConclusao { get; set; }

            public IResultado Resultado { get; set; }

            public List<Aposta> Apostas { get; set; }
        }

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
