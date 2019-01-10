using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DFC.HTTP.Standard
{
    public interface IHttpRequestHelper
    {
        Task<T> GetResourceFromRequest<T>(HttpRequest req);
        void SetContentTypeToApplicationJson(HttpRequest req);
        string GetQueryString(HttpRequest req, string queryStringKey);
        string GetHeader(HttpRequest req, string queryStringKey);
        string GetDssTouchpointId(HttpRequest req);
        string GetDssCorrelationId(HttpRequest req);
        string GetDssSubcontractorId(HttpRequest req);
        string GetDssApimUrl(HttpRequest req);
    }
}
