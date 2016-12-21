using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mlib;
using System.IO;

namespace NaverCafeEditor
{
    public interface SettingInterface
    {
        void getpath(string pathA, string pathB);
    }
    public partial class Setting : Form
    {
        private SettingInterface frm = null;
        private string commentpath = null;
        private string textviewerpath = null;
        public Setting()
        {
            InitializeComponent();
        }
        public Setting(SettingInterface frm)
        {
            InitializeComponent();
            this.frm = frm;
        }

        private void commentButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                commentText.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void textviewerButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textviewerText.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if(this.commentpath != commentText.Text || this.textviewerpath != textviewerText.Text)
            {
                switch (MessageBox.Show("변경된 내용을 저장하시겠습니까?", "Save?", MessageBoxButtons.YesNo))
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        saveButton_Click(new object(), new EventArgs());
                        break;
                    case System.Windows.Forms.DialogResult.No:
                        break;
                }
            }
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            MFile m = new MFile(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TaskCollector\\" + "log.txt", FileMode.Create, FileAccess.Write);
            m.WriteLine(commentText.Text);
            this.commentpath = commentText.Text;
            m.WriteLine(textviewerText.Text);
            this.textviewerpath = textviewerText.Text;
            m.Close();
            frm.getpath(commentpath, textviewerpath);
            MessageBox.Show("저장 되었습니다");
            this.Close();
        }
        public void getpath(string pathA, string pathB)
        {
            this.commentpath = pathA;
            this.textviewerpath = pathB;
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            if (this.commentpath != null)
                commentText.Text = this.commentpath;
            if (this.textviewerpath != null)
                textviewerText.Text = this.textviewerpath;
        }
    }
}
