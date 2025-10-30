using illumiyaFramework.Log;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace illumiyaFramework.Converters
{
    public static class XmlConvertor
    {
        public static T LoadXmlFile<T>(string path)
            where T : class
        {
            try
            {
                if (!path.ToLower().EndsWith(".xml"))
                {
                    path += ".xml";
                }
                var xmlPath = getResourcePath(path);

                if (File.Exists(xmlPath))
                {
                    var fileContent = File.ReadAllText(xmlPath);
                    if (!string.IsNullOrEmpty(fileContent))
                    {
                        var obj = ConvertXmlToObject<T>(fileContent);
                        return obj;
                    }
                }
                else
                {
                    Logger.Error("");
                }
            }
            catch (Exception ex)
            {
                Logger.Error("", ex);
            }
            return null;
        }
        public static bool ConvertXmlToObject(string fileLocation, ref object obj)
        {
            bool isOK = false;
            try
            {
                string data = File.ReadAllText(fileLocation);
                XmlReader reader = XmlReader.Create(new StringReader(data));

                XmlSerializer xs = new XmlSerializer(obj.GetType());
                obj = xs.Deserialize(reader);
                reader.Close();
                isOK = true;
            }
            catch (Exception ex)
            {
                Logger.Error(string.Empty, ex);
            }


            return isOK;
        }

        public static string ConvertToXml<T>(T objectToSerialize, bool removeXmlDecletaion = false, bool removeFormating = true)
        {
            string _ret = "";
            try
            {

                if (objectToSerialize != null)
                {
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add("", "");

                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

                    StringWriter stringWriter = new StringWriter();
                    XmlTextWriter xmlWriter = new XmlTextWriter(stringWriter);

                    xmlWriter.Formatting = System.Xml.Formatting.Indented;

                    if (removeXmlDecletaion)
                    {
                        xmlSerializer.Serialize(xmlWriter, objectToSerialize, ns);
                    }
                    else
                    {
                        xmlSerializer.Serialize(xmlWriter, objectToSerialize);
                    }



                    _ret = stringWriter.ToString();
                    stringWriter.Dispose();
                    if (removeFormating)
                    {
                        _ret = _ret.Replace("\r", "").Replace("\n", "");
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

        private static string getResourcePath(string relativePath)
        {
            var root = AppDomain.CurrentDomain.BaseDirectory;
            var path = Path.Combine(root, relativePath);

            if (!path.StartsWith(root))
            {
                //throw new HttpException
                return string.Empty;
            }
            return path;
        }
    }
}
