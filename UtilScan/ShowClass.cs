using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace UtilScan
{
    public class ShowClass
    {
        static ShowClass()
        {
            JObject o1 = JObject.Parse(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "classLinkStorage.json"));
            ClassList classCollection = JsonConvert.DeserializeObject<ClassList>(o1.ToString());
            //give json objects parsed to static collection
            AllClasses = classCollection.classList;
            Console.WriteLine(classCollection.classList.Count);
        }
        private static List<Classes> allClasses;

        public static List<Classes> AllClasses { get => allClasses; set => allClasses = value; }
    
        public static List<Classes> GetClasses()
        {
            return AllClasses;
        }
    }
}
