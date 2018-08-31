using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Itix.Agenda.Core.Infra.Utils
{
    public static class StringExtension
    {
        public static DateTime ToDateTime(this string s)
        {
            return Convert.ToDateTime(s);
        }



        public static string ToDateTimeInicial(this string s)
        {
            return string.Format("{0} 00:00:00", s);
        }

        public static string ToDateTimeFinal(this string s)
        {
            return string.Format("{0} 23:59:59", s);
        }

        /// <summary>
        /// Converte uma string True ou False em um valor booleano
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool ToBool(this string s)
        {
            return Convert.ToBoolean(s);
        }

        public static int ToBoolDd(this string s)
        {
            return Convert.ToInt32(Convert.ToBoolean(s));
        }

        /// <summary>
        /// Retorna os ultimos caracteres de uma string
        /// </summary>
        /// <param name="s"></param>
        /// <param name="lenght">Quantidade no final da string</param>
        /// <returns></returns>
        public static string LastString(this string s, int lenght)
        {
            return s.Substring(s.Length - lenght, lenght);
        }

        /// <summary>
        /// Adiciona zero na frente de  um número
        /// </summary>
        /// <param name="s"></param>
        /// <param name="lenghtOfNumbers">quantidade de numeros que a string deverá ter</param>
        /// <returns></returns>
        public static string AddZerosToFront(this string s, int lenghtOfNumbers)
        {
            string zeros = "";

            for (int i = 0; i < lenghtOfNumbers - s.Length; i++)
            {
                zeros += "0";
            }

            return s.Insert(0, zeros);
        }

        public static int ToInt<T>(string valor)
        {
            return (int)Enum.Parse(typeof(T), valor);
        }


        public static int ToInt(this string s)
        {
            return Convert.ToInt32(s);
        }



        public static int ToLong(this string s)
        {
            return Convert.ToInt32(s);
        }

        public static decimal ToDecimal(this string s)
        {
            return Convert.ToDecimal(s);
        }



        public static string RemoveMask(this string texto)
        {
            if (texto == null)
            {
                return null;
            }

            return Regex.Replace(texto, "[ ()/,.-]", "");
        }



        public static int ToIntMonth(this string i)
        {
            switch (i)
            {
                case "Janeiro":
                    return 1;
                case "Fevereiro":
                    return 2;
                case "Março":
                    return 3;
                case "Abril":
                    return 4;
                case "Maio":
                    return 5;
                case "Junho":
                    return 6;
                case "Julho":
                    return 7;
                case "Agosto":
                    return 8;
                case "Setembro":
                    return 9;
                case "Outubro":
                    return 10;
                case "Novembro":
                    return 11;
                case "Dezembro":
                    return 12;
                default:
                    throw new Exception("Valor inválido");
            }
        }

        public static void ColocarAspas(this List<string> lista)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                lista[i] = string.Format("'{0}'", lista[i]);
            }
        }

        public static string ToMultiLineWeb(this List<string> lista)
        {
            return string.Join("<br/>", lista.ToArray());
        }




        /// <summary>
        /// Troca acentos por caracteres normais
        /// Troca os caracteres especiais por " " a não ser .;,_- e " " e \n e \r 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static String RemoverCaracteresEspeciais(this String self)
        {
            if (self == null)
            {
                return null;
            }


            var normalizedString = self;

            normalizedString = Regex.Replace(normalizedString, "[âáàã]", "a");
            normalizedString = Regex.Replace(normalizedString, "[ÂÀÁÃ]", "A");
            normalizedString = Regex.Replace(normalizedString, "[êèé]", "e");
            normalizedString = Regex.Replace(normalizedString, "[ÊÈÉ]", "E");
            normalizedString = Regex.Replace(normalizedString, "[îìí]", "i");
            normalizedString = Regex.Replace(normalizedString, "[ÎÌÍ]", "I");
            normalizedString = Regex.Replace(normalizedString, "[õôòó]", "o");
            normalizedString = Regex.Replace(normalizedString, "[ÕÔÒÓ]", "O");
            normalizedString = Regex.Replace(normalizedString, "[üûúù]", "u");
            normalizedString = Regex.Replace(normalizedString, "[ÜÛÚÙ]", "U");
            normalizedString = Regex.Replace(normalizedString, "[ç]", "c");
            normalizedString = Regex.Replace(normalizedString, "[Ç]", "C");



            // Remove os outros caracteres especiais.
            var caracteresPermitidos = "[^0-9a-zA-Z._,;\n\r -]+?";
            normalizedString = Regex.Replace(normalizedString, caracteresPermitidos, " ");

            return normalizedString.Trim();
        }

     



      

        public static string MaxString(this string str, int quantidadeMaxima)
        {


            if (str.Length > quantidadeMaxima)
            {
                return str.Substring(0, quantidadeMaxima);
            }
            else
            {
                return str;
            }

        }

        public static string SplitMaiusculas(this string str)
        {
            string resposta = string.Empty;

            var reg = new Regex("[A-Z]");

            for (int i = 0; i < str.Length; i++)
            {
                if (reg.IsMatch(str[i].ToString()) && i != 0)
                {
                    resposta += " " + str[i].ToString();

                }
                else
                {
                    resposta += str[i].ToString();
                }
            }


            return resposta;
        }

        public static Dictionary<string, string> XmlToDictionary(this string xml)
        {

            XElement element = XElement.Load(xml);

            Dictionary<string, string> dicionario = (from no in element.Descendants()
                                                     select new { key = no.Name.LocalName, value = no.Value })
                                                           .ToDictionary(y => y.key, y => y.value);

            return dicionario;

        }


        /// <summary>
        /// Removes control characters and other non-UTF-8 characters
        /// </summary>
        /// <param name="inString">The string to process</param>
        /// <returns>A string with no control characters or entities above 0x00FD</returns>
        public static string RemoveTroublesomeCharacters(string inString)
        {
            if (inString == null) return null;

            StringBuilder newString = new StringBuilder();

            try
            {

                char ch;

                for (int i = 0; i < inString.Length; i++)
                {

                    ch = inString[i];
                    // remove any characters outside the valid UTF-8 range as well as all control characters
                    // except tabs and new lines
                    if ((ch < 0x00FD && ch > 0x001F) || ch == '\t' || ch == '\n' || ch == '\r')
                    {
                        newString.Append(ch);
                    }
                }
                return newString.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                newString.Clear();
            }


        }





        public static void Clear(this StringBuilder str)
        {
            str.Remove(0, str.Length - 1);
        }

        /// <summary>
        /// Retornar o Valor da String passada se houver valor.
        /// Se não, retorna null
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Null_IF_Empty(this string str)
        {
            return Validation.PossuiValor(str) ? str : null;
        }

        public static void Add(this List<string> lista, string format, params object[] args)
        {
            lista.Add(string.Format(format, args));
        }

        public static List<int> ToListOfInts(this string value)
        {
            if (!Validation.PossuiValor(value))
            {
                return new List<int>();
            }

            value = value.Trim();




            if (value.Split('\n').Count() > 1)
            {
                return value
              .Split('\n')
              .ToList()
              .ConvertAll<int>(p => Convert.ToInt32(p.Trim()));
            }



            return value
            .Split(',')
            .ToList()
            .ConvertAll<int>(p =>
                {
                    int codigo = 0;

                    if (!int.TryParse(p.Trim(), out codigo))
                    {
                        throw new DomainException(String.Format("O código {0} não está em um formato válido", p));
                    }

                    return codigo;
                }

                );

        }


        /// <summary>
        /// Tranforma uma string contendo:
        /// , (vírgula)
        /// ; (ponto e vírgula)
        /// \n (quebra de linha)
        /// em um array de strings
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static List<string> ToListOfStrings(this string value)
        {
            if (value.EhVazio())
            {
                return new List<string>();
            }

            value = value
                .Trim()
                .Replace(";", ",")
                .Replace('\n', ',');


            return value
            .Split(',')
            .Select(x => x.Trim())
            .Where(x => x.Length > 0)
            .ToList();

        }


        public static bool PossuiValor(this string str)
        {
            return Validation.PossuiValor(str);
        }

        public static bool EhVazio(this string str)
        {
            return !Validation.PossuiValor(str);
        }


        public static string Empty_if_null(this string str)
        {
            return str.PossuiValor() ? str : string.Empty;
        }


        public static string Value_if_null(this string str, string value)
        {
            return str.PossuiValor() ? str : value;
        }

        public static string ReplaceWithRegex(this string str, string pattern, string with = "")
        {
            return Regex.Replace(str, pattern, with);
        }

        public static string DeveTerTamanho(this string str, int tamanhoExato, Func<string> mensagem = null)
        {
            Assegure.NaoNulo(str, $"{mensagem()}. Valor null");

            Assegure.Que(str.Length == tamanhoExato,
                () => $"{mensagem()}. {str.Length} caracteres, quando deveria ter {tamanhoExato}. Valor: #{str}#");

            return str;
        }

    }
}
