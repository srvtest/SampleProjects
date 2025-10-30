using illumiyaFramework.Log;
using illumiyaFramework.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace illumiyaFramework.Serialization
{
    public static class Serializer
    {

        public static T CloneObject<T>(this T item)
        {
            return ConvertJsonToObject<T>(item.ConvertToJson());
        }

        public static T ConvertJsonToObject<T>(string json)
        {
            try
            {
                if (!string.IsNullOrEmpty(json))
                {
                    var settings = new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.Auto
                    };

                    var obj = JsonConvert.DeserializeObject(json, typeof(T), settings);
                    return (T)obj;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(string.Empty, ex);
            }
            return default(T);
        }

        public static string ConvertToJson(Object value, bool isIndentedFormat = false, bool isTypeName = false)
        {
            string JSONString = string.Empty;
            try
            {
                var settings = new JsonSerializerSettings
                {
                    TypeNameHandling = isTypeName ? TypeNameHandling.Auto : TypeNameHandling.None
                };

                return JsonConvert.SerializeObject(value, isIndentedFormat ? Newtonsoft.Json.Formatting.Indented : Newtonsoft.Json.Formatting.None, settings);
            }
            catch (Exception ex)
            {
                Logger.Error(string.Empty, ex);
            }
            return JSONString;
        }

        public static bool ConvertXmlToObject(string fileLocation, ref object obj)
        {
            bool isOK = false;
            try
            {
                string data = File.ReadAllText(fileLocation);
                if (!string.IsNullOrEmpty(data))
                {
                    using (XmlReader reader = XmlReader.Create(new StringReader(data)))
                    {
                        XmlSerializer xs = new XmlSerializer(obj.GetType());
                        obj = xs.Deserialize(reader);
                        isOK = true;
                    };
                }
            }
            catch (Exception ex)
            {
                Logger.Error(string.Empty, ex);
            }
            return isOK;
        }

        public static string ConvertToXml<T>(T objectToSerialize, bool removeXmlDecletaion = false)
        {
            string _ret = string.Empty;
            try
            {
                if (objectToSerialize != null)
                {
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add("", "");

                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    using (StringWriter stringWriter = new StringWriter())
                    {
                        using (XmlTextWriter xmlWriter = new XmlTextWriter(stringWriter) { Formatting = System.Xml.Formatting.Indented })
                        {
                            if (removeXmlDecletaion)
                            {
                                xmlSerializer.Serialize(xmlWriter, objectToSerialize, ns);
                            }
                            else
                            {
                                xmlSerializer.Serialize(xmlWriter, objectToSerialize);
                            }
                            _ret = stringWriter.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(string.Empty, ex);
            }
            return _ret;
        }

        public static T ConvertXmlToObject<T>(object xmlRes) where T : class
        {
            try
            {
                if (xmlRes != null)
                {

                    T deserializedRes = null;
                    if (xmlRes is string)
                    {
                        deserializedRes = (xmlRes as string).ToDeserialize<T>();
                    }
                    else
                    {
                        deserializedRes = null;
                    }
                    return deserializedRes;
                }
                else
                { return default(T); }
            }
            catch (Exception ex)
            {
                Logger.Error(string.Empty, ex);
                return default(T);
            }
        }

        public static T ToDeserialize<T>(this string str) where T : class
        {
            if (!string.IsNullOrEmpty(str))
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        writer.Write(str);
                        writer.Flush();
                        stream.Position = 0;

                        XmlSerializer serializer = new XmlSerializer(typeof(T));
                        return serializer.Deserialize(stream) as T;
                    }
                }
            }
            else
            {
                return default(T);
            }
        }
    }
}
