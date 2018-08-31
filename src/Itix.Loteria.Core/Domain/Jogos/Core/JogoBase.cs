using Itix.Loteria.Core.Domain.Jogos.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Itix.Loteria.Core.Domain.Jogos
{
    public abstract class JogoBase<IVol, IResult, IAcer>: IJogo
        where IVol : IVolante
        where IResult : IResultado
        where IAcer : IAcerto
        
    {
        public virtual int IdJogo { get; protected set; }

        public virtual string CodigoJogo { get; protected set; }
        public virtual string Nome { get; protected set; }
        public virtual JogoTipoStatus Status { get; protected set; }
        public virtual string Descricao { get; protected set; }


        public abstract void ValidarVolante(IVol volante);

        public abstract IAcer ApostaVencedora(IResult resultado, IVol volante);





    }
}
