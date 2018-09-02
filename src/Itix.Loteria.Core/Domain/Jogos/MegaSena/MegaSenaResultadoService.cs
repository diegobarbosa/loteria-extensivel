using Itix.Loteria.Core.Domain.Jogos.Core;
using Itix.Loteria.Core.Domain.Servicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Itix.Loteria.Core.Domain.Jogos.MegaSena
{
    public class MegaSenaResultadoService : IResultadoService
    {
        IMaquinaDeNumerosAleatorios maquinaDeNumerosAleatorios;

        public MegaSenaResultadoService(IMaquinaDeNumerosAleatorios maquinaDeNumerosAleatorios)
        {
            this.maquinaDeNumerosAleatorios = maquinaDeNumerosAleatorios;
        }

        public IResultado GetResultado(IJogo jogo)
        {
            var megaSena = jogo as MegaSenaJogo;

            var numerosSorteados = maquinaDeNumerosAleatorios
                  .GerarNumeros(
                 megaSena.Regras.Quantidade_Maxima_De_Numeros_Disponiveis_Para_Selecionar,
                 megaSena.Regras.QuantidadeDeNumerosASortear);


            return new MegaSenaJogo.Resultado(numerosSorteados);
        }
    }
}
