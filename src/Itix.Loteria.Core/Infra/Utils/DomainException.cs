using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Itix.Agenda.Core.Infra.Utils
{


    [Serializable]
    public class DomainException : Exception
    {
        public DomainException()
        {
            Messages = new List<string>();
        }

        public DomainException(string message)
            : base(message)
        {
            Messages = new List<string>();

            Messages.Add(message);
        }

        public DomainException(string message, object context)
           : base(message)
        {
            Messages = new List<string>();

            Messages.Add(message);

            Context = context;
        }

        public DomainException(string message, Exception inner)
            : base(message, inner)
        {
            Messages = new List<string>();

            Messages.Add(message);
        }

        protected DomainException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }

        public List<string> Messages { get; private set; }

        public object Context { get; private set; }

        public DomainException(List<string> messages)
        {
            this.Messages = messages;
        }
    }


}
