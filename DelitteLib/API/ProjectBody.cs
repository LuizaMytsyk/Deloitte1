using System;
using System.Collections.Generic;
using RestSharp;

namespace DelitteLib.API
{
    public class ProjectBody
    {
        private string due_date {get; set;}
        private string end_month { get; set; }
        private string end_year { get; set; }
        private string name { get; set; }
        private string start_month { get; set; }
        private string start_year { get; set; }
        private string type { get; set; }
              
    }
}
