using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudFast.Data.Domain
{
    public class ZipCode
    {
        public string zipcodeid { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public DateTime updated { get; set; }
        public string updatedby { get; set; }
    }

}