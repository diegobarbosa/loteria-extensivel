using Itix.Loteria.Core.Domain.Apostas;
using Itix.Loteria.Core.Domain.Concursos;
using Itix.Loteria.Core.Domain.Jogos;
using Itix.Loteria.Core.Domain.Jogos.MegaSena;
using NSubstitute;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xunit;

namespace Itix.Loteria.Tests.Apostas
{
    public class ApostaFacts
    {
        [Fact]
        void cria_com_sucesso()
        {
            var concurso = Substitute.For<Concurso>();
            concurso.IdConcurso.Returns(10);


            var volante = Substitute.For<MegaSenaJogo.Volante>();

            var data = DateTime.Now;

            var jogo = Substitute.For<IJogo>();
            jogo.IdJogo.Returns(2);


            var aposta = new Aposta(
                1,
                concurso,
                jogo,
                data,
                "jogador",
                volante
                );


            jogo.Received().ValidarVolante(volante);

            aposta.IdAposta.ShouldBe(1);

            aposta.IdConcurso.ShouldBe(10);

            aposta.IdJogo.ShouldBe(2);

            aposta.DataOcorrencia.ShouldBe(data);

            aposta.Jogador.ShouldBe("jogador");

            aposta.Volante.ShouldBe(volante);


        }
    }
}
