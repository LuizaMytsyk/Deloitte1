using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelitteLib.JsonBodies
{
    public class JsonLogin
    {
        public JsonLogin(string username, string password)
        {
            this.username = username;
            this.password = password;
;
        }

        public string username { get; set; }
        public string password { get; set; }
    }
}