using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Web;

namespace practice0CSharp
{
    public partial class Comment : Form
    {
        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool InternetSetCookie(string lpszUrlName, string lbszCookieName, string lpszCookieData);
        private string address = "";
        private int articleNum = 0;
        private int cafeNum = 0;
        private string cafeName = null;
        private int emotion = 0;
        private CookieCollection cookie = null;
        public Comment()
        {
            InitializeComponent();
        }

        public Comment(string link, CookieCollection cook, int articleNum, int cafeNum, string cafeName)
        {
            InitializeComponent();
            this.cookie = cook;
            this.address = link;
            this.articleNum = articleNum;
            this.cafeNum = cafeNum;
            this.cafeName = cafeName;
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            //퍼스나콘 (아이콘) 읽어오기
            string responsefromserver = "";
            HttpWebRequest Hwr2 = (HttpWebRequest)WebRequest.Create(cafeName + "/" + articleNum + "/comment");
            Hwr2.Method = "GET";

            Hwr2.CookieContainer = new CookieContainer();
            Hwr2.CookieContainer.Add(cookie);

            HttpWebResponse response = (HttpWebResponse)Hwr2.GetResponse();

            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream, Encoding.Default);

            responsefromserver = reader.ReadToEnd();
            responsefromserver = responsefromserver.Substring(responsefromserver.IndexOf("reply-write-ico"));
            responsefromserver = responsefromserver.Substring(responsefromserver.IndexOf("http://itemimgs.naver.net/personacon"), responsefromserver.IndexOf(".gif") - responsefromserver.IndexOf("http://itemimgs.naver.net/personacon"));
            responsefromserver = responsefromserver.Substring(responsefromserver.LastIndexOf("/") + 1);
            this.emotion = int.Parse(responsefromserver);

            sendComment();
        }
        private void sendComment()
        {
            //댓글 입력하기
            const string header_UA = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; Trident/6.0)";
            const string header_ConType = "application/x-www-form-urlencoded";
            HttpWebRequest Hwr2 = (HttpWebRequest)WebRequest.Create("http://cafe.naver.com/CommentPost.nhn");
            Hwr2.Method = "POST";
            Hwr2.Referer = "http://cafe.naver.com/onlyonedsm/" + articleNum + "/comment?referrerAllArticles=true";
            Hwr2.UserAgent = header_UA;
            Hwr2.ContentType = header_ConType;
            Hwr2.CookieContainer = new CookieContainer();
            Hwr2.CookieContainer.Add(cookie);

            System.IO.Stream str = Hwr2.GetRequestStream();
            System.IO.StreamWriter stwr = new System.IO.StreamWriter(str, Encoding.Default);
            stwr.Write("content=" + (sendText.Text) + "&clubid=" + cafeNum + "&articleid=" + articleNum + "&m=write&commentid=&refcommentid=&emotion=" + emotion);
            MessageBox.Show("Success!");
            stwr.Flush(); stwr.Close(); stwr.Dispose();
            str.Flush(); str.Close(); str.Dispose();

            HttpWebResponse response = (HttpWebResponse)Hwr2.GetResponse();
        }
        /*
        private void Comment_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < this.cookie.Count; i++)
            {
                Cookie c = cookie[i];
                InternetSetCookie(this.address, c.Name, c.Value);
            }
            webBrowser1.Navigate(address, null, null,
                "Referer:http://cafe.naver.com/onlyonedsm/2499/comment?referrerAllArticles=true");
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(address);
        }
         * */
    }
}
