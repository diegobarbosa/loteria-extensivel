﻿using Itix.Loteria.Core.Domain.Jogos.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Itix.Loteria.Core.Domain.Jogos.MegaSena
{
    public partial class MegaSenaJogo
    {
        public class Resultado : IResultado
        {
            public List<int> NumerosSorteados { get; protected set; }
        }
    }
}
