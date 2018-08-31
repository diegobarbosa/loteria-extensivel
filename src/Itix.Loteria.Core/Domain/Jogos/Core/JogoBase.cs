using Itix.Loteria.Core.Domain.Jogos.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Itix.Loteria.Core.Domain.Jogos
{
    public abstract class JogoBase<IVol, IResult, IAcer> : IJogo
        where IVol : class, IVolante
        where IResult : class, IResultado
        where IAcer : class, IAcerto

    {
        public virtual int IdJogo { get; protected set; }

        public virtual string CodigoJogo { get; protected set; }

        public virtual string Nome { get; protected set; }

        public virtual JogoTipoStatus Status { get; protected set; }

        public virtual string Descricao { get; protected set; }




        protected abstract IAcer ApostaVencedoraTemplate(IResult resultado, IVol volante);

        protected abstract void ValidarVolanteTemplate(IVol volante);


        public void ValidarVolante<IVol1>(IVol1 volante)
        {
            this.ValidarVolanteTemplate(volante as IVol);
        }

        public IAcer1 ApostaVencedora<IVol1, IResult1, IAcer1>(IResult1 resultado, IVol1 volante) where IAcer1 : class
        {
            return this.ApostaVencedoraTemplate(resultado as IResult, volante as IVol) as IAcer1;
        }

        protected JogoBase()
        {
            this.Status = JogoTipoStatus.ATV;
        }


    }

}
