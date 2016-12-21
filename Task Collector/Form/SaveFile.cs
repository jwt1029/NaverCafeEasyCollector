using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mlib;

namespace practice0CSharp
{
    public partial class SaveFile : Form
    {
        int namecnt;
        string[] namingArr;
        string[] fileName;
        public SaveFile()
        {
            InitializeComponent();
        }
        public SaveFile(int namecnt, string[] namingArr, string[] fileName)
        {
            InitializeComponent();
            this.namecnt = namecnt;
            this.namingArr = namingArr;
            this.fileName = fileName;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DirectoryInfo Dir = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TaskCollector");
            if (!Dir.Exists)
                Dir.Create();
            if (new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TaskCollector\\" + textBox1.Text + ".txt").Exists)
            {
                MessageBox.Show("이미 사용된 이름입니다!");
                return;
            }

            MFile wr = new MFile(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TaskCollector\\list.txt", FileMode.OpenOrCreate, FileAccess.Write);
            for (int i = 0; ; i++)
            {
                if (fileName[i] == null || fileName[i] == "")
                    break;
                wr.WriteLine(fileName[i]);
            }
            wr.WriteLine(textBox1.Text);
            MFile m = new MFile(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TaskCollector\\" + textBox1.Text + ".txt", FileMode.Create, FileAccess.Write);
            m.WriteLine(namecnt.ToString());
            for (int i = 0; i < namecnt; i++)
                m.WriteLine(namingArr[i]);
            this.Close();
        }
    }
}
