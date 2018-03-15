using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftCollection.Data.Model.ViewModal
{
    public class ResponseDetail
    {
        public string Error { get; set; }
        public string[] ErrorCode { get; set; }

        public string[] ErrorDetail { get; set; }
        public string Success { get; set; }
        public string[] SuccessCode { get; set; }

        public string[] SuccessDetail { get; set; }
        public string Warning { get; set; }
        public string[] WarningCode { get; set; }

        public string[] WarningDetail { get; set; }
    }
}
