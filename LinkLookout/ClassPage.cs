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
        }
        private void ClassPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Do you really want to exit?", "Dialog Title", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Dispose(true);
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
        private void button2_Click(object sender, EventArgs e)
        { 
            scanLink.webScanner();
            //Debug code
            //String output = scanLink.serializeJSON();
            //textBox1.Text = output;
        } 
        private void addClassButton_Click(object sender, EventArgs e)
        {
            string text = textBoxClass.Text.Trim();
            if (text != "")
            {
                Classes addedClass = new Classes(textBoxClass.Text);
                addedClass.links = new List<WebLinks>();
                ShowClass.AllClasses.Add(addedClass);
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
                scanLink.serializeJSON();
                bs.ResetBindings(false);
            }   
        }

        private void DeleteLink_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to delete this link?", "Dialog Title", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                ShowClass.AllClasses.ElementAt(classBox.SelectedIndex).links.RemoveAt(linkBox.SelectedIndex);
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
            if (ShowClass.AllClasses.Count > 0)
            {
                if (text != "")
                {
                    WebLinks addedLink = new WebLinks(textBoxLink.Text);
                    if (ShowClass.AllClasses.ElementAt(classBox.SelectedIndex).links == null)
                    {
                        ls.ResetBindings(false);
                        ls.ResetBindings(false);
                        scanLink.serializeJSON();
                    }
                    ShowClass.AllClasses.ElementAt(classBox.SelectedIndex).links.Add(addedLink);
                    scanLink.serializeJSON();
                    bs.ResetBindings(false);
                    ls.ResetBindings(false);
                }
                else
                {
                    DialogResult result = MessageBox.Show("Please Enter a website link", "Dialog Title", MessageBoxButtons.OK);
                }
                textBoxLink.Text = "";
            } else
            {
                DialogResult result = MessageBox.Show("Please add a class or lecture", "Dialog Title", MessageBoxButtons.OK);
            }

        }
    }
}
