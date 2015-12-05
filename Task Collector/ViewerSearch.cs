using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace practice0CSharp
{
    public interface ViewInterface
    {
        string getText(string text);
        TextBox getTextArea();
    }
    public partial class ViewerSearch : Form, ViewInterface
    {
        private int start = 0;
        private ViewInterface frm = null;
        TextBox textBox1;
        
        public ViewerSearch()
        {
            InitializeComponent();
        }
        public ViewerSearch(ViewInterface frm)
        {
            InitializeComponent();
            this.frm = frm;
            textBox1 = frm.getTextArea();
        }
        public ViewerSearch(ViewInterface frm, bool check)
        {
            InitializeComponent();
            this.frm = frm;
            textBox1 = frm.getTextArea();
            if (check == true)
                checkBox1.Checked = true;
            else
                checkBox1.Checked = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                groupBox2.Enabled = true;
            else
                groupBox2.Enabled = false;
        }

        private void leftsearch_Click(object sender, EventArgs e)
        {
            string sub = substr(textBox1.Text, 0, start);
            if (sub.IndexOf(searchText.Text) != -1)
            {
                textBox1.SelectionStart = sub.LastIndexOf(searchText.Text);
                textBox1.SelectionLength = searchText.Text.Length;
                start = textBox1.SelectionStart;
            }
            else
            {
                MessageBox.Show("더 이상 찾을 수 없습니다");
            }
        }

        private void rightsearch_Click(object sender, EventArgs e)
        {
            string sub = substr(textBox1.Text, start, textBox1.TextLength);
            sub = substr(textBox1.Text, start, textBox1.TextLength);
            if (sub.IndexOf(searchText.Text) != -1)
            {
                textBox1.SelectionStart = start + sub.IndexOf(searchText.Text);
                textBox1.SelectionLength = searchText.Text.Length;
                start = textBox1.SelectionStart + textBox1.SelectionLength;
            }
            else
            {
                MessageBox.Show("문자열을 찾을 수 없습니다");
            }
        }
        private string substr(string str, int st, int ed)
        {
            return str.Substring(st, ed - 1 - st);
        }

        private void replacebt_Click(object sender, EventArgs e)
        {
            string sub = textBox1.Text.Substring(textBox1.SelectionStart, textBox1.SelectionLength);
            if (sub == searchText.Text)
            {
                Regex regex = new Regex(Regex.Escape(searchText.Text));
                string newText = regex.Replace(textBox1.Text.Substring(textBox1.SelectionStart), replaceText.Text, 1);
                textBox1.Text = textBox1.Text.Substring(0, textBox1.SelectionStart) + newText;
            }
            rightsearch_Click(new object(), new EventArgs());
        }

        private void replaceAllbt_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.IndexOf(searchText.Text)!=-1)
                textBox1.Text = textBox1.Text.Replace(searchText.Text, replaceText.Text);
            else
                MessageBox.Show("문자열을 찾을 수 없습니다");
        }
        public string getText(string text)
        {
            return text;
        }

        public TextBox getTextArea()
        {
            return null;
        }
    }
}
