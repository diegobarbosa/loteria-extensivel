using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Itix.Agenda.Core.Infra.AppService
{
    public abstract class CommandHandler<T> where T : ICommand
    {

        protected object Result;


        protected abstract void Executar(T command);


        public object Run(T command)
        {
            this.Executar(command);

            return this.Result;
        }

    }

    public interface ICommand
    {
    }
}
