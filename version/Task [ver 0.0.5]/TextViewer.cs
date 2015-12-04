using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mlib;

namespace practice0CSharp
{

    public partial class TextViewer : Form, ViewInterface
    {
        private string openedFile = null;
        private int cursorPos = -1;
        public TextViewer()
        {
            InitializeComponent();
            textBox1.ScrollBars = ScrollBars.Vertical;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if(cursorPos == -1)
                cursorPos = textBox1.SelectionStart;
            cursorPos = textBox1.SelectionStart + textBox1.SelectionLength;
            search(textBox1.Text, cursorPos);
        }
        private void search(string str, int start)
        {
            string sub = substr(str, start, textBox1.TextLength);
            if (sub.IndexOf(searchText.Text) != -1)
            {
                textBox1.SelectionStart = start + sub.IndexOf(searchText.Text);
                textBox1.SelectionLength = searchText.Text.Length;
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

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.A)
                {
                    textBox1.SelectAll();
                }
                if(e.KeyCode == Keys.F)
                {
                    ViewerSearch search = new ViewerSearch(this as ViewInterface);
                    search.Show();
                }
                if(e.KeyCode == Keys.H)
                {
                    ViewerSearch search = new ViewerSearch(this as ViewInterface, true);
                    search.Show();
                }
                if (e.KeyCode == Keys.O)
                {
                    열기ToolStripMenuItem_Click(new object(), new EventArgs());
                }
                if (e.KeyCode == Keys.S)
                {
                    저장ToolStripMenuItem_Click(new object(), new EventArgs());
                }
            }
        }

        private void 바꾸기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewerSearch search = new ViewerSearch(this as ViewInterface, true);
            search.Show();
        }
        public string getText(string text)
        {
            return text;
        }
        public TextBox getTextArea()
        {
            return textBox1;
        }

        private void 열기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fileName = "";
            string readData = "";

            openFileDialog1.Filter = "텍스트 문서(*.txt)|*.txt";
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Title = "열기";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;
                MFile m = new MFile(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                while (!m.eof)
                    readData += m.ReadLine() + Environment.NewLine;
                textBox1.Text = readData;
                this.openedFile = fileName;
                this.Text = "TextViewer - " + this.openedFile;
                m.Close();
            }
        }

        private void TextViewer_SizeChanged(object sender, EventArgs e)
        {
            textBox1.Size = new Size(this.Size.Width-40,this.Size.Height-78);
            menuStrip1.Size = new Size(this.Size.Width-16,menuStrip1.Size.Height);
        }

        private void 다른이름으로저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fileName = "";
            saveFileDialog1.Filter = "텍스트 문서(*.txt)|*.txt";
            saveFileDialog1.InitialDirectory = @"C:\";
            saveFileDialog1.Title = "다른 이름으로 저장";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog1.FileName;
                MFile m = new MFile(fileName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
                m.WriteLine(textBox1.Text);
                this.openedFile = fileName;
                this.Text = "TextViewer - " + this.openedFile;
                m.Close();
            }
        }

        private void 저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.openedFile == null)
                다른이름으로저장ToolStripMenuItem_Click(new object(), new EventArgs());
            else
            {
                string fileName = openedFile;
                MFile m = new MFile(fileName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
                m.WriteLine(textBox1.Text);
                this.openedFile = fileName;
                this.Text = "TextViewer - " + this.openedFile;
                m.Close();
            }
        }
    }
}
