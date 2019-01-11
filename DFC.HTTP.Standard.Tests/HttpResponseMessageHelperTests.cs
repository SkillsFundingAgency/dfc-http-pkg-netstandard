using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using NSubstitute;
using NUnit.Framework;

namespace DFC.HTTP.Standard.Tests
{
    [TestFixture]
    public class HttpResponseMessageHelperTests
    {
        private IHttpResponseMessageHelper _httpResponseMessageHelper;

        [SetUp]
        public void Setup()
        {
            _httpResponseMessageHelper = Substitute.For<IHttpResponseMessageHelper>();
        }

        [Test]
        public void HttpResponseMessageHelperTests_ReturnsStatusCodeOK_WhenHttpResponseMessageOkIsCalled()
        {
            _httpResponseMessageHelper.Ok().Returns(x => new HttpResponseMessage(HttpStatusCode.OK));

            var response = _httpResponseMessageHelper.Ok();

            Assert.IsInstanceOf<HttpResponseMessage>(response);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public void HttpResponseMessageHelperTests_ReturnsStatusCodeOK_WhenHttpResponseMessageOkIsCalledWithGuid()
        {
            _httpResponseMessageHelper.Ok(Arg.Any<Guid>()).Returns(x => new HttpResponseMessage(HttpStatusCode.OK));

            var response = _httpResponseMessageHelper.Ok(Arg.Any<Guid>());

            Assert.IsInstanceOf<HttpResponseMessage>(response);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public void HttpResponseMessageHelperTests_ReturnsStatusCodeOK_WhenHttpResponseMessageOkIsCalledWithString()
        {
            _httpResponseMessageHelper.Ok(Arg.Any<string>()).Returns(x => new HttpResponseMessage(HttpStatusCode.OK));

            var response = _httpResponseMessageHelper.Ok("");

            Assert.IsInstanceOf<HttpResponseMessage>(response);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public void HttpResponseMessageHelperTests_ReturnsStatusCodeCreated_WhenHttpResponseMessageCreatedIsCalled()
        {
            _httpResponseMessageHelper.Created().Returns(x => new HttpResponseMessage(HttpStatusCode.Created));

            var response = _httpResponseMessageHelper.Created();

            Assert.IsInstanceOf<HttpResponseMessage>(response);
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }

        [Test]
        public void HttpResponseMessageHelperTests_ReturnsStatusCodeCreated_WhenHttpResponseMessageCreatedIsCalledWithString()
        {
            _httpResponseMessageHelper.Created(Arg.Any<string>()).Returns(x => new HttpResponseMessage(HttpStatusCode.Created));

            var response = _httpResponseMessageHelper.Created("");

            Assert.IsInstanceOf<HttpResponseMessage>(response);
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }

        [Test]
        public void HttpResponseMessageHelperTests_ReturnsStatusCodeBadRequest_WhenHttpResponseMessageBadRequestIsCalled()
        {
            _httpResponseMessageHelper.BadRequest().Returns(x => new HttpResponseMessage(HttpStatusCode.BadRequest));

            var response = _httpResponseMessageHelper.BadRequest();

            Assert.IsInstanceOf<HttpResponseMessage>(response);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Test]
        public void HttpResponseMessageHelperTests_ReturnsStatusCodeBadRequest_WhenHttpResponseMessageBadRequestIsCalledWithGuid()
        {
            _httpResponseMessageHelper.BadRequest(Arg.Any<Guid>()).Returns(x => new HttpResponseMessage(HttpStatusCode.BadRequest));

            var response = _httpResponseMessageHelper.BadRequest(Arg.Any<Guid>());

            Assert.IsInstanceOf<HttpResponseMessage>(response);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }


        [Test]
        public void HttpResponseMessageHelperTests_ReturnsStatusCodeForbidden_WhenHttpResponseMessageForbiddenRequestIsCalled()
        {
            _httpResponseMessageHelper.Forbidden().Returns(x => new HttpResponseMessage(HttpStatusCode.Forbidden));

            var response = _httpResponseMessageHelper.Forbidden();

            Assert.IsInstanceOf<HttpResponseMessage>(response);
            Assert.AreEqual(HttpStatusCode.Forbidden, response.StatusCode);
        }

        [Test]
        public void HttpResponseMessageHelperTests_ReturnsStatusCodeForbidden_WhenHttpResponseMessageForbiddenRequestIsCalledWithGuid()
        {
            _httpResponseMessageHelper.BadRequest(Arg.Any<Guid>()).Returns(x => new HttpResponseMessage(HttpStatusCode.Forbidden));

            var response = _httpResponseMessageHelper.BadRequest(Arg.Any<Guid>());

            Assert.IsInstanceOf<HttpResponseMessage>(response);
            Assert.AreEqual(HttpStatusCode.Forbidden, response.StatusCode);
        }

        [Test]
        public void HttpResponseMessageHelperTests_ReturnsStatusCodeUnprocessableEntity_WhenHttpResponseMessageUnprocessableEntityIsCalled()
        {
            _httpResponseMessageHelper.UnprocessableEntity().Returns(x => new HttpResponseMessage((HttpStatusCode)422));

            var response = _httpResponseMessageHelper.UnprocessableEntity();

            Assert.IsInstanceOf<HttpResponseMessage>(response);
            Assert.AreEqual(422, (int)response.StatusCode);
        }

        [Test]
        public void HttpResponseMessageHelperTests_ReturnsStatusCodeUnprocessableEntity_WhenHttpResponseMessageUnprocessableEntityIsCalledWithRequest()
        {
            _httpResponseMessageHelper.UnprocessableEntity(Arg.Any<HttpRequest>()).Returns(x => new HttpResponseMessage((HttpStatusCode)422));

            var response = _httpResponseMessageHelper.UnprocessableEntity(Arg.Any<HttpRequest>());

            Assert.IsInstanceOf<HttpResponseMessage>(response);
            Assert.AreEqual(422, (int)response.StatusCode);
        }

        [Test]
        public void HttpResponseMessageHelperTests_ReturnsStatusCodeUnprocessableEntity_WhenHttpResponseMessageUnprocessableEntityIsCalledWithValidationResult()
        {
            _httpResponseMessageHelper.UnprocessableEntity(Arg.Any<List<ValidationResult>>()).Returns(x => new HttpResponseMessage((HttpStatusCode)422));

            var response = _httpResponseMessageHelper.UnprocessableEntity(new List<ValidationResult>());

            Assert.IsInstanceOf<HttpResponseMessage>(response);
            Assert.AreEqual(422, (int)response.StatusCode);
        }

        [Test]
        public void HttpResponseMessageHelperTests_ReturnsStatusCodeUnprocessableEntity_WhenHttpResponseMessageUnprocessableEntityIsCalledWithJsonException()
        {
            _httpResponseMessageHelper.UnprocessableEntity(Arg.Any<JsonException>()).Returns(x => new HttpResponseMessage((HttpStatusCode)422));

            var response = _httpResponseMessageHelper.UnprocessableEntity(Arg.Any<JsonException>());

            Assert.IsInstanceOf<HttpResponseMessage>(response);
            Assert.AreEqual(422, (int)response.StatusCode);
        }
    }
}