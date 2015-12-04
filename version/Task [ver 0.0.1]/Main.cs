using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace practice0CSharp
{
    public partial class Main : Form, IMyInterface
    {
        CookieCollection cookie;
        private bool DirMode = false;
        private char cons = 'A';
        private int cnt = 0;
        private int cnt2 = 0;
        private int ArticleNum = 2441;
        public static string text;

        private string[] title = new string[80];
        private string[] body = new string[80];
        private string[][] fileTitle = new string[80][];
        private string[][] fileLink = new string[80][];

        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login log = new Login(this as IMyInterface);
            log.Show();
            
        }

        public void Logged_in(string data)
        {
            LogCheck.Text = data;
            LogCheck.ForeColor = Color.Blue;
            button1.Visible = false;

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "상수")
            {
                textBox1.Enabled = true;
                setConsAll();
                textBox1.Text = "";
            }
            if (comboBox1.Text == "변수" && textBox1.Text == "")
            {
                setConsAll();
                textBox1.Enabled = false;

            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "상수")
            {
                textBox2.Enabled = true;
                setConsAll();
                textBox2.Text = "";
            }
            if (comboBox2.Text == "변수" && textBox2.Text == "")
            {
                textBox2.Enabled = false;
                setConsAll();

            }
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == "상수")
            {
                textBox3.Enabled = true;
                setConsAll();
                textBox3.Text = "";
            }
            if (comboBox3.Text == "변수" && textBox3.Text == "")
            {
                textBox3.Enabled = false;
                setConsAll();

            }
        }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.Text == "상수")
            {
                textBox4.Enabled = true;
                setConsAll();
                textBox4.Text = "";
            }
            if (comboBox4.Text == "변수" && textBox4.Text == "")
            {
                textBox4.Enabled = false;
                setConsAll();

            }
        }
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.Text == "상수")
            {
                textBox5.Enabled = true;
                setConsAll();
                textBox5.Text = "";
            }
            if (comboBox5.Text == "변수" && textBox5.Text == "")
            {
                textBox5.Enabled = false;
                setConsAll();

            }
        }
        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox6.Text == "상수")
            {
                textBox6.Enabled = true;
                setConsAll();
                textBox6.Text = "";
            }
            if (comboBox6.Text == "변수" && textBox6.Text == "")
            {
                textBox6.Enabled = false;
                setConsAll();

            }
        }
        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox7.Text == "상수")
            {
                textBox7.Enabled = true;
                setConsAll();
                textBox7.Text = "";
            }
            if (comboBox7.Text == "변수" && textBox7.Text == "")
            {
                textBox7.Enabled = false;
                setConsAll();

            }
        }
        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox8.Text == "상수")
            {
                textBox8.Enabled = true;
                setConsAll();
                textBox8.Text = "";
            }
            if (comboBox8.Text == "변수" && textBox8.Text == "")
            {
                textBox8.Enabled = false;
                setConsAll();

            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            switch (cnt)
            {
                case 0:
                    comboBox2.Visible = true;
                    textBox2.Visible = true;
                    cnt++;
                    Sub1.Enabled = true;
                    break;
                case 1:
                    comboBox3.Visible = true;
                    textBox3.Visible = true;
                    cnt++;
                    break;
                case 2:
                    comboBox4.Visible = true;
                    textBox4.Visible = true;
                    cnt++;
                    break;
                case 3:
                    comboBox5.Visible = true;
                    textBox5.Visible = true;
                    cnt++;
                    break;
                case 4:
                    comboBox6.Visible = true;
                    textBox6.Visible = true;
                    cnt++;
                    break;
                case 5:
                    comboBox7.Visible = true;
                    textBox7.Visible = true;
                    cnt++;
                    break;
                case 6:
                    comboBox8.Visible = true;
                    textBox8.Visible = true;
                    Add1.Enabled = false;
                    cnt++;
                    break;
            }
        }

        private void SubButton_Click(object sender, EventArgs e)
        {
            switch (cnt)
            {
                case 1:
                    comboBox2.Visible = false;
                    textBox2.Visible = false;
                    Sub1.Enabled = false;
                    comboBox2.Text = null;
                    textBox2.Text = null;
                    textBox2.Enabled = false;
                    cnt--;
                    break;
                case 2:
                    comboBox3.Visible = false;
                    textBox3.Visible = false;
                    comboBox3.Text = null;
                    textBox3.Text = null;
                    textBox3.Enabled = false;
                    cnt--;
                    break;
                case 3:
                    comboBox4.Visible = false;
                    textBox4.Visible = false;
                    comboBox4.Text = null;
                    textBox4.Text = null;
                    textBox4.Enabled = false;
                    cnt--;
                    break;
                case 4:
                    comboBox5.Visible = false;
                    textBox5.Visible = false;
                    comboBox5.Text = null;
                    textBox5.Text = null;
                    textBox5.Enabled = false;
                    cnt--;
                    break;
                case 5:
                    comboBox6.Visible = false;
                    textBox6.Visible = false;
                    comboBox6.Text = null;
                    textBox6.Text = null;
                    textBox6.Enabled = false;
                    cnt--;
                    break;
                case 6:
                    comboBox7.Visible = false;
                    textBox7.Visible = false;
                    comboBox7.Text = null;
                    textBox7.Text = null;
                    textBox7.Enabled = false;
                    cnt--;
                    break;
                case 7:
                    comboBox8.Visible = false;
                    textBox8.Visible = false;
                    Add1.Enabled = true;
                    comboBox8.Text = null;
                    textBox8.Text = null;
                    textBox8.Enabled = false;
                    cnt--;
                    break;
            }
        }

        void setConsAll()
        {
            char c = 'A';
            if (comboBox1.Text == "변수")
            {
                textBox1.Text = "[" + c.ToString() + "]";
                c++;
            }
            if (comboBox2.Text == "변수")
            {
                textBox2.Text = "[" + c.ToString() + "]";
                c++;
            }
            if (comboBox3.Text == "변수")
            {
                textBox3.Text = "[" + c.ToString() + "]";
                c++;
            }
            if (comboBox4.Text == "변수")
            {
                textBox4.Text = "[" + c.ToString() + "]";
                c++;
            }
            if (comboBox5.Text == "변수")
            {
                textBox5.Text = "[" + c.ToString() + "]";
                c++;
            }
            if (comboBox6.Text == "변수")
            {
                textBox6.Text = "[" + c.ToString() + "]";
                c++;
            }
            if (comboBox7.Text == "변수")
            {
                textBox7.Text = "[" + c.ToString() + "]";
                c++;
            }
            if (comboBox8.Text == "변수")
            {
                textBox8.Text = "[" + c.ToString() + "]";
                c++;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (DirMode == false)
            {
                addValue(comboBox16);
                addValue(comboBox15);
                addValue(comboBox14);
                addValue(comboBox13);
                addValue(comboBox12);
                addValue(comboBox11);
                addValue(comboBox10);
                addValue(comboBox9);
                DirMode = true;
                groupBox3.Enabled = true;
                groupBox2.Enabled = false;
            }
            else
            {
                DirMode = false;
                groupBox2.Enabled = true;
                groupBox3.Enabled = false;
            }
        }
        void addValue(ComboBox box)
        {
            if (textBox1.Text != "")
                box.Items.Add(textBox1.Text);
            if (textBox2.Text != "")
                box.Items.Add(textBox2.Text);
            if (textBox3.Text != "")
                box.Items.Add(textBox3.Text);
            if (textBox4.Text != "")
                box.Items.Add(textBox4.Text);
            if (textBox5.Text != "")
                box.Items.Add(textBox5.Text);
            if (textBox6.Text != "")
                box.Items.Add(textBox6.Text);
            if (textBox7.Text != "")
                box.Items.Add(textBox7.Text);
            if (textBox8.Text != "")
                box.Items.Add(textBox8.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            switch (cnt2)
            {
                case 6:
                    comboBox9.Visible = true;
                    textBox9.Visible = true;
                    cnt2++;
                    Add2.Enabled = false;
                    break;
                case 5:
                    comboBox10.Visible = true;
                    textBox10.Visible = true;
                    cnt2++;
                    break;
                case 4:
                    comboBox11.Visible = true;
                    textBox11.Visible = true;
                    cnt2++;
                    break;
                case 3:
                    comboBox12.Visible = true;
                    textBox12.Visible = true;
                    cnt2++;
                    break;
                case 2:
                    comboBox13.Visible = true;
                    textBox13.Visible = true;
                    cnt2++;
                    break;
                case 1:
                    comboBox14.Visible = true;
                    textBox14.Visible = true;
                    cnt2++;
                    break;
                case 0:
                    comboBox15.Visible = true;
                    textBox15.Visible = true;
                    cnt2++;
                    Sub2.Enabled = true;
                    break;
            }
        }

        private void Sub2_Click(object sender, EventArgs e)
        {
            switch (cnt2)
            {
                case 1:
                    comboBox15.Visible = false;
                    textBox15.Visible = false;
                    Sub2.Enabled = false;
                    comboBox15.Text = null;
                    textBox15.Text = null;
                    textBox15.Enabled = false;
                    cnt2--;
                    break;
                case 2:
                    comboBox14.Visible = false;
                    textBox14.Visible = false;
                    comboBox14.Text = null;
                    textBox14.Text = null;
                    textBox14.Enabled = false;
                    cnt2--;
                    break;
                case 3:
                    comboBox13.Visible = false;
                    textBox13.Visible = false;
                    comboBox13.Text = null;
                    textBox13.Text = null;
                    textBox13.Enabled = false;
                    cnt2--;
                    break;
                case 4:
                    comboBox12.Visible = false;
                    textBox12.Visible = false;
                    comboBox12.Text = null;
                    textBox12.Text = null;
                    textBox12.Enabled = false;
                    cnt2--;
                    break;
                case 5:
                    comboBox11.Visible = false;
                    textBox11.Visible = false;
                    comboBox11.Text = null;
                    textBox11.Text = null;
                    textBox11.Enabled = false;
                    cnt2--;
                    break;
                case 6:
                    comboBox10.Visible = false;
                    textBox10.Visible = false;
                    comboBox10.Text = null;
                    textBox10.Text = null;
                    textBox10.Enabled = false;
                    cnt2--;
                    break;
                case 7:
                    comboBox9.Visible = false;
                    textBox9.Visible = false;
                    Add2.Enabled = true;
                    comboBox9.Text = null;
                    textBox9.Text = null;
                    textBox9.Enabled = false;
                    cnt2--;
                    break;
            }
        }

        private void comboBox16_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox16.Text == "Text")
                textBox16.Enabled = true;
            else
                textBox16.Enabled = false;
        }

        private void comboBox15_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox15.Text == "Text")
                textBox15.Enabled = true;
            else
                textBox15.Enabled = false;
        }

        private void comboBox14_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox14.Text == "Text")
                textBox14.Enabled = true;
            else
                textBox14.Enabled = false;
        }

        private void comboBox13_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox13.Text == "Text")
                textBox13.Enabled = true;
            else
                textBox13.Enabled = false;
        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox12.Text == "Text")
                textBox12.Enabled = true;
            else
                textBox12.Enabled = false;
        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox11.Text == "Text")
                textBox11.Enabled = true;
            else
                textBox11.Enabled = false;
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox10.Text == "Text")
                textBox10.Enabled = true;
            else
                textBox10.Enabled = false;
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox9.Text == "Text")
                textBox9.Enabled = true;
            else
                textBox9.Enabled = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            while (ArticleNum == 2441)
            {
                string responseFromServer="";
                HttpWebRequest Hwr2 = (HttpWebRequest)WebRequest.Create("http://cafe.naver.com/ArticleRead.nhn?clubid=27874272&articleid=" + ArticleNum);
                Hwr2.Method = "GET";

                //string POSTFormatString2 = "club=27874272&articleid=2441";
                Hwr2.CookieContainer = new CookieContainer();
                Hwr2.CookieContainer.Add(cookie);

                HttpWebResponse response = (HttpWebResponse)Hwr2.GetResponse();
                
                Stream dataStream = response.GetResponseStream();
                //StreamReader reader = new StreamReader(dataStream);
                StreamReader reader = new StreamReader(dataStream, Encoding.Default);

                responseFromServer = reader.ReadToEnd();

                Htmlsrc htm = new Htmlsrc("Data : " + responseFromServer);
                htm.Show();
                ArticleNum++;
            }
        }
        private void parser(string src)
        {
            string title;
            string body;
            string Ftitle;
            string Flink;
        }
        public void getCookie(CookieCollection cookie)
        {
            this.cookie = cookie;
        }
    }
}
