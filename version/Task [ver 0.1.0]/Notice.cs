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
    public partial class Notice : Form
    {
        public Notice()
        {
            InitializeComponent();
            this.groupBox2.Click += new System.EventHandler(this.groupBox2_Click);
            this.groupBox3.Click += new System.EventHandler(this.groupBox3_Click);
        }
        private void groupBox2_Click(object sender, EventArgs e)
        {
            //group3 visible
            if (groupBox2.Size.Width != 553)
            {
                groupBox3.Visible = false;
                for (int i = groupBox2.Size.Width; i <= 553; i++)
                    groupBox2.Size = new Size(i, groupBox2.Size.Height);
                for (int i = groupBox2.Size.Height; i <= 268; i++)
                    groupBox2.Size = new Size(groupBox2.Size.Width, i);
            }
            else
            {
                for (int i = groupBox2.Size.Height; i >= 13; i--)
                    groupBox2.Size = new Size(groupBox2.Size.Width, i);
                for (int i = groupBox2.Size.Width; i >= 50; i--)
                    groupBox2.Size = new Size(i, groupBox2.Size.Height);
                groupBox3.Visible = true;
            }
        }

        private void groupBox3_Click(object sender, EventArgs e)
        {
            if (groupBox3.Size.Width != 553)
            {
                for (int i = groupBox3.Size.Width; i <= 553; i++)
                    groupBox3.Size = new Size(i, groupBox3.Size.Height);
                for (int i = groupBox3.Size.Height; i <= 268; i++)
                    groupBox3.Size = new Size(groupBox3.Size.Width, i);
            }
            else
            {
                for (int i = groupBox3.Size.Height; i >= 13; i--)
                    groupBox3.Size = new Size(groupBox3.Size.Width, i);
                for (int i = groupBox3.Size.Width; i >= 59; i--)
                    groupBox3.Size = new Size(i, groupBox3.Size.Height);
            }
        }
    }
}
