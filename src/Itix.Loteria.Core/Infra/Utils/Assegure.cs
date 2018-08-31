using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Itix.Agenda.Core.Infra.Utils
{
    public class QueSe
    {
        bool expressaoQueSe;

        public QueSe(bool expressaoQueSe)
        {
            this.expressaoQueSe = expressaoQueSe;
        }



        public QueSe Entao(Func<bool> expressao, Func<string> message = null)
        {
            if (expressaoQueSe)
            {
                if (expressao() == false)
                    throw new DomainException(message());
            }

            return this;
        }

        public void EntaoFalhe(Func<string> message = null)
        {
            if (expressaoQueSe)
            {
                throw new DomainException(message());
            }
        }
    }

    public class Falhe
    {
        public static void Se(bool expressao, Func<string> messagem = null)
        {
            if (expressao)
            {
                throw new DomainException(messagem());
            }
        }

        public static void Quando(bool expressao, Func<string> messagem = null)
        {
            if (expressao)
            {
                throw new DomainException(messagem());
            }
        }
    }

    public class Assegure
    {
        public const string MensagemDeErroDefault = "Erro Interno";

        public static void AddContext(Func<object> contexto)
        {
            //var context = System.Web.HttpContext.Current;

            //try
            //{
            //    if (contexto != null && context != null)
            //    {
            //        context.Request.ServerVariables["X-LOG-JSON-DATA"] =

            //     JsonConvert.SerializeObject(contexto()
            //                , Newtonsoft.Json.Formatting.Indented);
            //    }

            //}
            //catch (Exception ex)
            //{

            //    ErrorLog.Default?.Log(new Error(ex));

            //}
        }

        public static QueSe QueSe(bool expressao)
        {
            return new QueSe(expressao);
        }

        public static void Que(bool expressao, string message = null)
        {
            if (expressao == false)
                throw new DomainException(message);
        }

        public static void QueNao(bool expressao, string message = null)
        {
            if (expressao)
                throw new DomainException(message);
        }


        public static void Que(bool expressao, Func<string> messagem = null, Func<object> contexto = null)
        {
            if (expressao == false)
            {
                AddContext(contexto);

                throw new DomainException(messagem(), contexto?.Invoke());
            }
        }


        public static void NaoNulo(object obj, string message = null)
        {
            if (obj is string)
            {
                if (string.IsNullOrWhiteSpace(obj.ToString()))
                    throw new DomainException(message);
            }

            if (obj == null)
                throw new DomainException(message);
        }

        public static void NaoNulo(object obj, Func<string> message = null)
        {
            if (obj is string)
            {
                if (string.IsNullOrWhiteSpace(obj.ToString()))
                    throw new DomainException(message());
            }

            if (obj == null)
                throw new DomainException(message());
        }




        public static void Regex(string pattern, string input, string message = null)
        {
            var reg = new Regex(pattern);

            if (!reg.IsMatch(input))
                throw new DomainException(message);
        }


    }
}
