using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Xml;
using System.Text.RegularExpressions;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq.Expressions;

namespace Itix.Agenda.Core.Infra.Utils
{
    public static class ObjectExtension
    {
        public static object GetProperty(this object obj, string name)
        {
            PropertyInfo p = obj.GetType().GetProperty(name);

            if (p == null)
            {
                throw new Exception("A propriedade '" + name + "' não foi encontrada.");
            }

            return p.GetValue(obj, null);
        }

        public static void SetProperty(this object obj, string name, object value)
        {
            PropertyInfo p = obj.GetType().GetProperty(name);

            if (p == null)
            {
                throw new Exception("A propriedade '" + name + "' não foi encontrada.");
            }

            p.SetValue(obj, value, null);
        }


        public static void SetProperty<TSource, TProperty>(
            this TSource obj,
            Expression<Func<TSource, TProperty>> propertyLambda,
            object value)
        {
            Type type = typeof(TSource);

            MemberExpression member = propertyLambda.Body as MemberExpression;
            if (member == null)
                throw new ArgumentException(string.Format(
                    "Expression '{0}' refers to a method, not a property.",
                    propertyLambda.ToString()));

            PropertyInfo propInfo = member.Member as PropertyInfo;
            if (propInfo == null)
                throw new ArgumentException(string.Format(
                    "Expression '{0}' refers to a field, not a property.",
                    propertyLambda.ToString()));

            if (type != propInfo.ReflectedType &&
                !type.IsSubclassOf(propInfo.ReflectedType))
                throw new ArgumentException(string.Format(
                    "Expression '{0}' refers to a property that is not from type {1}.",
                    propertyLambda.ToString(),
                    type));


            propInfo.SetValue(obj, value, null);

        }

        public static void SetPrivateAtribute(this object obj, string name, object value)
        {
            FieldInfo[] fields = obj.GetType().GetFields(
                         BindingFlags.NonPublic |
                         BindingFlags.Instance);

            var field = fields.Where(x => x.Name == name).SingleOrDefault();

            if (field == null)
            {
                throw new Exception("A propriedade '" + name + "' não foi encontrada.");
            }

            field.SetValue(obj, value);
        }






        public static XElement ToXml(this object obj)
        {
            var t = obj.GetType();
            XmlSerializer xs = new XmlSerializer(obj.GetType());

            XDocument d = new XDocument();
            d.Declaration = new XDeclaration("1.0", "utf-8", "yes");
            using (XmlWriter w = d.CreateWriter()) xs.Serialize(w, obj);
            XElement e = d.Root;
            e.Remove();
            return e;
        }

        public static byte[] ToBinary(this object obj)
        {
            MemoryStream memory = null;

            try
            {
                memory = new MemoryStream();

                var formatter = new BinaryFormatter();

                formatter.Serialize(memory, obj);

                return memory.ToArray();

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (memory != null) memory.Close();
            }

        }



        public static XElement ToXml(this object obj, string defaultNamespace)
        {
            XmlSerializer xs = new XmlSerializer(obj.GetType(), defaultNamespace);

            XDocument d = new XDocument();
            d.Declaration = new XDeclaration("1.0", "utf-8", "yes");
            using (XmlWriter w = d.CreateWriter()) xs.Serialize(w, obj);
            XElement e = d.Root;
            e.Remove();
            return e;
        }

        public static void SetarParametros(object parametroObj, Dictionary<string, string> dicParametros)
        {

            dicParametros = new Dictionary<string, string>(dicParametros, StringComparer.OrdinalIgnoreCase);


            PropertyInfo[] propriedades = parametroObj.GetType()
                    .GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);

            foreach (var propertyInfo in propriedades)
            {
                if (dicParametros.Keys.Contains(propertyInfo.Name))
                {

                    string valor = dicParametros[propertyInfo.Name];

                    if (typeof(DateTime?).IsAssignableFrom(propertyInfo.PropertyType))
                    {

                        if (valor.PossuiValor())
                        {
                            propertyInfo.SetValue(parametroObj, (DateTime?)DateTime.Parse(valor), null);
                        }

                    }
                    else if (typeof(int?).IsAssignableFrom(propertyInfo.PropertyType))
                    {

                        if (!string.IsNullOrWhiteSpace(valor))
                            propertyInfo.SetValue(parametroObj, Convert.ToInt32(valor), null);

                    }
                    else if (typeof(long?).IsAssignableFrom(propertyInfo.PropertyType))
                    {
                        propertyInfo.SetValue(parametroObj, long.Parse(valor), null);
                    }
                    else if (typeof(Enum).IsAssignableFrom(propertyInfo.PropertyType))//its derived from Enum
                    {
                        propertyInfo.SetValue(parametroObj, System.Enum.Parse(propertyInfo.PropertyType, valor), null);
                    }
                    else if (IsNullableEnum(propertyInfo.PropertyType))//its derived from Enum
                    {
                        propertyInfo.SetValue(parametroObj, System.Enum.Parse(Nullable.GetUnderlyingType(propertyInfo.PropertyType), valor), null);
                    }
                    else if (typeof(Guid).IsAssignableFrom(propertyInfo.PropertyType))
                    {
                        propertyInfo.SetValue(parametroObj, new Guid(valor), null);
                    }
                    else if (IsNullableGuid(propertyInfo.PropertyType))
                    {
                        propertyInfo.SetValue(parametroObj, new Guid(valor), null);
                    }
                    else if (typeof(decimal).IsAssignableFrom(propertyInfo.PropertyType))
                    {

                        bool ehDecimalValido = new Regex(@"^-?\d{1,3}(\.?\d{3})*(\,\d\d)?$|^\,\d\d$").IsMatch(valor);

                        if (!ehDecimalValido)
                            throw new FormatException(string.Format("{0}: formato inválido.", propertyInfo.Name));

                        propertyInfo.SetValue(parametroObj, decimal.Parse(valor, System.Globalization.CultureInfo.GetCultureInfo("pt-br")), null);
                    }

                    else
                    {
                        propertyInfo.SetValue(parametroObj, valor, null);
                    }


                }
            }
        }



        public static bool IsNullableEnum(this Type t)
        {
            Type u = Nullable.GetUnderlyingType(t);
            return (u != null) && u.IsEnum;
        }

        public static bool IsNullableGuid(this Type t)
        {
            Type u = Nullable.GetUnderlyingType(t);
            return (u != null) && u == typeof(Guid);
        }


        public static T DeSerializeAnObject<T>(this XElement XmlOfAnObject)
        {

            XmlSerializer Xml_Serializer = new XmlSerializer(typeof(T));
            XmlReader XmlReader = XmlOfAnObject.CreateReader();


            try
            {
                T AnObject = (T)Xml_Serializer.Deserialize(XmlReader);
                return AnObject;
            }

            finally
            {
                XmlReader.Close();
            }

        }


        public static T DeSerializeFromBinary<T>(byte[] obj)
        {
            MemoryStream memory = null;

            try
            {
                memory = new MemoryStream(obj);

                var formatter2 = new BinaryFormatter();

                return (T)formatter2.Deserialize(memory);

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (memory != null) memory.Close();
            }

        }



        public static T Clone<T>(this T source)
        {
            var serialized = JsonConvert.SerializeObject(source);
            return JsonConvert.DeserializeObject<T>(serialized);
        }





        public static object Invoke(this object o, string methodName, params object[] args)
        {
            var mi = o.GetType().GetMethod(methodName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (mi != null)
            {
                return mi.Invoke(o, args);
            }
            return null;
        }


    }
}
