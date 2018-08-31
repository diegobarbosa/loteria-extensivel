using Itix.Agenda.Core.Data;
using Itix.Agenda.Core.Infra.IocContainer;
using Itix.Agenda.Core.Infra.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Itix.Agenda.Core.Infra.AppService
{
    public class UseCaseRunner
    {

        IUnitOfWork unitOfWork;



       // ILogError logError;

        IContainer container;

        public UseCaseRunner(IUnitOfWork iUnitOfWork,
         //   ILogError logError, 
            IContainer container)
        {
            this.unitOfWork = iUnitOfWork;


           // this.logError = logError;

            this.container = container;
        }


        public CommandResponse Execute<T>(T request) where T : ICommand
        {
            var response = new CommandResponse();

            try
            {


                unitOfWork.StartTransaction();

                var useCase = container.GetInstance<CommandHandler<T>>();


                response.Result = useCase.Run(request);


                unitOfWork.Commit();


                response.Sucesso = true;

            }
            catch (DomainException ex)
            {

                response.AddMessages(ex.Messages);


                response.Sucesso = false;

                unitOfWork.RollBack();
            }

            catch (Exception ex)
            {
                response.AddMessage("Erro interno");
                response.Sucesso = false;

                unitOfWork.RollBack();


                //logError.Log(ex);
            }

            return response;

        }





        


        public CommandResponse Query(IQueryCommand request)
        {
            object currentRequest = request;

            var response = new CommandResponse();

            try
            {

                unitOfWork.StartTransaction();

                var handlerType =
                typeof(QueryHandler<>).MakeGenericType(request.GetType());

                dynamic handler = container.GetInstance(handlerType);


                handler.Query((dynamic)request);


                response.Sucesso = true;

            }
            catch (DomainException ex)
            {
                response.Exception = ex;
                response.AddMessages(ex.Messages);
                response.Sucesso = false;

            }
            catch (Exception ex)
            {
                response.Exception = ex;
                response.AddMessage("Erro interno");
                response.Sucesso = false;

               // logError.Log(ex);
            }
            finally
            {
                unitOfWork.RollBack();
            }


            return response;
        }






        public CommandResponse Build(IQueryCommand request)
        {
            object currentRequest = request;

            var response = new CommandResponse();

            try
            {

                unitOfWork.StartTransaction();

                var handlerType =
                typeof(QueryHandler<>).MakeGenericType(request.GetType());

                dynamic handler = container.GetInstance(handlerType);


                handler.Build((dynamic)request);


                response.Sucesso = true;

            }
            catch (DomainException ex)
            {
                response.Exception = ex;
                response.AddMessages(ex.Messages);
                response.Sucesso = false;

            }
            catch (Exception ex)
            {
                response.Exception = ex;
                response.AddMessage("Erro interno");
                response.Sucesso = false;

                //logError.Log(ex);
            }
            finally
            {
                unitOfWork.RollBack();
            }


            return response;
        }




    }
}
