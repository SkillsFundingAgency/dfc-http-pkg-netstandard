using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace DFC.HTTP.Standard
{
    public interface IHttpResponseMessageHelper
    {
        HttpResponseMessage Ok();
        HttpResponseMessage Ok(Guid id);
        HttpResponseMessage Ok(string resourceJson);
        HttpResponseMessage Created();
        HttpResponseMessage Created(string resourceJson);
        HttpResponseMessage NoContent();
        HttpResponseMessage NoContent(Guid id);
        HttpResponseMessage BadRequest();
        HttpResponseMessage BadRequest(Guid id);
        HttpResponseMessage Forbidden();
        HttpResponseMessage Forbidden(Guid id);
        HttpResponseMessage UnprocessableEntity();
        HttpResponseMessage UnprocessableEntity(HttpRequest req);
        HttpResponseMessage UnprocessableEntity(List<ValidationResult> errors);
        HttpResponseMessage UnprocessableEntity(JsonException requestException);
    }
}
