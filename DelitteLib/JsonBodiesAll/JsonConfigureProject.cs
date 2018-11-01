using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelitteLib.JsonBodiesAll
{
    public class JsonConfigureProject
    {
        public JsonConfigureProject(string due_date, string end_month, string end_year, string start_month, string start_year)
        {
            this.due_date = due_date;
            this.end_month = end_month;
            this.end_year = end_year;
            this.start_month = start_month;
            this.start_year = start_year;
        }

        public string due_date { get; set; }
        public string end_month { get; set; }
        public string end_year { get; set; }
        public string start_month { get; set; }
        public string start_year { get; set; }
    }
}
