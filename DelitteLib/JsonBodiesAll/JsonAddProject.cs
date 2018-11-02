using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelitteLib.JsonBodiesAll
{
    public class JsonAddProject
    {                 

        public JsonAddProject()
        {
            due_date = DateTime.Now.ToString("yyyy-MM-dd");
            end_month = DateTime.Now.AddMonths(2).Month.ToString("00");
            end_year = DateTime.Now.AddYears(1).ToString("yyyy");
            name = "test_project_" + DateTime.Now.ToString("yyyyMMddHHmm");
            methodologies = new List<string> { "f05248ed-dea8-4ccd-9af0-48196949259c" };
            start_month = DateTime.Now.Month.ToString("00");
            start_year = DateTime.Now.ToString("yyyy");
            type = "Adhoc";
        }

        public string due_date { get; set; }
        public string end_month { get; set; }
        public string end_year { get; set; }
        public string name { get; set; }
        public List<string> methodologies { get; set; }
        public string start_month { get; set; }
        public string start_year { get; set; }
        public string type { get; set; }
    }
}