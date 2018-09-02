using Itix.Agenda.Core.Infra.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Itix.Loteria.Core.Domain.Jogos.MegaSena
{
    public partial class MegaSenaJogo : JogoBase<MegaSenaJogo.Volante, MegaSenaJogo.Resultado, MegaSenaJogo.Acerto>
    {

        /// <summary>
        /// Em uma app real esses dados viriam do banco;
        /// Preferi deixar diretamente no código ....
        /// </summary>
        public MegaSenaJogo()
        {
            this.Regras = new RegrasJogo();

            this.IdJogo = 1;

            this.CodigoJogo = "megasena";

            this.Nome = "Mega Sena";

            this.Descricao = "A Mega-Sena paga milhões para o acertador dos 6 números sorteados. Ainda é possível ganhar prêmios ao acertar 4 ou 5 números dentre os 60 disponíveis no volante de apostas.";
        }



        public virtual RegrasJogo Regras { get; protected set; }

        protected override Acerto ApostaVencedoraTemplate(Resultado resultado, Volante volante)
        {
            Assegure.NaoNulo(resultado, "Informe o resultado");

            Assegure.NaoNulo(volante, "Informe o volante");


            var intersect = volante.NumerosSelecionados.Intersect(resultado.NumerosSorteados).ToList();

            if (intersect.Count() == 6
                || intersect.Count() == 5
                || intersect.Count() == 4)
            {
                return new Acerto(intersect);
            }


            return null;

        }

        protected override void ValidarVolanteTemplate(Volante volante)
        {
            Assegure.Que(volante.NumerosSelecionados.Count == Regras.QuantidadeDeNumerosDoVolante,
                () => $"Volante inválido. Deve ter {Regras.QuantidadeDeNumerosDoVolante} números");
        }





    }



}
