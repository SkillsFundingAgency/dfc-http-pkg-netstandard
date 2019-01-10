using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

namespace DFC.HTTP.Standard
{
    public static class HttpRequestHelper
    {

        public static async Task<T> GetResourceFromRequest<T>(HttpRequest req)
        {
            if (req == null)
                throw new ArgumentNullException(nameof(req));

            if (req.Body == null)
                throw new ArgumentNullException(nameof(req.Body));

            SetContentTypeToApplicationJson(req);

            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            dynamic data = JsonConvert.DeserializeObject<T>(requestBody);

            return data;
        }

        public static void SetContentTypeToApplicationJson(HttpRequest req)
        {
            if (req == null)
                throw new ArgumentNullException(nameof(req));

            req.ContentType = ContentApplicationType.ApplicationJSON;
        }

        public static string GetQueryString(HttpRequest req, string queryStringKey)
        {
            if (req == null)
                throw new ArgumentNullException(nameof(req));

            if (!req.Query.ContainsKey(queryStringKey))
                return string.Empty;

            req.Query.TryGetValue(queryStringKey, out StringValues keys);
            return keys.FirstOrDefault();
        }

        public static string GetHeader(this HttpRequest req, string queryStringKey)
        {
            if (req == null)
                throw new ArgumentNullException(nameof(req));

            return !req.Headers.TryGetValue(queryStringKey, out StringValues keys) ? string.Empty : keys.FirstOrDefault();
        }

        public static string GetDssTouchpointId(HttpRequest req)
        {
            if (req == null)
                throw new ArgumentNullException(nameof(req));

            if (!req.Headers.ContainsKey("TouchpointId"))
                return string.Empty;

            var touchpointId = req.Headers["TouchpointId"].FirstOrDefault();

            return string.IsNullOrEmpty(touchpointId) ? string.Empty : touchpointId;
        }

        public static string GetDssCorrelationId(HttpRequest req)
        {
            if (req == null)
                throw new ArgumentNullException(nameof(req));

            if (!req.Headers.ContainsKey("DssCorrelationId"))
                return string.Empty;

            var correlationId = req.Headers["DssCorrelationId"].FirstOrDefault();

            return string.IsNullOrEmpty(correlationId) ? string.Empty : correlationId;
        }

        public static string GetDssSubcontractorId(HttpRequest req)
        {
            if (req == null)
                throw new ArgumentNullException(nameof(req));

            if (!req.Headers.ContainsKey("DssSubcontractorId"))
                return string.Empty;

            var subcontractorId = req.Headers["DssSubcontractorId"].FirstOrDefault();

            return string.IsNullOrEmpty(subcontractorId) ? string.Empty : subcontractorId;
        }

        public static string GetDssApimUrl(HttpRequest req)
        {
            if (req == null)
                throw new ArgumentNullException(nameof(req));

            if (!req.Headers.ContainsKey("apimurl"))
                return string.Empty;

            var apimUrl = req.Headers["apimurl"].FirstOrDefault();

            if (apimUrl.EndsWith("/"))
                apimUrl = apimUrl.Substring(0, apimUrl.Length - 1);

            return string.IsNullOrEmpty(apimUrl) ? string.Empty : apimUrl;
        }
    }
}