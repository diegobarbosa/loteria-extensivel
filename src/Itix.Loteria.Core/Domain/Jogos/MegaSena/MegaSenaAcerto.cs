using Itix.Loteria.Core.Domain.Jogos.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Itix.Loteria.Core.Domain.Jogos.MegaSena
{
    public partial class MegaSenaJogo
    {
        public class Acerto : IAcerto
        {
            public int QuantidadeDeAcertos { get; protected set; }

            public List<int> Numeros { get; protected set; }

            public Acerto()
            {

            }

            public Acerto(List<int> numeros)
            {
                this.Numeros = numeros;

                this.QuantidadeDeAcertos = numeros.Count;
            }
        }
    }
}
