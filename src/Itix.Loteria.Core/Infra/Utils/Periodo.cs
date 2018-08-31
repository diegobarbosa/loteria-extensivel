using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itix.Agenda.Core.Infra.Utils
{
    public class PeriodoFechado
    {
        public virtual DateTime DataInicial { get; set; }

        public virtual DateTime DataFinal { get; set; }

        protected PeriodoFechado()
        {

        }

        public PeriodoFechado(DateTime? dataInicial, DateTime? dataFinal)
        {
            Validar(dataInicial, dataFinal);

            this.DataInicial = dataInicial.Value;

            this.DataFinal = dataFinal.Value;
        }

        public static void Validar(DateTime? dataInicial, DateTime? dataFinal)
        {
            Assegure.Que(dataInicial != null, "Informe uma Data Inicial válida");

            Assegure.Que(dataFinal != null, "Informe uma Data Final válida");


            Assegure.Que(dataInicial != DateTime.MinValue, () => $"Data inicial inválida: {dataInicial}");

            Assegure.Que(dataFinal != DateTime.MinValue, () => $"Data Final inválida: {dataFinal}");

            Assegure.Que(dataInicial <= dataFinal, "Data Inicial deve ser menor ou igual a Data Final");

        }

    }
}
