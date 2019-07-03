using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace DFC.HTTP.Standard
{
    public class HttpResponseMessageHelper : IHttpResponseMessageHelper
    {

        #region Ok(200)

        public HttpResponseMessage Ok()
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        public HttpResponseMessage Ok(Guid id)
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(id),
                    Encoding.UTF8, ContentApplicationType.ApplicationJSON)
            };
        }

        public HttpResponseMessage Ok(string resourceJson)
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(resourceJson, Encoding.UTF8, ContentApplicationType.ApplicationJSON)
            };
        }

        #endregion

        #region Created(201) 
        public HttpResponseMessage Created()
        {
            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        public HttpResponseMessage Created(string resourceJson)
        {
            return new HttpResponseMessage(HttpStatusCode.Created)
            {
                Content = new StringContent(resourceJson, Encoding.UTF8, ContentApplicationType.ApplicationJSON)
            };
        }

        #endregion

        #region NoContent(204)

        public HttpResponseMessage NoContent()
        {
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        public HttpResponseMessage NoContent(Guid id)
        {
            return new HttpResponseMessage(HttpStatusCode.NoContent)
            {
                Content = new StringContent(JsonConvert.SerializeObject(id),
                    Encoding.UTF8, ContentApplicationType.ApplicationJSON)
            };

        }

        #endregion

        #region BadRequest(400)

        public HttpResponseMessage BadRequest()
        {
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        public HttpResponseMessage BadRequest(Guid id)
        {
            return new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new StringContent(JsonConvert.SerializeObject(id),
                    Encoding.UTF8, ContentApplicationType.ApplicationJSON)
            };
        }

        #endregion

        #region Forbidden(403)

        public HttpResponseMessage Forbidden()
        {
            return new HttpResponseMessage(HttpStatusCode.Forbidden);
        }

        public HttpResponseMessage Forbidden(Guid id)
        {
            return new HttpResponseMessage(HttpStatusCode.Forbidden)
            {
                Content = new StringContent(JsonConvert.SerializeObject(id),
                    Encoding.UTF8, ContentApplicationType.ApplicationJSON)
            };
        }

        #endregion

        #region Conflict(409)

        public static HttpResponseMessage Conflict()
        {
            return new HttpResponseMessage(HttpStatusCode.Conflict);
        }

        #endregion

        #region UnprocessableEntity(422)
        public HttpResponseMessage UnprocessableEntity()
        {
            return new HttpResponseMessage((HttpStatusCode) 422);
        }

        public HttpResponseMessage UnprocessableEntity(HttpRequest req)
        {
            return new HttpResponseMessage((HttpStatusCode)422)
            {
                Content = new StringContent(JsonConvert.SerializeObject(req),
                    Encoding.UTF8, ContentApplicationType.ApplicationJSON)
            };
        }

        public HttpResponseMessage UnprocessableEntity(List<ValidationResult> errors)
        {
            return new HttpResponseMessage((HttpStatusCode)422)
            {
                Content = new StringContent(JsonConvert.SerializeObject(errors),
                    Encoding.UTF8, ContentApplicationType.ApplicationJSON)
            };
        }

        public HttpResponseMessage UnprocessableEntity(JsonException requestException)
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
