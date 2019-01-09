using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using NUnit.Framework;

namespace DFC.HTTP.Core.Tests
{
    public class HttpRequestHelperTests
    {
        private HttpRequest _request;

        [SetUp]
        public void Setup()
        {
            _request = new DefaultHttpRequest(new DefaultHttpContext())
            {
                ContentType = ContentApplicationType.ApplicationJSON,
            };
        }
        
        [Test]
        public void HttpRequestExtensions_SetContentTypeToApplicationJson_ThrowsArgumentNullException_WhenRequestIsNull()
        {
            Assert.That(() => HttpRequestHelper.SetContentTypeToApplicationJson(null),
                Throws.Exception
                    .TypeOf<ArgumentNullException>());
        }

        [Test]
        public void HttpRequestExtensions_UpdatesContentType_WhenSetContentTypeToApplicationJsonIsCalled()
        {
            _request.ContentType = ContentApplicationType.ApplicationXML;
            HttpRequestHelper.SetContentTypeToApplicationJson(_request);
            Assert.AreEqual(_request.ContentType, ContentApplicationType.ApplicationJSON);
        }

        [Test]
        public void HttpRequestExtensions_GetQueryString_ThrowsArgumentNullException_WhenRequestIsNull()
        {
            Assert.That(() => HttpRequestHelper.GetQueryString(null, string.Empty),
                Throws.Exception
                    .TypeOf<ArgumentNullException>());
        }

        [Test]
        public void HttpRequestExtensions_GetQueryString_ReturnsEmptyString_WhenQueryStringCannotBeFound()
        {
           var result = HttpRequestHelper.GetQueryString(_request, "Test");
            Assert.AreEqual(result, string.Empty);
        }

        [Test]
        public void HttpRequestExtensions_GetQueryString_ReturnsQueryString_WhenQueryStringExists()
        {
            _request.QueryString= new QueryString("?GivenName=John");

            var result = HttpRequestHelper.GetQueryString(_request, "GivenName");
            Assert.AreEqual(result, "John");
        }

        [Test]
        public void HttpRequestExtensions_GetHeader_ThrowsArgumentNullException_WhenRequestIsNull()
        {
            Assert.That(() => HttpRequestHelper.GetHeader(null, string.Empty),
                Throws.Exception
                    .TypeOf<ArgumentNullException>());
        }

        [Test]
        public void HttpRequestExtensions_GetHeader_ReturnsEmptyString_WhenHeaderDoesNotExist()
        {
            var result = HttpRequestHelper.GetHeader(_request, "Header");
            Assert.AreEqual(result, string.Empty);
        }

        [Test]
        public void HttpRequestExtensions_GetHeader_ReturnsHeaderValue_WhenHeaderExists()
        {
            _request.Headers.TryAdd("Number", "0123456789");
            var result = HttpRequestHelper.GetHeader(_request, "Number");
            Assert.AreEqual(result, "0123456789");
        }


        [Test]
        public void HttpRequestExtensions_GetTouchpointId_ThrowsArgumentNullException_WhenRequestIsNull()
        {
            Assert.That(() => HttpRequestHelper.GetTouchpointId(null),
                Throws.Exception
                    .TypeOf<ArgumentNullException>());
        }

        [Test]
        public void HttpRequestExtensions_GetTouchpointId_ReturnsEmptyString_WhenHeaderDoesNotExist()
        {
            var result = HttpRequestHelper.GetTouchpointId(_request);
            Assert.AreEqual(result, string.Empty);
        }

        [Test]
        public void HttpRequestExtensions_GetTouchpointId_ReturnsTouchpointId_WhenHeaderExists()
        {
            _request.Headers.TryAdd("TouchpointId", "0123456789");
            var result = HttpRequestHelper.GetTouchpointId(_request);
            Assert.AreEqual(result, "0123456789");
        }

        [Test]
        public void HttpRequestExtensions_GetApimURL_ThrowsArgumentNullException_WhenRequestIsNull()
        {
            Assert.That(() => HttpRequestHelper.GetApimURL(null),
                Throws.Exception
                    .TypeOf<ArgumentNullException>());
        }

        [Test]
        public void HttpRequestExtensions_GetApimURL_ReturnsEmptyString_WhenHeaderDoesNotExist()
        {
            var result = HttpRequestHelper.GetApimURL(_request);
            Assert.AreEqual(result, string.Empty);
        }

        [Test]
        public void HttpRequestExtensions_GetApimURL_ReturnsApimUrl_WhenHeaderExists()
        {
            _request.Headers.TryAdd("apimurl", "http://localhost");
            var result = HttpRequestHelper.GetApimURL(_request);
            Assert.AreEqual(result, "http://localhost");
        }


    }
}