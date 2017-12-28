using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.WebAPI.Model
{
    public class Status
    {
        public Status()
        {
            Errors = new List<string>();
        }

        public int Code { get; set; }
        public int PagesCount { get; set; }
        public string Description { get; set; }
        public List<string> Errors { get; set; }
    }
}
