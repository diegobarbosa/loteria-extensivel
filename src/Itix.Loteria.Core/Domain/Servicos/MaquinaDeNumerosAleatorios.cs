using System;
using System.Collections.Generic;
using System.Text;

namespace Itix.Loteria.Core.Domain.Servicos
{
    public interface IMaquinaDeNumerosAleatorios
    {
        List<int> GerarNumeros(int maiorNumero, int quantidadeDeSaida);
    }

    public class MaquinaDeNumerosAleatorios: IMaquinaDeNumerosAleatorios
    {
        public List<int> GerarNumeros(int maiorNumero, int quantidadeDeSaida)
        {
            var result = new List<int>();

            var random = new Random();

            while (result.Count < quantidadeDeSaida)
            {
                var number = random.Next(1, maiorNumero);

                if (result.Contains(number))
                {
                    continue;
                }

                result.Add(number);
            }

            return result;
        }
    }
}
