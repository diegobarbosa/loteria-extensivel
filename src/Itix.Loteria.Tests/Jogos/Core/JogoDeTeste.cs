using Itix.Loteria.Core.Domain.Jogos;
using Itix.Loteria.Core.Domain.Jogos.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Itix.Loteria.Tests.Apostas
{
    public class JogoDeTeste : JogoBase<JogoDeTeste.Volante, JogoDeTeste.Resultado, JogoDeTeste.Acerto>
    {
        protected override Acerto ApostaVencedoraTemplate(Resultado resultado, Volante volante)
        {
            return new Acerto();
        }

        protected override void ValidarVolanteTemplate(Volante volante)
        {

        }

        public class Acerto : IAcerto { }

        public class Resultado : IResultado { }

        public class Volante : IVolante { }
    }
}
