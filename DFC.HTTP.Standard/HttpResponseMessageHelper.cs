using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace DFC.HTTP.Core
{
    public static class HttpResponseMessageHelper
    {

        #region Ok(200)

        public static HttpResponseMessage Ok()
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        public static HttpResponseMessage Ok(Guid id)
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(id),
                    Encoding.UTF8, ContentApplicationType.ApplicationJSON)
            };
        }

        public static HttpResponseMessage Ok(string resourceJson)
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(resourceJson, Encoding.UTF8, ContentApplicationType.ApplicationJSON)
            };
        }

        #endregion

        #region Created(201) 
        public static HttpResponseMessage Created()
        {
            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        public static HttpResponseMessage Created(string resourceJson)
        {
            return new HttpResponseMessage(HttpStatusCode.Created)
            {
                Content = new StringContent(resourceJson, Encoding.UTF8, ContentApplicationType.ApplicationJSON)
            };
        }

        #endregion

        #region NoContent(204)

        public static HttpResponseMessage NoContent()
        {
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        public static HttpResponseMessage NoContent(Guid id)
        {
            return new HttpResponseMessage(HttpStatusCode.NoContent)
            {
                Content = new StringContent(JsonConvert.SerializeObject(id),
                    Encoding.UTF8, ContentApplicationType.ApplicationJSON)
            };

        }

        #endregion

        #region BadRequest(400)

        public static HttpResponseMessage BadRequest()
        {
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        public static HttpResponseMessage BadRequest(Guid id)
        {
            return new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new StringContent(JsonConvert.SerializeObject(id),
                    Encoding.UTF8, ContentApplicationType.ApplicationJSON)
            };
        }

        #endregion

        #region Forbidden(403)

        public static HttpResponseMessage Forbidden()
        {
            return new HttpResponseMessage(HttpStatusCode.Forbidden);
        }

        public static HttpResponseMessage Forbidden(Guid id)
        {
            return new HttpResponseMessage(HttpStatusCode.Forbidden)
            {
                Content = new StringContent(JsonConvert.SerializeObject(id),
                    Encoding.UTF8, ContentApplicationType.ApplicationJSON)
            };
        }

        #endregion

        #region UnprocessableEntity(422)
        public static HttpResponseMessage UnprocessableEntity()
        {
            return new HttpResponseMessage((HttpStatusCode) 422);
        }

        public static HttpResponseMessage UnprocessableEntity(HttpRequest req)
        {
            return new HttpResponseMessage((HttpStatusCode)422)
            {
                Content = new StringContent(JsonConvert.SerializeObject(req),
                    Encoding.UTF8, ContentApplicationType.ApplicationJSON)
            };
        }

        public static HttpResponseMessage UnprocessableEntity(List<ValidationResult> errors)
        {
            return new HttpResponseMessage((HttpStatusCode)422)
            {
                Content = new StringContent(JsonConvert.SerializeObject(errors),
                    Encoding.UTF8, ContentApplicationType.ApplicationJSON)
            };
        }

        public static HttpResponseMessage UnprocessableEntity(JsonException requestException)
        {
            return new HttpResponseMessage((HttpStatusCode)422)
            {
                Content = new StringContent(JsonConvert.SerializeObject(requestException),
                    Encoding.UTF8, ContentApplicationType.ApplicationJSON)
            };
        }


        #endregion

    }
}
