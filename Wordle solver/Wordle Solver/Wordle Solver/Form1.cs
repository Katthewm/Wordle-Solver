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

namespace Wordle_Solver
{
    public partial class Form1 : Form
    {
        List<string> words = new List<string>();
        List<string> workingset = new List<string>();
        public Form1()
        {
            InitializeComponent();
            loadfile();
        }

        private void loadfile()
        {
            string[] lines = File.ReadAllLines(@"C:/Users/mattk/Desktop/test.txt");

            foreach (string line in lines)
            {
                words.Add(line);
            }
            textBox14.Text = words.Count.ToString();
            words.Sort();
            workingset = words;
            printoutwords();
        }

        private void printoutwords()
        {
            string line = "";
            textBox8.Text = "";
            foreach(string word in workingset)
            {
                line=line+word+System.Environment.NewLine;
            }
            textBox8.Text = line;
            textBox14.Text=words.Count.ToString();
        }

        //delete a letter
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length != 1)
            {
                return;
            }
            for(int i=0; i< workingset.Count; i++)
            {
                if(workingset[i].Contains(textBox1.Text)==true)
                {
                    workingset.RemoveAt(i);
                }
            }
            printoutwords();
        }

        //contains a letter
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length != 1)
            {
                return;
            }
            for (int i = 0; i < workingset.Count; i++)
            {
                if (workingset[i].Contains(textBox2.Text)==false)
                {
                    workingset.RemoveAt(i);
                }
            }
            printoutwords();
        }
        //reset working set
        private void button3_Click(object sender, EventArgs e)
        {
            List<string> workingset = words;
            printoutwords();
        }

        private void Rightposition(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            if (textbox.Text.Length != 1)
            {
                return;
            }
            for (int i = 0; i < workingset.Count; i++)
            {
                if (workingset[i][Int32.Parse(textbox.AccessibleDescription)]+"" != textbox.Text || workingset[i].Contains(textbox.Text) == false)
                {
                    workingset.RemoveAt(i);
                }
            }
            printoutwords();
        }

        private void Wrongposition(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            if (textbox.Text.Length != 1)
            {
                return;
            }
            for (int i = 0; i < workingset.Count; i++)
            {
                if (workingset[i][Int32.Parse(textbox.AccessibleName)] + "" == textbox.Text || workingset[i].Contains(textbox.Text) == false)
                {
                    workingset.RemoveAt(i);
                }
            }
            printoutwords();
        }
    }
}
