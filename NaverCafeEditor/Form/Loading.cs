using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NaverCafeEditor
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
        }


        private void Loading_Load(object sender, EventArgs e)
        {
            this.BringToFront();
            timer1_Tick(sender, e);
            timer1.Interval = 1000;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (label1.Text == "Searching....")
                label1.Text = "Searching";
            label1.Text += ".";
        }
        public void loadingpp(int num)
        {
            label2.Text = num + " files found";

        }
    }
}
