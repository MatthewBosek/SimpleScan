using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace LinkLookout
{
    public class ClassList
    {
        public List<Classes> classList { get; set; }
    }

   
    public class Classes
    {
        public Classes (string a)
        {
            this.links = null;
            this.className = a;
        }
        public string className { get; set; }
        public List<WebLinks> links { get; set; }
    }
}
