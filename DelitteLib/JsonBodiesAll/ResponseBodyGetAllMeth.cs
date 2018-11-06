using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelitteLib.JsonBodiesAll
{

    public class ResponseBodyGetAllMeth
    {
        public string status { get; set; }
        public string response_datetime { get; set; }
        public List<Datum> data { get; set; }
    }


    public class Datum
    {
        public string meth_id { get; set; }
        public object output_bucket_map { get; set; }
        public object output_dependencies { get; set; }
        public string worm_version { get; set; }
        public string effective_date { get; set; }
        public string name { get; set; }
        public object effective_end { get; set; }
        public int effective_start { get; set; }
        public string data { get; set; }
    }

 
}
