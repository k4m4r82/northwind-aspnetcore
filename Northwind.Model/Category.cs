using System;
using System.Collections.Generic;
using System.Text;

using Dapper.Contrib.Extensions;

namespace Northwind.Model
{
    [Table("categories")]
    public class Category
    {
        [ExplicitKey]
        public int categoryid { get; set; }
        public string categoryname { get; set; }
        public string description { get; set; }
    }
}
