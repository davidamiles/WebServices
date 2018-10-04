using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Peek.Core.Json
{
    /// <summary>
    /// JSON Utilities
    /// </summary>
    public static class JsonSerializer
    {
        private static bool trustAllEnabled = false;

        /// <summary>
        /// Method(Post) for object of type T to address(URI)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="address"></param>
        /// <param name="model"></param>
        public static void PostToUrl<T>(string address, T model, bool trustAnyCertificates = true)
        {
            try
            {
                string data = JsonSerializer.Serialize(model);

                using (WebClient webClient = new WebClient())
                {
                    if (trustAnyCertificates && !trustAllEnabled)
                    {
                        // Always return true to trust any cert
                        ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                        trustAllEnabled = true;
                    }

                    webClient.Headers.Add("Content-Type", "application/json");
                    webClient.UploadData(address, "POST", ASCIIEncoding.ASCII.GetBytes(data));
                }
            }
            catch (WebException ex)
            {
                // The URI formed by combining BaseAddress, and address is invalid.
                // -or -
                // data is null.
                // - or -
                // An error occurred while sending the data.
                // -or -
                // There was no response from the server hosting the resource.
                // TODO: Log or the like...
                throw ex;
            }
            catch (System.ArgumentNullException ex)
            {
                // The address parameter is null.
                // TODO: Log or the like...
                throw ex;
            }
            catch (Exception ex)
            {
                // Something generic happened
                // TODO: Log or the like...
                throw ex;
            }
        }

        #region Serialization/Deserialization

        /// <summary>
        /// Serialize the supplied generic type to a JSON string.
        /// </summary>
        /// <typeparam name="T">Type to convert from</typeparam>
        /// <param name="object">Object to convert to JSON</param>
        /// <returns>JSON string result</returns>
        public static string Serialize<T>(T @object)
        {
            try
            {
                MemoryStream ms = new MemoryStream();

                DataContractJsonSerializerSettings settings = new DataContractJsonSerializerSettings();
                settings.DateTimeFormat = new DateTimeFormat("yyyy-MM-ddTHH:mm:ss.fffZ");

                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T), settings);
                serializer.WriteObject(ms, @object);

                string jsonString = ASCIIEncoding.ASCII.GetString(ms.GetBuffer());

                // Not sure why NULL are being removed from the resulting string.
                if (jsonString.IndexOf("\0") > 0)
                {
                    jsonString = jsonString.Substring(0, jsonString.IndexOf("\0"));
                }

                return jsonString;
            }
            catch (InvalidDataContractException ex)
            {
                // The type being serialized does not conform to data contract rules. 
                // For example, the DataContractAttribute attribute has not been applied to the type.
                // TODO: Log or the like...
                throw ex;
            }
            catch (SerializationException ex)
            {
                // There is a problem with the instance being written.
                // TODO: Log or the like...
                throw ex;
            }
            catch (QuotaExceededException ex)
            {
                // The maximum number of objects to serialize has been exceeded. Check the MaxItemsInObjectGraph property.
                // TODO: Log or the like...
                throw ex;
            }
            catch (Exception ex)
            {
                // Something generic happened
                // TODO: Log or the like...
                throw ex;
            }
        }

        /// <summary>
        /// Deserialize a JSON string to the supplied generic type.
        /// </summary>
        /// <typeparam name="T">Type to convert to</typeparam>
        /// <param name="jsonString">The JSON string</param>
        /// <returns>Object of type T from JSON</returns>
        public static T Deserialize<T>(string jsonString)
        {
            return Deserialize<T>(ASCIIEncoding.UTF8.GetBytes(jsonString));
        }

        /// <summary>
        /// Deserialize a JSON byte array to the supplied generic type.
        /// </summary>
        /// <typeparam name="T">Type to convert to</typeparam>
        /// <param name="jsonBytes">byte[] of the JSON string</param>
        /// <returns>Object of type T from JSON</returns>
        public static T Deserialize<T>(byte[] jsonBytes)
        {
            try
            {
                DataContractJsonSerializerSettings settings = new DataContractJsonSerializerSettings();
                settings.DateTimeFormat = new DateTimeFormat("yyyy-MM-ddTHH:mm:ss.fffZ");

                DataContractJsonSerializer s = new DataContractJsonSerializer(typeof(T), settings);

                return (T)s.ReadObject(new MemoryStream(jsonBytes));
            }
            // MSDN did not specify specific exceptions.
            catch (Exception ex)
            {
                // Something generic happened
                // TODO: Log or the like...
                throw ex;
            }
        }

        #endregion
    }
}
