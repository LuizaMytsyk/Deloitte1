using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelitteLib.JsonBodies
{
    public class JsonCreateMethodology
    {
        public JsonCreateMethodology(string data, string name)
        {
            this.data = data;
            this.name = name;
        }

        public string data { get; set; }
        public string name { get; set; }
    }
}