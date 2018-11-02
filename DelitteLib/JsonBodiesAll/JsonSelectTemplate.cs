using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelitteLib.JsonBodiesAll
{
    class JsonSelectTemplate
    {
        public JsonSelectTemplate()
        {
            this.common = false;
            this.template_url = "/documents/v2/docloads/1dbe7262-311c-11e8-b252-0242ac110012";
        }

        public bool common { get; set; }
        public string template_url { get; set; }
    }
}