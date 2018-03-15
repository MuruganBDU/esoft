using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace SoftCollection.AppService.Handlers
{
    public class ResponseHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);
            return BuildApiResponse(request, response);
        }
        private static HttpResponseMessage BuildApiResponse(HttpRequestMessage request, HttpResponseMessage response)
        {
            if (response.Content.Headers.ContentType != null)
            {
                var contentType = response.Content.Headers.ContentType.ToString();
                if (contentType.Contains("image")
                    || contentType.Contains("text/plain")
                    || contentType.Contains("text/html"))
                {
                    return response;
                }
            }
            if (response.Content.Headers.ContentDisposition != null)
            {
                if (response.Content.Headers.ContentDisposition.DispositionType == "attachment")
                {
                    return response;
                }
            }
            object content;

            string errorMessage = null;
            string[] errorDesc = null;
            string[] errorCode = null;
            var statusCode = response.StatusCode;
            if (response.TryGetContentValue(out content) && !response.IsSuccessStatusCode)
            {
                HttpError error = content as HttpError;
                if (error != null)
                {
                    content = null;
                    errorMessage = error.Message;

                    if (error.ExceptionType != null && error.ExceptionType.Contains("DbEntityValidationException"))
                    {
                        errorCode = Regex.Split(error.ExceptionMessage.Substring(0, error.ExceptionMessage.Length - 2), "\r\n");
                        if (error.InnerException != null)
                        {
                            errorDesc = Regex.Split(error.InnerException.ExceptionMessage.Substring(0, error.InnerException.ExceptionMessage.Length - 2), "\r\n");
                        }
                    }
                    else if (error.ExceptionMessage != null)
                    {
                        errorCode = Regex.Split(error.ExceptionMessage, "\r\n");
                        if (error.InnerException != null)
                        {
                            errorDesc = Regex.Split(error.InnerException.ExceptionMessage, "\r\n");
                        }
                    }
                    statusCode = HttpStatusCode.OK;
                }
            }

            if (content == null && errorMessage == null)
            {
                statusCode = HttpStatusCode.NotFound;
            }

            var newResponse = request.CreateResponse(statusCode, new ApiResponse(statusCode, content, errorMessage, errorDesc, errorCode));

            foreach (var header in response.Headers)
            {
                newResponse.Headers.Add(header.Key, header.Value);
            }

            return newResponse;
        }
    }
}