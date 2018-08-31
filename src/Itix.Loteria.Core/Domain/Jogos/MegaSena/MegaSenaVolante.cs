using Itix.Loteria.Core.Domain.Jogos.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Itix.Loteria.Core.Domain.Jogos.MegaSena
{
    public partial class MegaSenaJogo
    {
        public class Volante : IVolante
        {
            public Volante()
            {
                NumerosSelecionados = new List<int>();
            }

            public List<int> NumerosSelecionados { get; protected set; }
        }
    }
}
