using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelitteLib.JsonBodiesAll
{
    public class JsonConfigureProject
    {
        public JsonConfigureProject()
        {
            this.due_date = DateTime.Now.ToString("yyyy-MM-dd");
            this.end_month = DateTime.Now.AddMonths(2).Month.ToString("00");
            this.end_year = DateTime.Now.AddYears(1).ToString("yyyy");
            this.start_month = DateTime.Now.Month.ToString("00");
            this.start_year = DateTime.Now.ToString("yyyy");
        }

        public string due_date { get; set; }
        public string end_month { get; set; }
        public string end_year { get; set; }
        public string start_month { get; set; }
        public string start_year { get; set; }
    }
}