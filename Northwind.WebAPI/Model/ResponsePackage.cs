using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Northwind.WebAPI.Model
{
    public class ResponsePackage
    {
        public ResponsePackage()
        {
            Status = new Status();
            Results = new List<object>();
        }

        public ResponsePackage(HttpStatusCode httpStatusCode)
            : this()
        {
            Status.Code = Convert.ToInt32(httpStatusCode);
            Status.Description = httpStatusCode.ToString();
        }

        public ResponsePackage(List<string> errors)
            : this()
        {
            Status.Code = Convert.ToInt32(HttpStatusCode.BadRequest);
            Status.Description = HttpStatusCode.BadRequest.ToString();
            Status.Errors = errors;
        }

        public Status Status { get; set; }
        public object Results { get; set; }
    }
}
