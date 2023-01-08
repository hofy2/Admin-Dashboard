using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace template.bl.helper
{
    public class apiresponse <type>
    {
        public string code { get; set; }
        public string status { get; set; }
        public string message { get; set; }
        public type data { get; set; }
        public type error { get; set; }

    }
}
