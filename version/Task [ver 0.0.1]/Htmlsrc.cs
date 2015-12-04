using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace practice0CSharp
{
    public partial class Htmlsrc : Form
    {
        string text;
        public Htmlsrc()
        {
            InitializeComponent();
            textBox1.ScrollBars = ScrollBars.Vertical;
        }
        public Htmlsrc(string text)
        {
            InitializeComponent();
            textBox1.ScrollBars = ScrollBars.Vertical;
            this.text = text;
        }
        private void Htmlsrc_Load(object sender, EventArgs e)
        {
            CookieContainer cookies = new CookieContainer();
            textBox1.Text = text;
        }
    }
}
