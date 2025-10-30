using illumiyaFramework.Converters;
using illumiyaFramework.Log;
using illumiyaFramework.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace illumiyaFramework.Helpers
{
    public static class HttpHelper
    {
        public static TResult PostJsonAction<TResult>(string url, string request, List<KeyValuePair<string, string>> headerKeys = null, string method = "POST")
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    try
                    {
                        Uri uri = new Uri(url);
                        client.Headers[HttpRequestHeader.ContentType] = "application/json";
                        client.Encoding = Encoding.UTF8;
                        if (headerKeys != null && headerKeys.Any())
                        {
                            foreach (var key in headerKeys)
                            {
                                client.Headers.Add(key.Key, key.Value);
                            }
                        }
                        ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };

                        if (method == "GET")
                        {
                            WebRequest webRequest = WebRequest.Create(url);
                            if (headerKeys != null && headerKeys.Any())
                            {
                                foreach (var key in headerKeys)
                                {
                                    webRequest.Headers.Add(key.Key, key.Value);
                                }
                            }


                            webRequest.ContentType = "application/json";
                            using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
                            {
                                using (Stream stream = webResponse.GetResponseStream())
                                {
                                    using (StreamReader reader = new StreamReader(stream))
                                    {
                                        string JsonString = reader.ReadToEnd().Trim().Replace("\t", string.Empty).Replace("\n", string.Empty).Replace("\r", string.Empty);
                                        TResult results = JsonConvert.DeserializeObject<TResult>(JsonString);
                                        return results;
                                    }
                                }
                            }
                        }

                        else
                        {
                            var jsonResult = client.UploadString(url, method, request);
                            if (jsonResult == null)
                            {
                                return default(TResult);
                            }

                            if (typeof(TResult) == typeof(object))
                            {
                            }
                            else
                            {
                                TResult results = JsonConvert.DeserializeObject<TResult>(jsonResult);
                                return results;
                            }
                        }
                    }
                    catch (WebException wex)
                    {
                        string error = string.Empty;
                        if (wex.Response != null)
                        {
                            using (var errorResponse = (HttpWebResponse)wex.Response)
                            {
                                using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                                {
                                    error = reader.ReadToEnd();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Error(string.Empty, ex);
                    }
                    return default(TResult);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(string.Empty, ex);
            }
            return default(TResult);
        }

        public static ServiceResponse SendHttpRequestAsync(string xmlRequest, string serverUrl = "", string serverName = "")
        {
            var srvResponse = new ServiceResponse();
            bool success = false;

            try
            {
                var uriRet = GetUri(xmlRequest, serverUrl, serverName);

                string uri = uriRet.Item1;
                var data = Encoding.UTF8.GetBytes(uriRet.Item2);

                ServicePointManager.Expect100Continue = false;

                HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                // ASYNC: using awaitable wrapper to get request stream
                using (var postStream = request.GetRequestStream())
                {
                    // Write to the request stream.
                    // ASYNC: writing to the POST stream can be slow
                    postStream.WriteAsync(data, 0, data.Length);
                }

                // ASYNC: using awaitable wrapper to get response
                var response = (HttpWebResponse)request.GetResponse();
                if (response != null)
                {
                    var reader = new StreamReader(response.GetResponseStream());
                    // ASYNC: using StreamReader's async method to read to end, in case
                    // the stream i slarge.
                    srvResponse.ResponseXml = reader.ReadToEnd();
                    success = true;
                }
                else
                {
                    success = false;
                }
            }
            catch (Exception ex)
            {
                //Logger.LogData(ex, logFileName);

                srvResponse.Message = ex.Message;
                success = false;
            }
            finally
            {
                srvResponse.Success = success;
            }
            return srvResponse;
        }

        public static async Task<ServiceResponse> SendHttpRequestAsync(string requestUrl, string method = "POST", List<KeyValuePair<string, string>> headerKeys = null, string contentType = "application/x-www-form-urlencoded", int timeOut = 60000)
        {
            var response = new ServiceResponse();
            return await Task.Run(() =>
            {
                try
                {
                    WebRequest webRequest = WebRequest.Create(requestUrl);
                    webRequest.Method = method;
                    webRequest.Timeout = timeOut;
                    byte[] bytes = Encoding.ASCII.GetBytes(requestUrl);
                    if (headerKeys != null && headerKeys.Any())
                    {
                        foreach (var key in headerKeys)
                        {
                            webRequest.Headers.Add(key.Key, key.Value);
                        }
                    }

                    //webRequest.ContentLength = bytes.Length;
                    if (webRequest.Method == "GET")
                    {
                        //"application/json"
                        System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };

                        webRequest.ContentType = contentType;
                        using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
                        {
                            using (Stream stream = webResponse.GetResponseStream())
                            {
                                using (StreamReader reader = new StreamReader(stream))
                                {
                                    string JsonString = reader.ReadToEnd().Trim().Replace("\t", string.Empty).Replace("\n", string.Empty).Replace("\r", string.Empty);
                                    response.Success = true;
                                    response.ResponseXml = JsonString;
                                }
                            }
                        }
                    }
                    else
                    {
                        webRequest.ContentType = contentType;
                        using (Stream os = webRequest.GetRequestStream())
                        {
                            os.Write(bytes, 0, bytes.Length);
                            using (WebResponse webResponse = webRequest.GetResponse())
                            {
                                if (webResponse != null)
                                {
                                    using (StreamReader reader = new StreamReader(webResponse.GetResponseStream()))
                                    {
                                        string JsonString = reader.ReadToEnd().Trim();
                                        response.Success = true;
                                        response.ResponseXml = JsonString;
                                    }
                                }
                                else
                                {
                                    response.Success = false;
                                    response.Message = "";//TBD
                                }
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    Logger.Error(string.Empty, ex);
                }
                return response;
            });
        }


        private static Tuple<string, string> GetUri(string xmlRequest, string serverUrl, string serverName)
        {
            string uri = serverUrl;
            string parameters = "xml=" + xmlRequest;

            //if (isProduction)
            // {
            //If it's a booking request the send with https uri
            uri = serverUrl;
            parameters = string.Format("{0}&{1}", serverName, parameters);// "serverName=www.rentalcars.com&" + parameters;
            //}

            return new Tuple<string, string>(uri, parameters);
        }

        public static TResult SendSoapRequest<TResult>(string url, string requestXML) where TResult : class
        {
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
                webRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
                webRequest.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
                webRequest.ContentType = "text/xml;charset=\"utf-8\"";
                webRequest.Accept = "text/xml";
                webRequest.Method = "POST";
                webRequest.Timeout = 3000;
                webRequest.KeepAlive = true;

                using (var streamWriter = new StreamWriter(webRequest.GetRequestStream()))
                {
                    streamWriter.Write(requestXML);
                }

                using (var webResponse = ((HttpWebResponse)(webRequest.GetResponse())))
                {
                    using (var streamReader = new StreamReader(webResponse.GetResponseStream(), Encoding.GetEncoding("utf-8")))
                    {
                        var responseXml = streamReader.ReadToEnd().Trim();
                        if (!string.IsNullOrEmpty(responseXml))
                        {
                            var response = XmlConvertor.ConvertXmlToObject<TResult>(responseXml);

                            return response;
                        }
                    }
                }
            }
            catch (WebException wex)
            {
                string error = string.Empty;
                if (wex.Response != null)
                {
                    using (var errorResponse = (HttpWebResponse)wex.Response)
                    {
                        using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                        {
                            error = reader.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(string.Empty, ex);
            }

            return default(TResult);
        }
    }
}
