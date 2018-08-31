using System;
using System.Collections.Generic;
using System.Text;

namespace Itix.Agenda.Core.Infra.Utils
{
    public interface ITimeProvider
    {
        DateTime Now { get; }
    }

    public class TimeProvider : ITimeProvider
    {
        public DateTime Now => DateTime.Now;
    }
}
