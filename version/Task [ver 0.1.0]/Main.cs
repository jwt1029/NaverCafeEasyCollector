using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Mlib;
using System.Collections;
namespace practice0CSharp
{
    public partial class Main : Form, IMyInterface, SettingInterface
    {
        CookieCollection cookie = null;                     //Cookie Data
        private bool DirMode = false;                       //Directory Mode
        private char cons = 'A';                            //Const Character
        private int cnt = 0;                                //Plus/Minus Button 1
        private int cnt2 = 0;                               //Plus/Minus Button 2
        private int ArticleNum = 2440;                      //Article Number
        private int foundcnt = 0;                           //Article Founded Count
        private int[] fTcnt = new int[80];                  //File Title Count
        private int[] fLcnt = new int[80];                  //File Link Count
        private string[] title = new string[80];            //Article Title Text
        private string[][] body = new string[80][];         //Article Body Text
        private string[][] fileTitle = new string[80][];    //File Title Text
        private string[][] fileLink = new string[80][];     //File Title Text
        private string[][] date = new string[80][];         //Article Upload Date
        private int cafeNum;                                //Cafe Club Number
        private bool overTime = false;                      //Article Time Check
        private string cafeMainsrc = "";                    //Cafe Main Source
        private string dirstr = "";                         //Directory String
        private string browseDir = "";                      //BrowerDialog Directory
        private string[] namingArr = new string[10];        //Naming Rule Arrary
        private string namingRegular = "";                  //Naming to Regular
        private int namecnt = 0;                            //Naming Split Count
        private int filecnt = 0;                            //File Data Count
        private string[] fileName = new string[10];         //Saved File Names
        private string selectedFile = "";                   //Selcted File from SaveFile Form
        private int[] ArticleList = new int[80];            //Article Number List
        private string commentpath = null;                  //Comment Open Initalize Path
        private string textviewerpath = null;               //TextViewer Initalize Path

        public Main()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }
        /* Open Login Form*/

        OpenFile opfile;

        /* Login */
        private void button1_Click(object sender, EventArgs e)
        {
            Login log = new Login(this as IMyInterface);
            log.Show();

        }

        /* get Login Data */
        public void Logged_in(string data)
        {
            //Get Login Check From NaverLogin.cs
            LogCheck.Text = data;
            LogCheck.ForeColor = Color.Blue;
            button1.Visible = false;

        }

        /* Main Load (DateTime Max setting) */
        private void Main_Load(object sender, EventArgs e)
        {
            //readTemplate();
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.Value = DateTime.Today;
            dateTimePicker1.MaxDate = DateTime.Today;
            dateTimePicker2.MaxDate = DateTime.Today;
            TimeH1.Text = "00";
            TimeM1.Text = "00";
            TimeH2.Text = "23";
            TimeM2.Text = "59";
            opfile = new OpenFile(this as IMyInterface);
            fileInit();
            filepathInit();
        }

        /* set DateTime2's Min with DateTime1 Value */
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.MinDate = dateTimePicker1.Value;
        }

        /* Const / Variable Setting */
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "상수")
            {
                textBox1.Enabled = true;
                setConsAll();
                textBox1.Text = "";
            }
            if (comboBox1.Text == "변수")
            {
                setConsAll();
                textBox1.Enabled = false;
            }
            if (comboBox1.Text == "학번")
            {
                textBox1.Enabled = false;
                textBox1.Text = "[학번]";
                setConsAll();
            }
            setNaming();
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "상수")
            {
                textBox2.Enabled = true;
                setConsAll();
                textBox2.Text = "";
            }
            if (comboBox2.Text == "변수" )
            {
                textBox2.Enabled = false;
                setConsAll();
            }
            if (comboBox2.Text == "학번")
            {
                textBox2.Enabled = false;
                textBox2.Text = "[학번]";
                setConsAll();
            }
            setNaming();
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == "상수")
            {
                textBox3.Enabled = true;
                setConsAll();
                textBox3.Text = "";
            }
            if (comboBox3.Text == "변수" )
            {
                textBox3.Enabled = false;
                setConsAll();
            }
            if (comboBox3.Text == "학번")
            {
                textBox3.Enabled = false;
                textBox3.Text = "[학번]";
                setConsAll();
            }
            setNaming();
        }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.Text == "상수")
            {
                textBox4.Enabled = true;
                setConsAll();
                textBox4.Text = "";
            }
            if (comboBox4.Text == "변수")
            {
                textBox4.Enabled = false;
                setConsAll();
            }
            if (comboBox4.Text == "학번")
            {
                textBox4.Enabled = false;
                textBox4.Text = "[학번]";
                setConsAll();
            }
            setNaming();
        }
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.Text == "상수")
            {
                textBox5.Enabled = true;
                setConsAll();
                textBox5.Text = "";
            }
            if (comboBox5.Text == "변수")
            {
                textBox5.Enabled = false;
                setConsAll();
            }
            if (comboBox5.Text == "학번")
            {
                textBox5.Enabled = false;
                textBox5.Text = "[학번]";
                setConsAll();
            }
            setNaming();
        }
        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox6.Text == "상수")
            {
                textBox6.Enabled = true;
                setConsAll();
                textBox6.Text = "";
            }
            if (comboBox6.Text == "변수")
            {
                textBox6.Enabled = false;
                setConsAll();
            }
            if (comboBox6.Text == "학번")
            {
                textBox6.Enabled = false;
                textBox6.Text = "[학번]";
                setConsAll();
            }
            setNaming();
        }
        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox7.Text == "상수")
            {
                textBox7.Enabled = true;
                setConsAll();
                textBox7.Text = "";
            }
            if (comboBox7.Text == "변수")
            {
                textBox7.Enabled = false;
                setConsAll();
            }
            if (comboBox7.Text == "학번")
            {
                textBox7.Enabled = false;
                textBox7.Text = "[학번]";
                setConsAll();
            }
            setNaming();
        }
        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox8.Text == "상수")
            {
                textBox8.Enabled = true;
                setConsAll();
                textBox8.Text = "";
            }
            if (comboBox8.Text == "변수")
            {
                textBox8.Enabled = false;
                setConsAll();
            }
            if (comboBox8.Text == "학번")
            {
                textBox8.Enabled = false;
                textBox8.Text = "[학번]";
                setConsAll();
            }
            setNaming();
        }

        /* Const / Variable Plus */
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
            setNaming();
        }

        /* Const / Variable Minus */
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
            setNaming();
        }

        /* Set Const all with Alpabet Order */
        private void setConsAll()
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
            this.cons = c;
        }

        /* Dir Mode On/Off */
        private void button4_Click(object sender, EventArgs e)
        {
            setNaming();
            if (DirMode == false)
            {
                comboBox16.Items.Clear();
                comboBox15.Items.Clear();
                comboBox14.Items.Clear();
                comboBox13.Items.Clear();
                comboBox12.Items.Clear();
                comboBox11.Items.Clear();
                comboBox10.Items.Clear();
                comboBox9.Items.Clear();
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

        /* Add Values to Dir ComboBox*/
        private void addValue(ComboBox box)
        {
            box.Items.Add("Text");
            if (textBox1.Text != "" && comboBox1.Text != "변수" && comboBox1.Text != "학번")
                box.Items.Add(textBox1.Text);
            if (textBox2.Text != "" && comboBox2.Text != "변수" && comboBox2.Text != "학번")
                box.Items.Add(textBox2.Text);
            if (textBox3.Text != "" && comboBox3.Text != "변수" && comboBox3.Text != "학번")
                box.Items.Add(textBox3.Text);
            if (textBox4.Text != "" && comboBox4.Text != "변수" && comboBox4.Text != "학번")
                box.Items.Add(textBox4.Text);
            if (textBox5.Text != "" && comboBox5.Text != "변수" && comboBox5.Text != "학번")
                box.Items.Add(textBox5.Text);
            if (textBox6.Text != "" && comboBox6.Text != "변수" && comboBox6.Text != "학번")
                box.Items.Add(textBox6.Text);
            if (textBox7.Text != "" && comboBox7.Text != "변수" && comboBox7.Text != "학번")
                box.Items.Add(textBox7.Text);
            if (textBox8.Text != "" && comboBox8.Text != "변수" && comboBox8.Text != "학번")
                box.Items.Add(textBox8.Text);

            char c = 'A';
            while (cons > c)
            {
                box.Items.Add("[" + c.ToString() + "]");
                c++;
            }
            box.Items.Add("[학년]");
            box.Items.Add("[반]");
            box.Items.Add("[번호]");
        }

        /* Dir Plus */
        private void button3_Click(object sender, EventArgs e)
        {
            switch (cnt2)
            {
                case 6:
                    Divide7.Visible = true;
                    comboBox9.Visible = true;
                    textBox9.Visible = true;
                    cnt2++;
                    Add2.Enabled = false;
                    break;
                case 5:
                    Divide6.Visible = true;
                    comboBox10.Visible = true;
                    textBox10.Visible = true;
                    cnt2++;
                    break;
                case 4:
                    Divide5.Visible = true;
                    comboBox11.Visible = true;
                    textBox11.Visible = true;
                    cnt2++;
                    break;
                case 3:
                    Divide4.Visible = true;
                    comboBox12.Visible = true;
                    textBox12.Visible = true;
                    cnt2++;
                    break;
                case 2:
                    Divide3.Visible = true;
                    comboBox13.Visible = true;
                    textBox13.Visible = true;
                    cnt2++;
                    break;
                case 1:
                    Divide2.Visible = true;
                    comboBox14.Visible = true;
                    textBox14.Visible = true;
                    cnt2++;
                    break;
                case 0:
                    Divide1.Visible = true;
                    comboBox15.Visible = true;
                    textBox15.Visible = true;
                    cnt2++;
                    Sub2.Enabled = true;
                    break;
            }
        }

        /* Dir Minus */
        private void Sub2_Click(object sender, EventArgs e)
        {
            switch (cnt2)
            {
                case 1:
                    Divide1.Visible = false;
                    Divide1.Text = "";
                    comboBox15.Visible = false;
                    textBox15.Visible = false;
                    Sub2.Enabled = false;
                    comboBox15.Text = null;
                    textBox15.Text = null;
                    textBox15.Enabled = false;
                    cnt2--;
                    break;
                case 2:
                    Divide2.Visible = false;
                    Divide2.Text = "";
                    comboBox14.Visible = false;
                    textBox14.Visible = false;
                    comboBox14.Text = null;
                    textBox14.Text = null;
                    textBox14.Enabled = false;
                    cnt2--;
                    break;
                case 3:
                    Divide3.Visible = false;
                    Divide3.Text = "";
                    comboBox13.Visible = false;
                    textBox13.Visible = false;
                    comboBox13.Text = null;
                    textBox13.Text = null;
                    textBox13.Enabled = false;
                    cnt2--;
                    break;
                case 4:
                    Divide4.Visible = false;
                    Divide4.Text = "";
                    comboBox12.Visible = false;
                    textBox12.Visible = false;
                    comboBox12.Text = null;
                    textBox12.Text = null;
                    textBox12.Enabled = false;
                    cnt2--;
                    break;
                case 5:
                    Divide5.Visible = false;
                    Divide5.Text = "";
                    comboBox11.Visible = false;
                    textBox11.Visible = false;
                    comboBox11.Text = null;
                    textBox11.Text = null;
                    textBox11.Enabled = false;
                    cnt2--;
                    break;
                case 6:
                    Divide6.Visible = false;
                    Divide6.Text = "";
                    comboBox10.Visible = false;
                    textBox10.Visible = false;
                    comboBox10.Text = null;
                    textBox10.Text = null;
                    textBox10.Enabled = false;
                    cnt2--;
                    break;
                case 7:
                    Divide7.Visible = false;
                    Divide7.Text = "";
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

        /* Read Dir*/
        private void button6_Click(object sender, EventArgs e)
        {
            readDir();
        }

        /* Set Naming */
        private void button5_Click(object sender, EventArgs e)
        {
            setNaming();
        }

        /* Dir Setting */
        private void comboBox16_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox16.Text == "Text")
            {
                textBox16.Enabled = true;
                textBox16.Text = "";
            }
            else
            {
                textBox16.Text = comboBox16.Text;
                textBox16.Enabled = false;
            }
            readDir();
        }
        private void comboBox15_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox15.Text == "Text")
            {
                textBox15.Enabled = true;
                textBox15.Text = "";
            }
            else
            {
                textBox15.Text = comboBox15.Text;
                textBox15.Enabled = false;
            }
            readDir();
        }
        private void comboBox14_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox14.Text == "Text")
            {
                textBox14.Enabled = true;
                textBox14.Text = "";
            }
            else
            {
                textBox14.Text = comboBox14.Text;
                textBox14.Enabled = false;
            }
            readDir();
        }
        private void comboBox13_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox13.Text == "Text")
            {
                textBox13.Enabled = true;
                textBox13.Text = "";
            }
            else
            {
                textBox13.Text = comboBox13.Text;
                textBox13.Enabled = false;
            }
            readDir();
        }
        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox12.Text == "Text")
            {
                textBox12.Enabled = true;
                textBox12.Text = "";
            }
            else
            {
                textBox12.Text = comboBox12.Text;
                textBox12.Enabled = false;
            }
            readDir();
        }
        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox11.Text == "Text")
            {
                textBox11.Enabled = true;
                textBox11.Text = "";
            }
            else
            {
                textBox11.Text = comboBox11.Text;
                textBox11.Enabled = false;
            }
            readDir();
        }
        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox10.Text == "Text")
            {
                textBox10.Enabled = true;
                textBox10.Text = "";
            }
            else
            {
                textBox10.Text = comboBox10.Text;
                textBox10.Enabled = false;
            }
            readDir();
        }
        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox9.Text == "Text")
            {
                textBox9.Enabled = true;
                textBox9.Text = "";
            }
            else
            {
                textBox9.Text = comboBox9.Text;
                textBox9.Enabled = false;
            }
            readDir();
        }

        /* Target Select */
        private void comboBox17_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox17.Text == "(직접 입력)")
                TargetText.Enabled = true;
            else
            {
                TargetText.Enabled = false;
                if (comboBox17.Text == "세상을 깨워라 (DSM)")
                    TargetText.Text = "http://cafe.naver.com/onlyonedsm";
            }
        }

        Loading lod = new Loading();
        
        /* Search Button Clicked */
        private void button2_Click_1(object sender, EventArgs e)
        {
            //button2.Enabled = false;      ->       Set After Develop
            switch (MessageBox.Show("현재 Naming 템플릿을 저장하시겠습니까?", "Save?", MessageBoxButtons.YesNo))
            {
                case System.Windows.Forms.DialogResult.Yes:
                    SaveFile save = new SaveFile(namecnt, namingArr, fileName);
                    save.Show();
                    break;
                case System.Windows.Forms.DialogResult.No:
                    break;

            }

            Thread thread1 = new Thread(new ThreadStart(ThreadGOGO));

            //Logged in check
            if (cookie == null)
            {
                MessageBox.Show("로그인 후 실행 해주세요");
                return;
            }

            //Naming Rule Null Check
            if (isNamingNull())
            {
                MessageBox.Show("Naming Rule에 빈칸이 있습니다!");
                return;
            }

            //Get Cafe Number
            if (getCafeNumber() == false)
                return;
            ArticleNum = getlastArticleNum();

            isCafeMember(cafeMainsrc);
            if (CafeMemberValue.Text == "false")
            {
                MessageBox.Show("카페 멤버가 아닙니다!!");
                return;
            }

            //Initalize Array 
            for (int i = 0; i < fileTitle.Length; i++)
            {
                fileTitle[i] = new string[80];
                fileLink[i] = new string[80];
                date[i] = new string[4];
            }
            getRegularNaming();
            lod.Show();
            thread1.Start();  //ThreadGOGO메소드를 새로운 쓰레드가 실행합니다
        }
        public void ThreadGOGO()
        {
            string Data = "";
            //Read Articles
            while (true)
            {
                string responseFromServer = "";
                HttpWebRequest Hwr2 = (HttpWebRequest)WebRequest.Create("http://cafe.naver.com/ArticleRead.nhn?clubid=" + cafeNum + "&articleid=" + ArticleNum);
                Hwr2.Method = "GET";

                Hwr2.CookieContainer = new CookieContainer();
                Hwr2.CookieContainer.Add(cookie);

                HttpWebResponse response = (HttpWebResponse)Hwr2.GetResponse();

                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream, Encoding.Default);

                responseFromServer = reader.ReadToEnd();


                //Check Null Article
                if (isArticleNull(responseFromServer))
                {
                    ArticleNum--;
                    continue;
                }

                //Parse
                if (parser(responseFromServer))
                    lod.loadingpp(foundcnt);
                if (overTime == true)
                    break;

                ArticleNum--;
            }
            //Get Data + Show Data
            searchResult.Text += foundcnt;
            for (int i = 0; i < foundcnt; i++)
            {
                Data += "<" + date[i][0] + "/" + date[i][1] + "/" + date[i][2] + ">" + Environment.NewLine;
                Data += "[Title]" + Environment.NewLine + title[i] + Environment.NewLine;
                Data += Environment.NewLine + "[Body]" + Environment.NewLine;
                for (int j = 0; j < body[i].Length; j++)
                    Data += body[i][j] + Environment.NewLine;
                Data += Environment.NewLine + "[FileTitle]" + Environment.NewLine;
                for (int j = 0; j < fTcnt[i]; j++)
                {
                    Data += Environment.NewLine + (j + 1) + "번째 파일 명 : " + fileTitle[i][j] + Environment.NewLine;
                    Data += Environment.NewLine + (j + 1) + "번째 파일 주소 : " + fileLink[i][j] + Environment.NewLine;
                }
                Data += Environment.NewLine + "=============================================================================================" + Environment.NewLine + Environment.NewLine;
            }
            lod.Close();
            Application.Run(new Htmlsrc(Data));
            //            Htmlsrc htm = new Htmlsrc(Data);
            //            htm.Show();
        }
        /* Parse Html */
        private bool parser(string src)
        {
            /*Data Parsing*/
            string Date = src;
            string[] member = new string[4];
            Date = Date.Substring(Date.IndexOf("<td class=\"m-tcol-c date\">") + "<td class=\"m-tcol-c date\">".Length);
            Date = substr(Date, 0, Date.IndexOf("</td>"));
            member[0] = Date.Substring(0, 4);
            member[1] = Date.Substring(5, 2);
            member[2] = Date.Substring(8, 2);
            if (!isDateInPeriod(member))
            {
                return false;
            }
            /*Title Parsing*/
            string title = src.Substring(src.IndexOf("<span class=\"b m-tcol-c\">"));
            title = substr(title, title.IndexOf(">") + 1, title.IndexOf("</span>"));
            title = title.Trim();

            if (checkNaming(title))
            {
                date[foundcnt] = member;
                /*Body Parsing*/
                string body = src.Substring(src.IndexOf("<div class=\"tbody m-tcol-c\" id=\"tbody\">") + "<div class=\"tbody m-tcol-c\" id=\"tbody\">".Length);

                while (body.IndexOf("<div>") != -1)
                {
                    if (body.IndexOf("<div>") > body.IndexOf("</div>"))
                        break;
                    var regex = new Regex(Regex.Escape("<div>"));
                    body = regex.Replace(body, "", 1);
                    regex = new Regex(Regex.Escape("</div>"));
                    body = regex.Replace(body, "", 1);
                }
                body = substr(body, 0, body.IndexOf("</div>"));
                body = body.Trim();
                body = tagChange(body);
                body = removeHtmlTag(body);

                string[] bodyarr = body.Split(new string[] { "[::NEWLINE::]" }, StringSplitOptions.None);

                /*File Title Parsing*/
                string Ftitle = src;
                while (Ftitle.IndexOf("<span class=\"file_name\">") != -1)
                {
                    Ftitle = Ftitle.Substring(Ftitle.IndexOf("<span class=\"file_name\">") + "<span class=\"file_name\">".Length);
                    string subFtitle = substr(Ftitle, 0, Ftitle.IndexOf("</span>"));
                    fileTitle[foundcnt][fTcnt[foundcnt]] = subFtitle;
                    fTcnt[foundcnt]++;
                }

                /*File Link Parsing*/
                string Flink = src;
                while (Flink.IndexOf("<div id=\"attahc\" class=\"download_opt\">") != -1)
                {
                    Flink = Flink.Substring(Flink.IndexOf("<div id=\"attahc\" class=\"download_opt\">") + "<div id=\"attahc\" class=\"download_opt\">".Length);
                    Flink = Flink.Substring(Flink.IndexOf("<a href=") + "<a href=".Length + 1);
                    string subFlink = substr(Flink, 0, Flink.IndexOf("\">내PC 저장"));
                    fileLink[foundcnt][fLcnt[foundcnt]] = subFlink;
                    fLcnt[foundcnt]++;
                }
                this.title[foundcnt] = title;
                this.body[foundcnt] = bodyarr;
                this.ArticleList[foundcnt] = ArticleNum;
                foundcnt++;
                return true;
            }
            return false;
        }

        /* Get Cookie From NaverLogin -> Login -> this */
        public void getCookie(CookieCollection cookie)
        {
            this.cookie = cookie;
        }

        /* SubString st -> ed */
        private string substr(string str, int st, int ed)
        {
            return str.Substring(st, ed - st);
        }

        /* Change Html tag */
        private string tagChange(string str)
        {
            str = str.Replace("<br />", "[::NEWLINE::][::NEWLINE::]");
            str = str.Replace("</p>", "[::NEWLINE::]");
            str = str.Replace("&nbsp;", " ");
            return str;
        }

        /* Remove Html Tag */
        private string removeHtmlTag(string str)
        {
            // 정규표현을 이용한 HTML태그 삭제
            return Regex.Replace(str, @"[<][a-z|A-Z|/](.|\n)*?[>]", "");
        }

        /* Log to cafe & Get cafe number */
        private bool getCafeNumber()
        {
            string responseFromServer = "";
            if (TargetText.Text == "")
            {
                this.cafeNum = -1;
                MessageBox.Show("카페 주소를 입력해 주세요");
                return false;
            }
            HttpWebRequest Hwr2 = (HttpWebRequest)WebRequest.Create(TargetText.Text);
            Hwr2.Method = "GET";

            Hwr2.CookieContainer = new CookieContainer();
            Hwr2.CookieContainer.Add(cookie);

            HttpWebResponse response = (HttpWebResponse)Hwr2.GetResponse();

            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream, Encoding.Default);

            cafeMainsrc = reader.ReadToEnd();
            responseFromServer = cafeMainsrc;

            int cafeNum = 0;
            if (responseFromServer.IndexOf("var g_sClubId = ") != -1)
            {
                responseFromServer = responseFromServer.Substring(responseFromServer.IndexOf("var g_sClubId = ") + "var g_sClubId = ".Length);
                responseFromServer = substr(responseFromServer, 1, responseFromServer.IndexOf(";") - 1);
                cafeNum = int.Parse(responseFromServer);
                this.cafeNum = cafeNum;
                CafeNumberValue.Text = cafeNum.ToString();
            }
            if (cafeNum == 0)
            {
                MessageBox.Show("카페를 찾을 수 없습니다!");
                return false;
            }
            else
            {
                CafeNumberValue.ForeColor = Color.Blue;
                return true;
            }
        }

        /* Check Article Delete or non exist */
        private bool isArticleNull(string str)
        {
            if (str.IndexOf("삭제되었거나 없는 게시물입니다") != -1)
                return true;
            return false;
        }

        /* Check Cafe Member */
        private bool isCafeMember(string str)
        {
            if (str.IndexOf("카페 가입하기") != -1)
            {
                CafeMemberValue.Text = "false";
                return false;
            }
            CafeMemberValue.Text = "true";
            CafeMemberValue.ForeColor = Color.Blue;
            return true;
        }

        /* Divide Button Clicked */
        private void Divide1_Click(object sender, EventArgs e)
        {
            if (Divide1.Text == "")
                Divide1.Text = "\\";
            else
                Divide1.Text = "";
            readDir();
        }
        private void Divide2_Click(object sender, EventArgs e)
        {
            if (Divide2.Text == "")
                Divide2.Text = "\\";
            else
                Divide2.Text = "";
            readDir();
        }
        private void Divide3_Click(object sender, EventArgs e)
        {
            if (Divide3.Text == "")
                Divide3.Text = "\\";
            else
                Divide3.Text = "";
            readDir();
        }
        private void Divide4_Click(object sender, EventArgs e)
        {
            if (Divide4.Text == "")
                Divide4.Text = "\\";
            else
                Divide4.Text = "";
            readDir();
        }
        private void Divide5_Click(object sender, EventArgs e)
        {
            if (Divide5.Text == "")
                Divide5.Text = "\\";
            else
                Divide5.Text = "";
            readDir();
        }
        private void Divide7_Click(object sender, EventArgs e)
        {
            if (Divide7.Text == "")
                Divide7.Text = "\\";
            else
                Divide7.Text = "";
            readDir();
        }
        private void Divide6_Click(object sender, EventArgs e)
        {
            if (Divide6.Text == "")
                Divide6.Text = "\\";
            else
                Divide6.Text = "";
            readDir();
        }

        /* Check Naming Rule has Null */
        private bool isNamingNull()
        {
            int run = 0;

            if (comboBox1.Text == "")
                return true;
            if (run == cnt)
                return false;
            run++;

            if (comboBox2.Text == "")
                return true;
            if (run == cnt)
                return false;
            run++;

            if (comboBox3.Text == "")
                return true;
            if (run == cnt)
                return false;
            run++;

            if (comboBox4.Text == "")
                return true;
            if (run == cnt)
                return false;
            run++;

            if (comboBox5.Text == "")
                return true;
            if (run == cnt)
                return false;
            run++;

            if (comboBox6.Text == "")
                return true;
            if (run == cnt)
                return false;
            run++;

            if (comboBox7.Text == "")
                return true;
            if (run == cnt)
                return false;
            run++;

            if (comboBox8.Text == "")
                return true;
            if (run == cnt)
                return false;

            return false;
        }

        /* Check Date in Period*/
        private bool isDateInPeriod(string[] dd)
        {
            string day = "0";
            if (dateTimePicker1.Value.Day.ToString().Length == 1)
                day += dateTimePicker1.Value.Day.ToString();
            else
                day = dateTimePicker1.Value.Day.ToString();
            if (!(int.Parse(dd[0] + dd[1] + dd[2]) >= int.Parse(dateTimePicker1.Value.Year.ToString() + dateTimePicker1.Value.Month.ToString() + day)))
            {
                overTime = true;
                return false;
            }
            else
            {
                day = "0";
                if (dateTimePicker2.Value.Day.ToString().Length == 1)
                    day += dateTimePicker2.Value.Day.ToString();
                else
                    day = dateTimePicker2.Value.Day.ToString();
                if ((int.Parse(dd[0] + dd[1] + dd[2]) <= int.Parse(dateTimePicker2.Value.Year.ToString() + dateTimePicker2.Value.Month.ToString() + day)))
                    return true;
            }
            return false;
        }

        /* Check Last Article */
        private int getlastArticleNum()
        {
            string responseFromServer = "";
            HttpWebRequest Hwr2 = (HttpWebRequest)WebRequest.Create("http://cafe.naver.com/ArticleList.nhn?search.clubid=" + cafeNum);
            Hwr2.Method = "GET";

            Hwr2.CookieContainer = new CookieContainer();
            Hwr2.CookieContainer.Add(cookie);

            HttpWebResponse response = (HttpWebResponse)Hwr2.GetResponse();

            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream, Encoding.Default);

            responseFromServer = reader.ReadToEnd();

            responseFromServer = responseFromServer.Substring(responseFromServer.IndexOf("<span class=\"aaa\">") + "<span class=\"aaa\">".Length);
            responseFromServer = responseFromServer.Substring(responseFromServer.IndexOf("articleid=") + "articleid=".Length);
            responseFromServer = substr(responseFromServer, 0, responseFromServer.IndexOf("&"));

            return int.Parse(responseFromServer);
        }

        /* Read Set Directory */
        private void readDir()
        {
            string dirstr = "";
            if (textBox16.Text != "")
                dirstr += textBox16.Text;
            if (Divide1.Text == "\\")
                dirstr += "\\";

            if (textBox15.Text != "")
                dirstr += textBox15.Text;
            if (Divide2.Text == "\\")
                dirstr += "\\";

            if (textBox14.Text != "")
                dirstr += textBox14.Text;
            if (Divide3.Text == "\\")
                dirstr += "\\";

            if (textBox13.Text != "")
                dirstr += textBox13.Text;
            if (Divide4.Text == "\\")
                dirstr += "\\";

            if (textBox12.Text != "")
                dirstr += textBox12.Text;
            if (Divide5.Text == "\\")
                dirstr += "\\";

            if (textBox11.Text != "")
                dirstr += textBox11.Text;
            if (Divide6.Text == "\\")
                dirstr += "\\";

            if (textBox10.Text != "")
                dirstr += textBox10.Text;
            if (Divide7.Text == "\\")
                dirstr += "\\";

            if (textBox9.Text != "")
                dirstr += textBox9.Text;
            dirstr += "\\";
            dirstr = dirstr.Replace("\\\\", "\\");
            if (DirResult.Text != "파일 위치를 지정해주세요 (찾아보기)")
                DirResult.Text = browseDir + dirstr;
            this.dirstr = dirstr;
        }

        /* Search Directory Button */
        private void searchDir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                browseDir = folderBrowserDialog1.SelectedPath + "\\";
                DirResult.Text = (browseDir + dirstr).Replace("\\\\", "\\");
            }
        }

        /* Set Naming Rule */
        private void setNaming()
        {
            int namecnt = 0;
            if (textBox1.Text != "")
            {
                namingArr[namecnt] = textBox1.Text;
                namecnt++;
            }
            if (textBox2.Text != "")
            {
                namingArr[namecnt] = textBox2.Text;
                namecnt++;
            }
            if (textBox3.Text != "")
            {
                namingArr[namecnt] = textBox3.Text;
                namecnt++;
            }
            if (textBox4.Text != "")
            {
                namingArr[namecnt] = textBox4.Text;
                namecnt++;
            }
            if (textBox5.Text != "")
            {
                namingArr[namecnt] = textBox5.Text;
                namecnt++;
            }
            if (textBox6.Text != "")
            {
                namingArr[namecnt] = textBox6.Text;
                namecnt++;
            }
            if (textBox7.Text != "")
            {
                namingArr[namecnt] = textBox7.Text;
                namecnt++;
            }
            if (textBox8.Text != "")
            {
                namingArr[namecnt] = textBox8.Text;
                namecnt++;
            }
            NamingEx.Text = "Naming : ";
            for (int i = 0; i < namecnt; i++)
            {
                if (i == 0)
                    NamingEx.Text += namingArr[i];
                else
                    NamingEx.Text += " + " + namingArr[i];
            }
            this.namecnt = namecnt;
        }

        /* Make Regular Naming */
        private void getRegularNaming()
        {
            for (int i = 0; i < namecnt; i++)
            {
                if (Regex.IsMatch(namingArr[i], "[[][A-Z][]]"))
                    namingRegular += "(.|\n)*";
                else if(namingArr[i] == "[학번]") {
                    namingRegular += "\\d{5}";
                }
                else
                    namingRegular += namingArr[i];
            }
        }

        /* Check Title with Regular Naming*/
        private bool checkNaming(string title)
        {
            if (spaceIgnore.Checked)
                title = title.Replace(" ", "");
            if (Regex.IsMatch(title, namingRegular))
                return true;
            else
                return false;
        }

        /* Read Template form Saved Text */
        private void readTemplate()
        {
            DirectoryInfo Dir = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TaskCollector");
            if (!Dir.Exists)
            {
                MessageBox.Show("저장된 파일이 없습니다!");
                return;
            }
            FileInfo f = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TaskCollector\\" + selectedFile + ".txt");
            if(!f.Exists)
            {
                MessageBox.Show("저장된 파일이 없습니다!");
                return;
            }
            MFile m = new MFile(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TaskCollector\\" + selectedFile + ".txt", FileMode.Open, FileAccess.Read);
            int cnt = int.Parse(m.ReadLine());
            string str = "";
            for (int i = 1; i <= cnt; i++)
            {
                str = m.ReadLine();
                switch (i)
                {
                    case 1:
                        if (isStringVariable(str))
                            comboBox1.Text = "변수";
                        else
                            comboBox1.Text = "상수";
                        textBox1.Text = str;
                        break;
                    case 2:
                        if (isStringVariable(str))
                            comboBox2.Text = "변수";
                        else
                            comboBox2.Text = "상수";
                        textBox2.Text = str;
                        break;
                    case 3:
                        if (isStringVariable(str))
                            comboBox3.Text = "변수";
                        else
                            comboBox3.Text = "상수";
                        textBox3.Text = str;
                        break;
                    case 4:
                        if (isStringVariable(str))
                            comboBox4.Text = "변수";
                        else
                            comboBox4.Text = "상수";
                        textBox4.Text = str;
                        break;
                    case 5:
                        if (isStringVariable(str))
                            comboBox5.Text = "변수";
                        else
                            comboBox5.Text = "상수";
                        textBox5.Text = str;
                        break;
                    case 6:
                        if (isStringVariable(str))
                            comboBox6.Text = "변수";
                        else
                            comboBox6.Text = "상수";
                        textBox6.Text = str;
                        break;
                    case 7:
                        if (isStringVariable(str))
                            comboBox7.Text = "변수";
                        else
                            comboBox7.Text = "상수";
                        textBox7.Text = str;
                        break;
                    case 8:
                        if (isStringVariable(str))
                            comboBox8.Text = "변수";
                        else
                            comboBox8.Text = "상수";
                        textBox8.Text = str;
                        break;

                }
                setNaming();
            }
        }

        /* Check String is Variable */
        private bool isStringVariable(string str)
        {
            if (Regex.IsMatch(str, "[[][A-Z][]]"))
                return true;
            else
                return false;
        }

        /* Open Template Clicked */
        private void OpenTemplate_Click(object sender, EventArgs e)
        {
            opfile.ShowDialog();

            readTemplate();
        }

        /* Read list.txt and set comboBox Initalize */
        private void fileInit()
        {
            FileInfo file = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TaskCollector\\list.txt");
            if (!file.Exists)
                filecnt = 0;
            else
            {
                MFile m = new MFile(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TaskCollector\\list.txt", FileMode.Open, FileAccess.Read);
                int i;
                for (i = 0; ; i++)
                {
                    if (m.eof)
                        break;
                    fileName[i] = m.ReadLine();
                }
                filecnt = i;
                for (i = 0; i < filecnt; i++)
                    opfile.addComponent(fileName[i]);
                m.Close();
            }
        }

        /* Get Selected File from SaveFile Form */
        public void getSelectedFile(string str)
        {
            this.selectedFile = str;
        }

        /* Download Button Clicked */
        private void button3_Click_1(object sender, EventArgs e)
        {
            getDownloadDir();
        }

        /* Get Real Download Directory */
        private void getDownloadDir()
        {
            for (int i = 0; i < foundcnt; i++)
            {
                string downloadDir = DirResult.Text;

                string downloadTitle = title[i];
                downloadTitle = convertIllegalCharacters(downloadTitle);
                Hashtable hash = new Hashtable();
                hash = setHashTitle(hash, downloadTitle);
                Regex reg = new Regex("[[][A-Z][]]");
                Match match = reg.Match(downloadDir);
                while (match.Success)
                {
                    string key = match.Groups[0].Value;
                    
                    downloadDir = downloadDir.Replace(key, hash[key].ToString());
                    match = reg.Match(downloadDir);
                }
                downloadDir = downloadDir.Replace("[학년]", hash["[학년]"].ToString());
                downloadDir = downloadDir.Replace("[반]", hash["[반]"].ToString());
                downloadDir = downloadDir.Replace("[번호]", hash["[번호]"].ToString());
                makeDownloadDir(downloadDir);
                downloadFiles(downloadDir, i);
                //MessageBox.Show("Scan Finish!" + downloadDir);
            }
            MessageBox.Show("Download Complete!");
        }

        /* Convert Folder Illegal Characters to [INV] */
        private string convertIllegalCharacters(string name) 
        {
            name = name.Replace("\\", "[INV]");
            name = name.Replace("/", "[INV]");
            name = name.Replace(":", "[INV]");
            name = name.Replace("*", "[INV]");
            name = name.Replace("?", "[INV]");
            name = name.Replace("\"", "[INV]");
            name = name.Replace("<", "[INV]");
            name = name.Replace(">", "[INV]");
            name = name.Replace("|", "[INV]");
            return name;
        }

        /* Make Download Directory*/
        private void makeDownloadDir(string DirLink)
        {
            DirectoryInfo Dir = new DirectoryInfo(DirLink);
            if (!Dir.Exists)
                Dir.Create();
        }

        /* Download Files*/
        private void downloadFiles(string DirLink, int i)
        {
            //Text Download
            MFile createBody = new MFile(DirLink + "body.txt", FileMode.OpenOrCreate, FileAccess.Write);
            string Data = "";
            Data += "<" + date[i][0] + "/" + date[i][1] + "/" + date[i][2] + "> - Num : " + ArticleList[i] + Environment.NewLine;
            Data += "[Title] : " + title[i] + Environment.NewLine + Environment.NewLine;
            Data += "[Body]" + Environment.NewLine;
            for (int j = 0; j < body[i].Length; j++)
                Data += body[i][j] + Environment.NewLine;
            createBody.WriteLine(Data);
            createBody.Close();

            //Files Download
            for (int k = 0; k < fTcnt[i]; k++)
            {
                HttpWebRequest Hwr2 = (HttpWebRequest)WebRequest.Create(fileLink[i][k].Substring(0, fileLink[i][k].IndexOf("?type=attachment")));
                Hwr2.Method = "GET";
                Hwr2.Referer = "http://cafe.naver.com/ArticleRead.nhn?clubid=" + cafeNum + "&articleid=" + ArticleList[i];
                Hwr2.CookieContainer = new CookieContainer();
                Hwr2.CookieContainer.Add(cookie);
                Hwr2.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/46.0.2490.71 Safari/537.36";

                HttpWebResponse response = (HttpWebResponse)Hwr2.GetResponse();

                Stream dataStream = response.GetResponseStream();

                byte[] data = ReadFully(dataStream);
                File.WriteAllBytes(DirLink + fileTitle[i][k], data);
                dataStream.Flush();
            }
        }

        /* Buffer[] to Stream */
        public static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        /* Set Variables Data to Hash */
        private Hashtable setHashTitle(Hashtable hash, string str)
        {
            for (int i = 0; i < namingArr.Length; i++)
            {
                if (namingArr[i] == null)
                    break;
                if (isStringVariable(namingArr[i]))
                {
                    string value;
                    if (namingArr[i + 1] != null)
                    {
                        value = substr(str, 0, str.IndexOf(namingArr[i + 1]));
                        str = str.Substring(str.IndexOf(namingArr[i + 1]));
                    }
                    else
                        value = str;
                    hash.Add(namingArr[i], value);

                }
                else if(namingArr[i]=="[학번]") {
                    string value = str.Substring(0, 5);
                    str = substr(str, 5, str.Length);
                    hash.Add("[학년]", value.Substring(0, 1));
                    hash.Add("[반]", value.Substring(1, 2));
                    hash.Add("[번호]", value.Substring(3, 2));
                }
                else
                {
                    if (str.IndexOf(namingArr[i]) != -1)
                    {
                        str = str.Substring(namingArr[i].Length);
                    }
                }
            }
            return hash;
        }

        /* File Viewer*/
        private void FileManager_Click(object sender, EventArgs e)
        {
            TextViewer viewer = new TextViewer(this.textviewerpath);
            viewer.Show();
        }

        /* Comment to Article */
        private void button7_Click(object sender, EventArgs e)
        {
            string fileName = "";
            string readData = "";

            openFileDialog1.Filter = "텍스트 문서(*.txt)|*.txt";
            openFileDialog1.InitialDirectory = @"C:\";
            if (commentpath != null)
                openFileDialog1.InitialDirectory = commentpath;
            openFileDialog1.Title = "열기";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;
                MFile m = new MFile(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                readData = m.ReadLine();
                m.Close();
                if (readData.IndexOf("Num : ") != -1)
                {
                    int article = int.Parse(substr(readData, readData.IndexOf("Num : ") + "Num : ".Length, readData.Length));
                    getCafeNumber();
                    Comment com = new Comment(@"http://cafe.naver.com/onlyonedsm/2481/comment", cookie, article, cafeNum, TargetText.Text);
                    com.Show();
                }
                else
                    MessageBox.Show("올바른 형식의 파일을 열어주세요!");
            }
        }

        /* Larger Button */
        private void largeButton_Click(object sender, EventArgs e)
        {
            if (largeButton.Text == ">")
            {
                this.MaximumSize = new Size(810, 487);
                for (int i = 694; i <= 810; i++)
                {
                    this.Size = new Size(i, 487);
                    largeButton.Location = new Point(largeButton.Location.X + 1, largeButton.Location.Y);
                }
                toolsLabel.Visible = true;
                button7.Visible = true;
                Help.Visible = true;
                FileManager.Visible = true;
                settingButton.Visible = true;
                largeButton.Text = "<";
                this.MinimumSize = new Size(810, 487);
            }
            else
            {
                this.MinimumSize = new Size(694, 487);
                for (int i = 810; i >= 694; i--)
                {
                    this.Size = new Size(i, 487);
                    largeButton.Location = new Point(largeButton.Location.X - 1, largeButton.Location.Y);
                }
                toolsLabel.Visible = false;
                button7.Visible = false;
                Help.Visible = false;
                FileManager.Visible = false;
                settingButton.Visible = false;
                largeButton.Text = ">";
                this.MaximumSize = new Size(694, 487);
            }
        }

        /* Setting Button */
        private void settingButton_Click(object sender, EventArgs e)
        {
            Setting set = new Setting(this as SettingInterface);
            set.getpath(this.commentpath, this.textviewerpath);
            set.Show();
        }

        /* File Path Initalize */
        private void filepathInit()
        {
            FileInfo f = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TaskCollector\\" + "log.txt");
            if (!f.Exists)
                f.Create();
            MFile m = new MFile(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TaskCollector\\" + "log.txt", FileMode.Open, FileAccess.Read);
            string[] path = new string[10];
            int i = 0;
            while (!m.eof)
            {
                path[i] = m.ReadLine();
                i++;
            }
            m.Close();

            if (i != 2)
            {
                MFile m2 = new MFile(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TaskCollector\\" + "log.txt", FileMode.Create, FileAccess.Write);

                m2.WriteLine(@"C:\");
                m2.WriteLine(@"C:\");
                m2.Close();  //닫혀있는 파일에 엑세스 불가
                return;
            }
            this.commentpath = path[0];
            this.textviewerpath = path[1];
            if (!new DirectoryInfo(this.commentpath).Exists)
                this.commentpath = null;
            if (!new DirectoryInfo(this.textviewerpath).Exists)
                this.textviewerpath = null;
        }

        /* Get Path from Setting Form */
        public void getpath(string pathA, string pathB)
        {
            this.commentpath = pathA;
            this.textviewerpath = pathB;
        }

        /* 기능 추가 예정 */
        private void Button_Click(object sender, EventArgs e)
        {
            Notice notice = new Notice();
            notice.Show();
        }

    }
}