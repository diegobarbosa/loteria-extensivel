using Itix.Agenda.Core.Infra.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Itix.Loteria.Core.Domain.Jogos.MegaSena
{
    public partial class MegaSenaJogo : JogoBase<MegaSenaJogo.Volante, MegaSenaJogo.Resultado, MegaSenaJogo.Acerto>
    {

        public virtual RegrasJogo Regras { get; protected set; }

        public override Acerto ApostaVencedora(Resultado resultado, Volante volante)
        {
            var intersect = volante.NumerosSelecionados.Intersect(resultado.NumerosSorteados).ToList();

            if (intersect.Count() == 6
                || intersect.Count() == 5
                || intersect.Count() == 4)
            {
                return new Acerto(intersect);
            }


            return null;

        }

        public override void ValidarVolante(Volante volante)
        {
            Assegure.Que(volante.NumerosSelecionados.Count == Regras.QuantidadeDeNumerosDoVolante,
                () => $"Volante inválido. Deve ter {Regras.QuantidadeDeNumerosDoVolante} números");
        }





    }



}
