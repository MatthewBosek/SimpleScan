using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;
using System.IO;
using UtilScan;
using System.Timers;

namespace WebLinkScanner
{
    public partial class Service1 : ServiceBase
    {
        private System.Timers.Timer timer;
        public Service1()
        {
            InitializeComponent();
        }

        public void startApp()
        {
            

            string[] a = new string[] { };
            OnStart(a); 
        }
        protected override void OnStart(string[] args)
        {
            //string statusReturn = "";
            //string scanResult = "";
            writeLog();
            scanLink.webScanner();
            SetTimer();
        }

        private void writeLog()
        {
            string output = "";
            var fileName = AppDomain.CurrentDomain.BaseDirectory + "log.txt";
            FileInfo fi = new FileInfo(fileName);
            var size = fi.Length;
            if (size > 2097152)
            {
                System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "log.txt", String.Empty);
            }
            System.IO.File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "log.txt", output);
            JObject o1 = JObject.Parse(File.ReadAllText(@"C:\Users\matt2\source\repos\LinkLookout\LinkLookout\bin\outputTest.json"));
            ClassList classCollection = JsonConvert.DeserializeObject<ClassList>(o1.ToString());
            ShowClass.AllClasses = classCollection.classList;
            output = "{\"classList\": \n";
            output += JsonConvert.SerializeObject(ShowClass.AllClasses);
            output += "}";
            Console.WriteLine(output);
            File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "log.txt", output);
        }
        private void SetTimer()
        {
            if (timer == null)
            {
                timer = new System.Timers.Timer();
                timer.AutoReset = true;
                timer.Interval = 10 * 60000;
                timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
                timer.Start();
            }
        }

        private void timer_Elapsed(object source, System.Timers.ElapsedEventArgs e)
        {
            //Do some thing logic here
            writeLog();
            scanLink.webScanner();
        }

        protected override void OnStop()
        {
            Dispose(true);
            DialogResult result = MessageBox.Show("Service Turned Off.", "Dialog Title", MessageBoxButtons.YesNo);
        }
    }
}
