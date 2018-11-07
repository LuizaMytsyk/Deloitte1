using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelitteLib.JsonBodiesAll
{

    public class ResponseBodyGetAllProjects
    {
        public string status { get; set; }
        public DateTime response_datetime { get; set; }
        public List<ProjectDatum> data { get; set; }
    }


    public class ProjectDatum
    {
        public string delivery_status { get; set; }
        public object meth_effective_date { get; set; }
        public string proj_id { get; set; }
        public int end_year { get; set; }
        public int start_month { get; set; }
        public int start_year { get; set; }
        public string created_date { get; set; }
        public string type { get; set; }
        public string due_date { get; set; }
        public object filters { get; set; }
        public int end_month { get; set; }
        public string name { get; set; }
        public object creator_id { get; set; }
        public string worm_version { get; set; }
        public string model_effective_dates { get; set; }
    }

 
}
