using System;
using System.Collections.Generic;
using System.Text;

namespace Itix.Loteria.Core.Domain.Jogos
{
    public interface IJogo
    {
        int IdJogo { get; }

        string CodigoJogo { get; }

        string Nome { get; }

        JogoTipoStatus Status { get; }

        string Descricao { get; }



        void ValidarVolante<IVol>(IVol volante);

        IAcer1 ApostaVencedora<IVol1, IResult1, IAcer1>(IResult1 resultado, IVol1 volante) where IAcer1 : class;


    }

    public enum JogoTipoStatus
    {
        ATV,

        CANC
    }

}
