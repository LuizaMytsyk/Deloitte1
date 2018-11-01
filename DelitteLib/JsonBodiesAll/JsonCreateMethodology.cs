using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelitteLib.JsonBodies
{
    public class JsonCreateMethodology
    {
        public JsonCreateMethodology()
        {
             data = "Test data " + DateTime.Now.ToString("yyyyMMddHHmm");
 ;           name = "Test_methodology_" + DateTime.Now.ToString("yyyyMMddHHmm");
        }

        public string data { get; set; }
        public string name { get; set; }
    }
}