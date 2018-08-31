using Itix.Agenda.Core.Infra.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Itix.Agenda.Core.Infra.UI
{
    public class PeriodoFechadoDTO
    {

        public string DataInicial { get; set; }

        public string DataFinal { get; set; }


        public PeriodoFechadoDTO()
        {

        }

        public PeriodoFechadoDTO(PeriodoFechado periodoFechado)
        {
            this.DataInicial = periodoFechado.DataInicial.ToSortableISO();

            this.DataFinal = periodoFechado.DataFinal.ToSortableISO();
        }

        public PeriodoFechado ToPeriodoFechado()
        {
            return new PeriodoFechado(this.DataInicial.ToDateTimeOrNull(), this.DataFinal.ToDateTimeOrNull());
        }

        public void Validar()
        {
            var dataInicial = DataInicial.ToDateTimeOrNull();

            var dataFinal = DataFinal.ToDateTimeOrNull();

            PeriodoFechado.Validar(dataInicial, dataFinal);
        }
    }
}
