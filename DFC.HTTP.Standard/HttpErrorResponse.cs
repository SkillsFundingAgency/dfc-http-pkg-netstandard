using System;
using System.Collections.Generic;
using System.Text;

namespace DFC.HTTP.Standard
{
    public class HttpErrorResponse
    {
        public List<string> Errors { get; set; }
        public Guid CorrelationId { get; set; }

        public HttpErrorResponse(List<string> errors, Guid correlationId)
        {
            Errors = errors;
            CorrelationId = correlationId;
        }
    }
}
