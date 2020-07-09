using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace LinkLookout
{
    public class scanLink
    {
        public static async void webScanner()
        {
            if (ShowClass.AllClasses.Count > 0)
            {
                List<Classes> cl = new List<Classes>();
                for (int i = 0; i < ShowClass.AllClasses.Count; i++)
                {
                    Classes badLecture = new Classes(ShowClass.AllClasses.ElementAt(i).className);
                    badLecture.links = new List<WebLinks>();
                    cl.Add(badLecture);
                    for (int j = 0; j < ShowClass.AllClasses.ElementAt(i).links.Count; j++)
                    {
                        int statusCode = await pinger(ShowClass.AllClasses.ElementAt(i).links.ElementAt(j).stringLink);
                        Console.WriteLine(statusCode.ToString());
                        ShowClass.AllClasses.ElementAt(i).links.ElementAt(j).status = statusCode + "";
                        ShowClass.AllClasses.ElementAt(i).links.ElementAt(j).lastUpdated = DateTime.Now;
                        if (Int32.Parse(ShowClass.AllClasses.ElementAt(i).links.ElementAt(j).status) / 100 == 3 ||
                            Int32.Parse(ShowClass.AllClasses.ElementAt(i).links.ElementAt(j).status) / 100 == 4 ||
                            Int32.Parse(ShowClass.AllClasses.ElementAt(i).links.ElementAt(j).status) / 100 == 5 ||
                            Int32.Parse(ShowClass.AllClasses.ElementAt(i).links.ElementAt(j).status) == 0)
                        {
                            WebLinks badLink = new WebLinks(ShowClass.AllClasses.ElementAt(i).links.ElementAt(j).stringLink);
                            badLink.status = statusCode + "";
                            badLink.lastUpdated = DateTime.Now;
                            cl.Last().links.Add(badLink);
                        }
                    }
                }

                /* foreach (Classes lecture in ShowClass.AllClasses)
                 {
                     cl.Add(lecture);
                     foreach (WebLinks web in lecture.links)
                     {
                         //scan code here.  Ping's website
                             int statusCode = await pinger(web.stringLink);
                             Console.WriteLine(statusCode.ToString());
                             web.status = statusCode + "";
                             web.lastUpdated = DateTime.Now;
                         //add to list of bad status codes
                             if (Int32.Parse(web.status) / 100 == 3 || Int32.Parse(web.status) / 100 == 4 || Int32.Parse(web.status) / 100 == 5 || Int32.Parse(web.status) == 0)
                         {
                             int index = cl.IndexOf(lecture);
                             cl[index].links.Add(web);
                         }
                             //hoyl fuck i cant change or modify a foreachlo
                         //create an alert.  Loop through each class, if it is not arraylength 0, move on in loop, write class at top, then inner loop list stringLink and say webstatus is bad
                     }
                 }*/


                if (cl.Count > 0)
                {
                    String message = "The following classes and weblinks are down:\r";
                    foreach (Classes lecture in cl)
                    {
                        if (lecture.links.Count > 0)
                        {
                            message += lecture.className + ":  \r";
                            foreach (WebLinks web in lecture.links)
                            {
                                message += "\t" + web.stringLink + "\r\t" + web.lastUpdated + "\r";
                            }
                            message += "\r";
                        }
                    }
                    DialogResult result = MessageBox.Show(message, "Dialog Title", MessageBoxButtons.YesNo);
                }
            } else
            {
                DialogResult result = MessageBox.Show("There are no links to scan, please add links", "Dialog Title", MessageBoxButtons.YesNo);
            }
        }
        private static async Task<int> pinger(string url)
        {
            int StatusCode = 0;
            try
            {   
                HttpClient Client = new HttpClient();
                var result = await Client.GetAsync(url);
                StatusCode = (int)result.StatusCode;
                return StatusCode;
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(url + " is not a valid link, please follow format: https://www.website.com or no longer exists", "Dialog Title", MessageBoxButtons.YesNo);
                return StatusCode;
            }
        }

        public static string serializeJSON()
        {
            string output = "{\"classList\": \n";
            output += JsonConvert.SerializeObject(ShowClass.AllClasses);
            output += "}";
            Console.WriteLine(output);
            Console.WriteLine("snap: " + ShowClass.AllClasses.Last().links);
            Console.WriteLine("Snapboogaloo: " + ShowClass.AllClasses.First().links);
            File.WriteAllText(@"C:\Users\matt2\source\repos\LinkLookout\LinkLookout\bin\outputTest.json", output);
            return output;
        }
    }

}
