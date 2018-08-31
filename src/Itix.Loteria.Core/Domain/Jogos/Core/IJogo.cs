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
    }

    public enum JogoTipoStatus
    {
        ATV,

        CANC
    }

}
