using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelitteLib.JsonBodiesAll
{
    public class JsonSelectTemplate
    {
        public JsonSelectTemplate()
        {
            this.common = false;
            this.template_url = "/documents/v2/docloads/4e1bb7ca-7f62-11e8-88bf-0242ac110005";
        }

        public bool common { get; set; }
        public string template_url { get; set; }
    }
}