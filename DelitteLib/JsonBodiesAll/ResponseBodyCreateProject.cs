using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelitteLib.JsonBodiesAll
{
    public class ResponseBodyCreateProject
    {
        public ResponseBodyCreateProject()
        {
        }

        public Data data { get; set; }
        public DateTime response_datetime { get; set; }
        public string status { get; set; }
    }

    public class Data

    {
        public Data()
        {
        }

            public string data { get; set; }
            public string name { get; set; }
            public long effective_end { get; set; }
            public int effective_start { get; set; }
            public List<object> output_dependencies { get; set; }
            public object output_bucket_map { get; set; }
            public string worm_version { get; set; }
            public string meth_id { get; set; }
            public string methodology_status { get; set; }
       }

     
    }

