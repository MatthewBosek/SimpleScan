using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using Newtonsoft.Json.Schema;
using System.Net.Http;
using UtilScan;

namespace LinkLookout
{
    public partial class ClassPage : Form
    {
        public ClassPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Welcome w1 = new Welcome();
            w1.Show();
        }
        BindingSource bs;
        BindingSource ls;
        private void ClassPage_FormLoad(object sender, System.EventArgs e)
        {
            bs = new BindingSource();
            bs.DataSource = ShowClass.AllClasses;
            ls = new BindingSource();
            classBox.DataSource = bs;
            if (ShowClass.AllClasses.Count > 0 && ShowClass.AllClasses != null)
            {
                ls.DataSource = ShowClass.AllClasses.ElementAt(classBox.SelectedIndex).links;
            }
            else
            {
                ls.DataSource = null;
            }

            classBox.DisplayMember = "className";
            linkBox.DataSource = ls;
            linkBox.DisplayMember = "stringLink";
            //Console.WriteLine("index: " + classBox.SelectedIndex);
        }
        private void ClassPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Do you really want to exit?", "Dialog Title", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Environment.Exit(0);
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }
        private void deserializeJSONTest(string strJSON)
        {
            try
            {
                var jClass = JsonConvert.DeserializeObject<ClassList>(strJSON);
                textBox1.Text = "";
                textBox1.Text += jClass.ToString();
                textBox1.Text += "\n\n";

                foreach (var c in jClass.classList)
                {
                    textBox1.Text += "\n";
                    textBox1.Text += "Class Name: \n" + c.className;
                    Console.WriteLine("Class Name: " + c.className);
                    textBox1.Text += "\n";
                    foreach (var l in c.links)
                    {
                        textBox1.Text += "\n";
                        textBox1.Text += "WebLink: \n" + l.stringLink;
                        Console.WriteLine("WebLink: " + l.stringLink);
                        textBox1.Text += "\n";
                        textBox1.Text += "Status: \n" + l.status;
                        Console.WriteLine("Status: " + l.status);
                        textBox1.Text += "\n";
                        textBox1.Text += "lastUpdated: \n" + l.lastUpdated;
                        Console.WriteLine("lastUpdated: " + l.lastUpdated);
                        textBox1.Text += "\n";
                    }
                    textBox1.Text += "\n";
                }
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine("Problem: " + ex.Message.ToString());
            }
        }

        private void deserializeJSONT(string strJSON)
        {
            try
            {
                var jClass = JsonConvert.DeserializeObject<ClassList>(strJSON);

                foreach (var c in jClass.classList)
                {
                    foreach (var l in c.links)
                    {

                    }
                }
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine("Problem: " + ex.Message.ToString());
            }
        }
        /*  private void readJson()
          {
              /*JObject o1 = JObject.Parse(File.ReadAllText(@"C:\Users\matt2\source\repos\LinkLookout\LinkLookout\Data.json"));
  */
        // read JSON directly from a file
        /*using (StreamReader file = File.OpenText(@"C:\Users\matt2\source\repos\LinkLookout\LinkLookout\Data.json"))
        using (JsonTextReader reader = new JsonTextReader(file))
        {
            JObject jSchema = (JObject)JToken.ReadFrom(reader);
        }

        Classes c1 = JsonConvert.DeserializeObject<Classes>(File.ReadAllText(@"C:\Users\matt2\source\repos\LinkLookout\LinkLookout\Data.json"));
        using (StreamReader file = File.OpenText(@"C:\Users\matt2\source\repos\LinkLookout\LinkLookout\Data.json"))
        {
            JsonSerializer serial = new JsonSerializer();
            Classes c2 = (Classes)serial.Deserialize(file, typeof(Classes));
        }

        string a = c1.ToString();
        textBox1.Text = a;
    }*/

        private void button2_Click(object sender, EventArgs e)
        { 
            //JObject o1 = JObject.Parse(File.ReadAllText(@"C:\Users\matt2\source\repos\LinkLookout\LinkLookout\bin\sampleTest.json"));

            //deserializeJSONTest(o1.ToString());
            scanLink.webScanner();
            String output = scanLink.serializeJSON();
           textBox1.Text = output;
        } 
        private void addClassButton_Click(object sender, EventArgs e)
        {
            string text = textBoxClass.Text.Trim();
            if (text != "")
            {
                Classes addedClass = new Classes(textBoxClass.Text);
                addedClass.links = new List<WebLinks>();
                ShowClass.AllClasses.Add(addedClass);
                // this.bs.ResetBindings(false);
                /*string output = "{\"classList\": \n";
                output += JsonConvert.SerializeObject(ShowClass.AllClasses);
                output += "}";
                Console.WriteLine(output);
                Console.WriteLine("snap: " + ShowClass.AllClasses.Last().links);
                Console.WriteLine("Snapboogaloo: " + ShowClass.AllClasses.First().links);
                File.WriteAllText(@"C:\Users\matt2\source\repos\LinkLookout\LinkLookout\bin\outputTest.json", output);
                */
                scanLink.serializeJSON();
                bs.ResetBindings(false);
                if (ls.DataSource == null)
                {
                    ls.DataSource = ShowClass.AllClasses.ElementAt(classBox.SelectedIndex).links;
                    linkBox.DisplayMember = "stringLink";
                }
                ls.ResetBindings(false);
            }
            else
            {
                DialogResult result = MessageBox.Show("Please Enter a Class Name", "Dialog Title", MessageBoxButtons.OK);
            }
            textBoxClass.Text = "";

        }


        //delete class
        private void Delete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to delete this class?", "Dialog Title", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                int indexDel = classBox.SelectedIndex;
                ShowClass.AllClasses.RemoveAt(indexDel);
                /*string output = "{\"classList\": \n";
                output += JsonConvert.SerializeObject(ShowClass.AllClasses);
                output += "}";
                Console.WriteLine(output);
                File.WriteAllText(@"C:\Users\matt2\source\repos\LinkLookout\LinkLookout\bin\outputTest.json", output);*/
                scanLink.serializeJSON();
                bs.ResetBindings(false);
                //ls.ResetBindings(false);
            }   
        }

        private void DeleteLink_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to delete this link?", "Dialog Title", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //int indexDel = classBox.SelectedIndex;
                ShowClass.AllClasses.ElementAt(classBox.SelectedIndex).links.RemoveAt(linkBox.SelectedIndex);
                /*string output = "{\"classList\": \n";
                output += JsonConvert.SerializeObject(ShowClass.AllClasses);
                output += "}";
                Console.WriteLine(output);
                File.WriteAllText(@"C:\Users\matt2\source\repos\LinkLookout\LinkLookout\bin\outputTest.json", output);*/
                scanLink.serializeJSON();
                bs.ResetBindings(false);
                ls.ResetBindings(false);
            }
            else
            {
                //                  e.Cancel = true;
            }
        }

        private void classBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ShowClass.AllClasses.Count > 0 && ShowClass.AllClasses != null)
            {
                ls.DataSource = ShowClass.AllClasses.ElementAt(classBox.SelectedIndex).links;
                ls.ResetBindings(false);
            } else
            {
                ls.DataSource = null;
            }
            
        }

        private void linkBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((classBox.SelectedIndex > -1) && (linkBox.SelectedIndex > -1))
            {
                textBox1.Text = "Status:  " + ShowClass.AllClasses.ElementAt(classBox.SelectedIndex).links.ElementAt(linkBox.SelectedIndex).status + "/n: Last Updated: " + ShowClass.AllClasses.ElementAt(classBox.SelectedIndex).links.ElementAt(linkBox.SelectedIndex).status;
            } else
            {
                textBox1.Text = "";
                Console.WriteLine("no index");
            }
        }

        private void addLinkButton_Click(object sender, EventArgs e)
        {
            string text = textBoxLink.Text.Trim();
            if (text != "")
            {
                WebLinks addedLink = new WebLinks(textBoxLink.Text);
                if (ShowClass.AllClasses.ElementAt(classBox.SelectedIndex).links == null)
                {
                    ShowClass.AllClasses.ElementAt(classBox.SelectedIndex).links = new List<WebLinks>();
                    string outputtty= "{\"classList\": \n";
                    outputtty += JsonConvert.SerializeObject(ShowClass.AllClasses);
                    outputtty += "}";
                    ls.ResetBindings(false);
                    ls.ResetBindings(false);
                    File.WriteAllText(@"C:\Users\matt2\source\repos\LinkLookout\LinkLookout\bin\outputTest.json", outputtty);

                }
                ShowClass.AllClasses.ElementAt(classBox.SelectedIndex).links.Add(addedLink);
                // this.bs.ResetBindings(false);
                /* string output = "{\"classList\": \n";
                 output += JsonConvert.SerializeObject(ShowClass.AllClasses);
                 output += "}";
                 Console.WriteLine(output);
                 Console.WriteLine("snap: " + ShowClass.AllClasses.ElementAt(classBox.SelectedIndex).links);
                 //Console.WriteLine("Snapboogaloo: " + ShowClass.AllClasses.First().links);
                 File.WriteAllText(@"C:\Users\matt2\source\repos\LinkLookout\LinkLookout\bin\outputTest.json", output);*/
                scanLink.serializeJSON();
                bs.ResetBindings(false);
                ls.ResetBindings(false);
            }
            else
            {
                DialogResult result = MessageBox.Show("Please Enter a website link", "Dialog Title", MessageBoxButtons.OK);
            }
            textBoxLink.Text = "";
        }
    }
}
