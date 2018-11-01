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
        }

        public JsonAddProject(string due_date, string end_month, string end_year, string name, string start_month, string start_year, string type)
        {
            this.due_date = due_date;
            this.end_month = end_month;
            this.end_year = end_year;
            this.name = name;
            this.start_month = start_month;
            this.start_year = start_year;
            this.type = type;
        }

        public JsonAddProject(string due_date, string end_month, string end_year, string name, List<string> methodologies, string start_month, string start_year, string type)
        {
            this.due_date = due_date;
            this.end_month = end_month;
            this.end_year = end_year;
            this.name = name;
            this.methodologies = methodologies;
            this.start_month = start_month;
            this.start_year = start_year;
            this.type = type;
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
