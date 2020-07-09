using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilScan
{
    public class WebLinks
    {
        public WebLinks(string a)
        {
            this.stringLink = a;
            this.status = "Not checked";
            this.lastUpdated = new DateTime();
        }
        public string stringLink { get; set; }
        public string status { get; set; }
        public DateTime lastUpdated { get; set; }
    }
}
