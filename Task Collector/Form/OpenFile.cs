using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace practice0CSharp
{
    public partial class OpenFile : Form, IMyInterface
    {
        public OpenFile()
        {
            InitializeComponent();
        }
        private IMyInterface frm = null;

        public OpenFile(IMyInterface frm)
        {
            InitializeComponent();
            this.frm = frm;
        }
        public void addComponent(string str)
        {
            comboBox1.Items.Add(str);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == null)
                MessageBox.Show("선택해주세요");
            else
            {
                frm.getSelectedFile(comboBox1.Text);
                this.Close();
            }
        }
        public void Logged_in(string str)
        {

        }
        public void getSelectedFile(string str) {

        }
        public void getCookie(System.Net.CookieCollection cookie){

        }
        
    }
}
