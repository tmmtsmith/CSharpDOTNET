using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string SqlSafe(string x)
        {
            x = x.Replace("DROP", "Hacker Alert");
            x = x.Replace("DELETE", "Hacker Alert");
            x = x.Replace("'", "");
            return x;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string box = Convert.ToString(txt1.Text);
            box = SqlSafe(box);
            lbl1.Text = box;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
