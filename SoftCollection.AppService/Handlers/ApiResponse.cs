using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace SoftCollection.AppService.Handlers
{
    public class ApiResponse
    {
        public HttpStatusCode StatusCode { get; set; }

        public string Error { get; set; }
        public string[] ErrorCode { get; set; }

        public string[] ErrorDetail { get; set; }
        public string Success { get; set; }
        public string[] SuccessCode { get; set; }

        public string[] SuccessDetail { get; set; }
        public string Warning { get; set; }
        public string[] WarningCode { get; set; }

        public string[] WarningDetail { get; set; }


        public object Result { get; set; }

        public ApiResponse()
        {
        }

        public ApiResponse(HttpStatusCode statusCode, object result = null, string error = null, string[] errorDetail = null, string[] errorCode = null)
        {
            StatusCode = statusCode;
            Result = result;
            if (WebApiApplication.responseDetail.ErrorCode != null)
            {
                Error = WebApiApplication.responseDetail.Error;
                ErrorDetail = WebApiApplication.responseDetail.ErrorDetail;
                ErrorCode = WebApiApplication.responseDetail.ErrorCode;
                SuccessCode = null;
                Success = null;
                SuccessDetail = null;
                WarningCode = null;
                Warning = null;
                WarningDetail = null;
            }
            else
            {
                Error = null;
                ErrorDetail = null;
                ErrorCode = null;
                SuccessCode = WebApiApplication.responseDetail.SuccessCode;
                Success = WebApiApplication.responseDetail.Success;
                SuccessDetail = WebApiApplication.responseDetail.SuccessDetail;
                WarningCode = WebApiApplication.responseDetail.WarningCode;
                Warning = WebApiApplication.responseDetail.Warning;
                WarningDetail = WebApiApplication.responseDetail.WarningDetail;
            }
        }
    }
}