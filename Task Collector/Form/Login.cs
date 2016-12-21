using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
// User Defined.
using System.Net;

namespace practice0CSharp
{
    public interface IMyInterface
    {
        void Logged_in(string Data);
        void getCookie(CookieCollection cookie);
        void getSelectedFile(string str);
    }
    public partial class Login : Form
    {
       // public delegate void FormSendDataHandler();
       // public event FormSendDataHandler FormSendEvent;

        private IMyInterface frm = null;
        string text;

        public Login(IMyInterface frm)
        {
            InitializeComponent();
            this.frm = frm;
        }
        public Login(string str)
        {
            this.text = str;
            InitializeComponent();
            
        }
        // http://javascriptdotnet.codeplex.com/
        
        private void button1_Click(object sender, EventArgs e)
        {
            NaverLogin NL = new NaverLogin(frm);
            if (NL.Login(textBox1.Text, textBox2.Text))
            {
                frm.Logged_in("Logged in");
                MessageBox.Show("Logged In!\n");
                this.Close();
            }
            else
            {
                MessageBox.Show("FAILED!");
            }
        }
    }
}
