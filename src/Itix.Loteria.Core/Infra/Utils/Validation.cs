using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Itix.Agenda.Core.Infra.Utils
{
    public static class Validation
    {


        public static bool IsValidCPF(string cpf)
        {
            if (cpf == null)
            {
                return false;
            }

            // Limpa a string
            cpf = cpf.Replace(".", "").Replace("-", "").Replace("/", "").Replace("\\", "").Trim();

            // Se o tamanho for < 11 entao retorna como inválido
            if (cpf.Length != 11)
            {
                return false;
            }

            int d1, d2;
            int soma = 0;
            string digitado = "";
            string calculado = "";

            // Pesos para calcular o primeiro digito
            int[] peso1 = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            // Pesos para calcular o segundo digito
            int[] peso2 = new int[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            int[] n = new int[11];

            bool retorno = false;

            // Caso coloque todos os numeros iguais
            switch (cpf)
            {
                case "11111111111":
                    return false;
                case "00000000000":
                    return false;
                case "22222222222":
                    return false;
                case "33333333333":
                    return false;
                case "44444444444":
                    return false;
                case "55555555555":
                    return false;
                case "66666666666":
                    return false;
                case "77777777777":
                    return false;
                case "88888888888":
                    return false;
                case "99999999999":
                    return false;
            }

            try
            {
                // Quebra cada digito do CPF
                n[0] = Convert.ToInt32(cpf.Substring(0, 1));
                n[1] = Convert.ToInt32(cpf.Substring(1, 1));
                n[2] = Convert.ToInt32(cpf.Substring(2, 1));
                n[3] = Convert.ToInt32(cpf.Substring(3, 1));
                n[4] = Convert.ToInt32(cpf.Substring(4, 1));
                n[5] = Convert.ToInt32(cpf.Substring(5, 1));
                n[6] = Convert.ToInt32(cpf.Substring(6, 1));
                n[7] = Convert.ToInt32(cpf.Substring(7, 1));
                n[8] = Convert.ToInt32(cpf.Substring(8, 1));
                n[9] = Convert.ToInt32(cpf.Substring(9, 1));
                n[10] = Convert.ToInt32(cpf.Substring(10, 1));
            }
            catch
            {
                return false;
            }


            // Calcula cada digito com seu respectivo peso
            for (int i = 0; i <= peso1.GetUpperBound(0); i++)
            {
                soma += (peso1[i] * Convert.ToInt32(n[i]));
            }

            // Pega o resto da divisao
            int resto = soma % 11;

            if (resto == 1 || resto == 0)
            {
                d1 = 0;
            }
            else
            {
                d1 = 11 - resto;
            }

            soma = 0;

            // Calcula cada digito com seu respectivo peso
            for (int i = 0; i <= peso2.GetUpperBound(0); i++)
            {
                soma += (peso2[i] * Convert.ToInt32(n[i]));
            }

            // Pega o resto da divisao
            resto = soma % 11;

            if (resto == 1 || resto == 0)
            {
                d2 = 0;
            }
            else
            {
                d2 = 11 - resto;
            }

            calculado = d1.ToString() + d2.ToString();
            digitado = n[9].ToString() + n[10].ToString();

            // Se os ultimos dois digitos calculados bater com
            // os dois ultimos digitos do cpf entao é válido
            if (calculado == digitado)
            {
                retorno = true;
            }
            else
            {
                retorno = false;
            }

            return retorno;

        }

        public static bool IsValidCNPJ(string cnpj)
        {
            if (cnpj == null)
            {
                return false;
            }

            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "").Replace("\\", "").Trim();

            if (cnpj.Length != 14) { return false; }

            if (cnpj == "00000000000000") { return false; }

            string l, inx, dig;
            int s1, s2, i, d1, d2, v, m1, m2;
            inx = cnpj.Substring(12, 2);
            cnpj = cnpj.Substring(0, 12);
            s1 = 0;
            s2 = 0;
            m2 = 2;
            for (i = 11; i >= 0; i--)
            {
                l = cnpj.Substring(i, 1);
                v = Convert.ToInt16(l);
                m1 = m2;
                m2 = m2 < 9 ? m2 + 1 : 2;
                s1 += v * m1;
                s2 += v * m2;
            }
            s1 %= 11;
            d1 = s1 < 2 ? 0 : 11 - s1;
            s2 = (s2 + 2 * d1) % 11;
            d2 = s2 < 2 ? 0 : 11 - s2;
            dig = d1.ToString() + d2.ToString();

            return (inx == dig);

        }

        public static bool IsValidCpfCnpj(this string documento)
        {
            if (documento == null)
            {
                return false;
            }

            if (documento.RemoveMask().Length == 11)
                return Validation.IsValidCPF(documento);
            else
                return Validation.IsValidCNPJ(documento);
        }

        public static bool IsValidSequenciaNumeros(string sequencia, int quantidade)
        {
            System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex("^[0-9]{" + quantidade + "}$");

            return r.IsMatch(sequencia);
        }


        //    '-----------------------------------------------------------------'
        //    '                  Regra de composição do CMC7                    '
        //    '                                                                 '
        //    '                                                                 '
        //    ' Número composto por 30 dígitos, descritos da seguinte forma :   '
        //    '                                                                 '
        //    '   |341|0004|8|018|000001|5|0|5000000004|7|                      '
        //    '     1    2  3  4    5    6 7      8     9                       '
        //    '                                                                 '
        //    ' 1 = código compensação do banco (3 dígitos)                     '
        //    ' 2 = número da agência (4 dígitos)                               '
        //    ' 3 = dígito módulo 10 dos seguintes campos :                     '
        //    '     cód.câmara compensação (3 dígitos)                          '
        //    '     núm.do cheque (6 dígitos)                                   '
        //    '     cód.tipificação do documento (1 dígito)                     '
        //    ' 4 = código da câmara compensação (3 dígitos)                    '
        //    ' 5 = número do cheque (6 dígitos)                                '
        //    ' 6 = código tipificação do documento (1 dígito)                  '
        //    '     5 : cheque comum                                            '
        //    '     6 : cheque ordem de pagamento                               '
        //    '     7 : cheque viagem                                           '
        //    '     8 : cheque administrativo                                   '
        //    ' 7 = dígito módulo 10 dos seguintes campos :                     '
        //    '     cód.banco (3 dígitos)                                       '
        //    '     cód.agência (4 dígitos)                                     '
        //    ' 8 = número da conta corrente (com dígito da conta) (10 dígitos) '
        //    ' 9 = dígito módulo 10 do campo número da cta.corrente            '
        //    '-----------------------------------------------------------------'
        //=============================================================
        public static bool IsValidCMC7(string cmc7)
        {
            if (cmc7.Length != 30)
            {
                return false;
            }

            string numCalc;
            string digRec1;
            string digRec2;
            string digRec3;
            string digCalc1;
            string digCalc2;
            string digCalc3;
            string cmc7Calc;

            numCalc = cmc7.Substring(8, 10);
            digRec1 = cmc7.Substring(7, 1);
            digCalc1 = CalcMod10(numCalc);

            numCalc = "000" + cmc7.Substring(0, 7);
            digRec2 = cmc7.Substring(18, 1);
            digCalc2 = CalcMod10(numCalc);

            numCalc = cmc7.Substring(19, 10);
            digRec3 = cmc7.Substring(29, 1);
            digCalc3 = CalcMod10(numCalc);

            cmc7Calc =
                cmc7.Substring(0, 7)
                + digCalc1
                + cmc7.Substring(8, 10)
                + digCalc2
                + cmc7.Substring(19, 10)
                + digCalc3;

            return (cmc7 == cmc7Calc);
        }

        public static string CalcMod10(string num)
        {
            int tam = num.Length;
            int soma = 0;
            int resto = 0;
            int temp = 0;
            bool pos = true;

            for (int i = 0; i < tam; i++)
            {
                temp = int.Parse(num.Substring(i, 1));
                if (pos)
                {
                    pos = false;
                    soma += temp;
                }
                else
                {
                    pos = true;
                    if (temp > 4)
                    {
                        soma += (temp * 2) - 9;
                    }
                    else
                    {
                        soma += (temp * 2);
                    }
                }
            }

            resto = soma % 10;
            if (resto == 0)
            {
                return "0";
            }
            else
            {
                return string.Format("{0}", (10 - resto));
            }
        }

        public static bool IsValidEmail(string email)
        {
            if (!PossuiValor(email))
            {
                return false;
            }

            Regex rg = new Regex(@"^[A-Za-z0-9_\+-]+(\.[A-Za-z0-9_\+-]+)*@[A-Za-z0-9-]+(\.[A-Za-z0-9-]+)*\.([A-Za-z]{2,4})$");

            return rg.IsMatch(email);
        }


        public static bool IsValidPis(string pis)
        {
            int[] multiplicador = new int[10] { 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;

            if (pis.Trim().Length != 11)
                return false;

            pis = pis.Trim();
            pis = pis.Replace("-", "").Replace(".", "").PadLeft(11, '0');


            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(pis[i].ToString()) * multiplicador[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            return pis.EndsWith(resto.ToString());
        }


        /// <summary>
        /// Valida um Cep sem Mascara
        /// </summary>
        /// <param name="cep"></param>
        /// <returns></returns>
        public static bool IsValidCep(string cep)
        {
            Regex rg = new Regex(@"^[0-9]{8}$");

            return rg.IsMatch(cep);
        }

        /// <summary>
        /// Valida uma Data no formato dd/MM/yyyy
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool IsValidDate(this string data)
        {
            if (data.EhVazio())
            {
                return false;
            }

            //if (!new Regex(@"^[0-9]{2}/[0-9]{2}/[0-9]{4}$").IsMatch(data))
            //{
            //    return false;
            //}

            DateTime dataAuxiliar;

            return DateTime.TryParseExact(
                data
                , "dd/MM/yyyy"
                , CultureInfo.GetCultureInfo("pt-BR")
                , DateTimeStyles.None
                , out dataAuxiliar);

        }


        public static bool PossuiValor(string valor)
        {
            return !string.IsNullOrWhiteSpace(valor);
        }

        public static bool EstaVazio(string valor)
        {
            return !PossuiValor(valor);
        }


        public static bool EhVazio(string valor)
        {
            return string.IsNullOrWhiteSpace(valor);
        }

        public static bool IsValidPlacaDeAutomovel(this string placa)
        {
            return new Regex("[a-zA-Z]{3}[0-9]{4}").IsMatch(placa);
        }


        public static bool IsValidDecimal(this string valor)
        {
            decimal numero = 0;

            return decimal.TryParse(valor, out numero);
        }

        public static bool IsValidInt(this string data)
        {
            int inteiro;

            return int.TryParse(data, out inteiro);
        }


        public static DateTime? ParseData(string data)
        {
            if (Validation.IsValidDate(data))
            {
                return Convert.ToDateTime(data);
            }

            else
            {
                return null;
            }
        }


        /// <summary>
        /// Fonte : http://www.blackbeltcoder.com/Articles/ecommerce/validating-credit-card-numbers
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <returns></returns>
        public static bool IsValidCartaoDeCredito(string cardNumber)
        {

            if (!new Regex(@"^\d+$").IsMatch(cardNumber))
            {
                return false;
            }

            int i, checkSum = 0;

            // Compute checksum of every other digit starting from right-most digit
            for (i = cardNumber.Length - 1; i >= 0; i -= 2)
                checkSum += (cardNumber[i] - '0');

            // Now take digits not included in first checksum, multiple by two,
            // and compute checksum of resulting digits
            for (i = cardNumber.Length - 2; i >= 0; i -= 2)
            {
                int val = ((cardNumber[i] - '0') * 2);
                while (val > 0)
                {
                    checkSum += (val % 10);
                    val /= 10;
                }
            }

            // Number is valid if sum of both checksums MOD 10 equals 0
            return ((checkSum % 10) == 0);
        }


        public static bool EhCpf(this string documento)
        {
            return Validation.IsValidCPF(documento);
        }


        public static bool EhCnpj(this string documento)
        {
            return Validation.IsValidCNPJ(documento);
        }




        public static void Obrigatorio(
              object obj
            , string campo = null
            , string mensagem = null
            , string objetoPai = null
            , int? posicao = null
            )
        {

            string texto = RetornarMensagemValidacao(
                "é obrigatório."
                , campo
                , mensagem
                , objetoPai
                , posicao);



            if (obj == null)
                throw new DomainException(texto);

            if (obj is string && string.IsNullOrWhiteSpace(obj.ToString()))
                throw new DomainException(texto);

        }


        public static void AssegurarQue(
            bool condicao
            , string campo = null
            , string mensagem = null
            , string objetoPai = null
            , int? posicao = null
            )
        {

            string texto = RetornarMensagemValidacao(
              null
              , campo
              , mensagem
              , objetoPai
              , posicao);


            if (condicao == false)
                throw new DomainException(texto);


        }

        private static string RetornarMensagemValidacao(
              string sufixoMensagem
            , string campo
            , string mensagem
            , string objetoPai
            , int? posicao
            )
        {

            sufixoMensagem = sufixoMensagem?.Trim();

            campo = campo?.Trim();

            mensagem = mensagem?.Trim();

            objetoPai = objetoPai?.Trim();


            var result = string.Empty;


            if (objetoPai != null)
                result += objetoPai;

            if ((objetoPai != null) && (posicao != null))
                result += " " + posicao.ToString();

            if (objetoPai != null)
                result += " >";

            if (campo != null)
                result += " " + campo;

            if (sufixoMensagem != null)
                result += " " + sufixoMensagem;

            if (mensagem != null)
                result += " " + mensagem;


            return result.Trim();
        }


        public static void AssegurarCpfCnpj(
            string documento
            , string campo = null
            , string objetoPai = null
            , int? posicao = null
            )
        {

            string sufixoMensagem = "Inválido.";

            if (documento == null)
                documento = string.Empty;

            if (campo == null)
                campo = "Documento";

            string mensagem = RetornarMensagemValidacao(
           sufixoMensagem
           , campo
           , null
           , objetoPai
           , posicao);


            Validation.AssegurarQue(Validation.IsValidCpfCnpj(documento), mensagem: mensagem);


        }

        public static void AssegurarCnpj(
           string documento
           , string campo = null
           , string objetoPai = null
           , int? posicao = null
           )
        {

            string sufixoMensagem = "Inválido.";

            if (documento == null)
                documento = string.Empty;

            if (campo == null)
                campo = "Cnpj";

            string mensagem = RetornarMensagemValidacao(
           sufixoMensagem
           , campo
           , null
           , objetoPai
           , posicao);


            Validation.AssegurarQue(Validation.IsValidCNPJ(documento), mensagem: mensagem);


        }


        public static void AssegurarCep(
          string cep
          , string campo = null
          , string objetoPai = null
          , int? posicao = null
          )
        {

            string sufixoMensagem = "Inválido. Informe um Cep com 8 dígitos.";

            if (cep == null)
                cep = string.Empty;

            if (campo == null)
                campo = "Cep";

            string mensagem = RetornarMensagemValidacao(
           sufixoMensagem
           , campo
           , null
           , objetoPai
           , posicao);


            Validation.AssegurarQue(Validation.IsValidCep(cep), mensagem: mensagem);


        }

        public static bool EhCelular(string telefone)
        {
            telefone = telefone.Trim();

            int primeiroDigito = Convert.ToInt32(telefone[0].ToString());

            List<int> listaDigitoCelular = new List<int> { 7, 8, 9 };

            return listaDigitoCelular.Contains(primeiroDigito);
        }



    }

}