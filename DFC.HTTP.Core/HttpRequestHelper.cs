using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

namespace DFC.HTTP.Core
{
    public static class HttpRequestHelper
    {

        public static async Task<T> GetResourceFromRequest<T>(HttpRequest req)
        {
            if (req == null)
                throw new ArgumentNullException("req");

            if (req.Body == null)
                throw new ArgumentNullException("req.Body");

            SetContentTypeToApplicationJson(req);

            string requestBody;
            try
            {
                requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            }
            catch (Exception e)
            {
                throw;
            }

            dynamic data;

            try
            {
                data = JsonConvert.DeserializeObject<T>(requestBody);
            }
            catch (Exception)
            {
                throw;
            }

            return data;
        }

        public static void SetContentTypeToApplicationJson(HttpRequest req)
        {
            if (req == null)
                throw new ArgumentNullException("req");

            req.ContentType = ContentApplicationType.ApplicationJSON;
        }

        public static string GetQueryString(HttpRequest req, string queryStringKey)
        {
            if (req == null)
                throw new ArgumentNullException("req");

            if (!req.Query.ContainsKey(queryStringKey))
                return string.Empty;

            req.Query.TryGetValue(queryStringKey, out StringValues keys);
            return keys.FirstOrDefault();
        }

        public static string GetHeader(this HttpRequest req, string queryStringKey)
        {
            if (req == null)
                throw new ArgumentNullException("req");

            return !req.Headers.TryGetValue(queryStringKey, out StringValues keys) ? string.Empty : keys.FirstOrDefault();
        }

        public static string GetDssTouchpointId(HttpRequest req)
        {
            if (req == null)
                throw new ArgumentNullException("req");

            if (!req.Headers.ContainsKey("TouchpointId"))
                return string.Empty;

            var touchpointId = req.Headers["TouchpointId"].FirstOrDefault();

            return string.IsNullOrEmpty(touchpointId) ? string.Empty : touchpointId;
        }

        public static string GetDssCorrelationId(HttpRequest req)
        {
            if (req == null)
                throw new ArgumentNullException("req");

            if (!req.Headers.ContainsKey("DssCorrelationId"))
                return string.Empty;

            var correlationId = req.Headers["DssCorrelationId"].FirstOrDefault();

            return string.IsNullOrEmpty(correlationId) ? string.Empty : correlationId;
        }

        public static string GetDssApimURL(HttpRequest req)
        {
            if (req == null)
                throw new ArgumentNullException("req");

            if (!req.Headers.ContainsKey("apimurl"))
                return string.Empty;

            var ApimURL = req.Headers["apimurl"].FirstOrDefault();

            if (ApimURL.EndsWith("/"))
                ApimURL = ApimURL.Substring(0, ApimURL.Length - 1);


            return string.IsNullOrEmpty(ApimURL) ? string.Empty : ApimURL;
        }
    }
}
