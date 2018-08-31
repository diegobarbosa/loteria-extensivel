using System;
using System.Collections.Generic;
using System.Text;

namespace Itix.Loteria.Core.Domain.Jogos.MegaSena
{
    public partial class MegaSenaJogo
    {
        public class RegrasJogo
        {
            public int Quantidade_Maxima_De_Numeros_Disponiveis_Para_Selecionar { get => 60; }

            public int QuantidadeDeNumerosDoVolante { get => 6; }


            public int QuantidadeDeNumerosASortear { get => 6; }
        }
    }
}
