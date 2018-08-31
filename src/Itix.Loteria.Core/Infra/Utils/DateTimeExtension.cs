using System;
using System.Collections.Generic;
using System.Text;

namespace Itix.Agenda.Core.Infra.Utils
{
    public static class DateTimeExtension
    {
        public static DateTime? ToDateTimeOrNull(this string date)
        {
            if (date.EhVazio())
            {
                return null;
            }

            DateTime result;

            return DateTime.TryParse(date, out result) ? (DateTime?)result : null;
        }

        /// <summary>
        ///  example 2017-08-07T13:45:30
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToSortableISO(this DateTime date)
        {
            return date.ToString("s");
        }

        public static DateTime MenorDataPossivel = new DateTime(1753, 1, 1);

        public static string ToDateBr(this DateTime? date)
        {
            return date.Value.ToString("dd/MM/yyyy");
        }

    }
}
