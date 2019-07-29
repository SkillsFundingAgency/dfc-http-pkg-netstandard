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
        HttpResponseMessage Ok(string content);
        HttpResponseMessage Created();
        HttpResponseMessage Created(string content);
        HttpResponseMessage Conflict();
        HttpResponseMessage Conflict(string content);
        HttpResponseMessage Conflict(HttpErrorResponse errorResponse);
        HttpResponseMessage NoContent();
        HttpResponseMessage NoContent(string content);
        HttpResponseMessage NoContent(Guid id);
        HttpResponseMessage BadRequest();
        HttpResponseMessage BadRequest(Guid id);
        HttpResponseMessage BadRequest(string content);
        HttpResponseMessage BadRequest(HttpErrorResponse errorResponse);
        HttpResponseMessage Forbidden();
        HttpResponseMessage Forbidden(Guid id);
        HttpResponseMessage Forbidden(string content);
        HttpResponseMessage Forbidden(HttpErrorResponse errorResponse);
        HttpResponseMessage UnprocessableEntity();
        HttpResponseMessage UnprocessableEntity(string content);
        HttpResponseMessage UnprocessableEntity(HttpErrorResponse errorResponse);
        HttpResponseMessage UnprocessableEntity(HttpRequest req);
        HttpResponseMessage UnprocessableEntity(List<ValidationResult> errors);
        HttpResponseMessage UnprocessableEntity(JsonException requestException);
    }
}
