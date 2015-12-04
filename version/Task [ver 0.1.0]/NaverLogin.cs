using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// User Defined
using System.Net;
using Noesis.Javascript;
using System.IO;

namespace practice0CSharp
{
    class NLoginCLS
    {
        private IMyInterface frm = null;
        public NLoginCLS()
        {

        }
        public NLoginCLS(IMyInterface frm)
        {
            this.frm = frm;
        }
        CookieContainer cookies = new CookieContainer();
        CookieCollection cookie;
        public bool Login(string id, string pw)
        {
            const string keyuri = "http://static.nid.naver.com/enclogin/keys.nhn";
            const string pouri = "https://nid.naver.com/nidlogin.login";
            const string header_refereruri = "http://static.nid.naver.com/login.nhn?svc=wme&amp;url=http%3A%2F%2Fwww.naver.com&amp;t=20120425";
            const string header_UA = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; Trident/6.0)";
            const string header_ConType = "application/x-www-form-urlencoded";
            const string POSTFormatString = "enctp=1&encpw={0}&encnm={1}&svctype=0&id=&pw=&x=35&y=14";

            WebClient w = new WebClient();
            String tmp = w.DownloadString(keyuri);
            w.Dispose();


            List<string> p = new List<string>();
            p.AddRange(tmp.Split(','));
            string Rr = CreateRSA(id, pw, p);

            //System.Windows.Forms.MessageBox.Show("Rr = " + Rr);

            HttpWebRequest Hwr = (HttpWebRequest)HttpWebRequest.Create(pouri);
            Hwr.CookieContainer = cookies;

            Hwr.Method = "POST";
            Hwr.Referer = header_refereruri;
            Hwr.UserAgent = header_UA;
            Hwr.ContentType = header_ConType;
            System.IO.Stream str = Hwr.GetRequestStream();
            System.IO.StreamWriter stwr = new System.IO.StreamWriter(str);
            stwr.Write(string.Format(POSTFormatString, Rr, p[1]));
            stwr.Flush(); stwr.Close(); stwr.Dispose();
            str.Flush(); str.Close(); str.Dispose();


            HttpWebResponse wres = (HttpWebResponse)Hwr.GetResponse();
            System.IO.Stream strr = wres.GetResponseStream();
            System.IO.StreamReader strrr = new System.IO.StreamReader(strr);
            string Result = strrr.ReadToEnd();
            cookie = wres.Cookies;

            //System.Windows.Forms.MessageBox.Show("result = " + Result);

            if (Result.Contains("location.replace"))
            {
                frm.getCookie(wres.Cookies);
                return true;
            }
            else
            {
                return false;
            }
        }
        private string CreateRSA(string id, string pw, List<string> lst)
        {
            using (Noesis.Javascript.JavascriptContext c = new Noesis.Javascript.JavascriptContext())
            {
                c.SetParameter("vvv_id", id);
                c.SetParameter("vvv_pw", pw);
                for (int i = 0; i < 4; i++)
                {
                    c.SetParameter("vvv_" + i.ToString(), lst[i]);
                }
                c.SetParameter("vvv_Resu", string.Empty);
                string scriptc = practice0CSharp.Properties.Resources.RSAJS;
                scriptc = scriptc + "\n\nvvv_Resu = createRsaKey(vvv_id,vvv_pw,vvv_0,vvv_1,vvv_2,vvv_3);";
                try
                {
                    c.Run(scriptc);
                }
                catch(JavascriptException){

                }
                return (c.GetParameter("vvv_Resu") as string);
            }
        }
    }
}
