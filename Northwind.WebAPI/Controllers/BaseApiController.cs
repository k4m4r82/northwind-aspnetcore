using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.WebAPI.Model;

namespace Northwind.WebAPI.Controllers
{
    public class BaseApiController : Controller
    {
        protected ResponsePackage GenerateResponse(HttpStatusCode httpStatusCode, object results, int pagesCount = 0)
        {
            var output = new ResponsePackage
            {
                Status = new Status
                {
                    Code = Convert.ToInt32(httpStatusCode),
                    PagesCount = pagesCount,
                    Description = httpStatusCode.ToString()
                },

                Results = results
            };

            return output;
        }
    }
}