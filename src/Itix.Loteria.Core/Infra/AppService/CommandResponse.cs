using Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Itix.Agenda.Core.Infra.AppService
{
    public class CommandResponse
    {
        /// <summary>
        /// Pode ser o Id Gerado, Lista de Ids gerados, um resumo da operação (x items não encontrados, y já baixados).
        /// Ou Uma listagem de uma query.
        /// </summary>
        public object Result { get; set; }

        public Exception Exception { get; set; }

        public bool Sucesso { get; set; }

        public bool Erro { get { return !Sucesso; } }


        public List<MessageResult> Messages { get; private set; }

        public CommandResponse()
        {
            Messages = new List<MessageResult>();
        }

        public void AddMessage(string text)
        {
            Messages.Add(new MessageResult(text));
        }

        public void AddMessages(List<string> messages)
        {
            foreach (var msg in messages)
            {
                Messages.Add(new MessageResult(msg));
            }

        }


    }
}
