namespace practice0CSharp
{
    partial class ViewerSearch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.searchText = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.replaceText = new System.Windows.Forms.TextBox();
            this.leftsearch = new System.Windows.Forms.Button();
            this.replacebt = new System.Windows.Forms.Button();
            this.replaceAllbt = new System.Windows.Forms.Button();
            this.rightsearch = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.searchText);
            this.groupBox1.Location = new System.Drawing.Point(37, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 79);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "찾기";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "찾을 텍스트";
            // 
            // searchText
            // 
            this.searchText.Location = new System.Drawing.Point(83, 36);
            this.searchText.Name = "searchText";
            this.searchText.Size = new System.Drawing.Size(249, 21);
            this.searchText.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.replaceText);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(38, 131);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(346, 85);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "바꾸기";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "바꿀 텍스트";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(25, 124);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // replaceText
            // 
            this.replaceText.Location = new System.Drawing.Point(82, 39);
            this.replaceText.Name = "replaceText";
            this.replaceText.Size = new System.Drawing.Size(249, 21);
            this.replaceText.TabIndex = 2;
            // 
            // leftsearch
            // 
            this.leftsearch.Location = new System.Drawing.Point(40, 226);
            this.leftsearch.Name = "leftsearch";
            this.leftsearch.Size = new System.Drawing.Size(75, 23);
            this.leftsearch.TabIndex = 4;
            this.leftsearch.Text = "이전 찾기";
            this.leftsearch.UseVisualStyleBackColor = true;
            this.leftsearch.Click += new System.EventHandler(this.leftsearch_Click);
            // 
            // replacebt
            // 
            this.replacebt.Location = new System.Drawing.Point(215, 226);
            this.replacebt.Name = "replacebt";
            this.replacebt.Size = new System.Drawing.Size(75, 23);
            this.replacebt.TabIndex = 5;
            this.replacebt.Text = "바꾸기";
            this.replacebt.UseVisualStyleBackColor = true;
            this.replacebt.Click += new System.EventHandler(this.replacebt_Click);
            // 
            // replaceAllbt
            // 
            this.replaceAllbt.Location = new System.Drawing.Point(303, 226);
            this.replaceAllbt.Name = "replaceAllbt";
            this.replaceAllbt.Size = new System.Drawing.Size(78, 23);
            this.replaceAllbt.TabIndex = 6;
            this.replaceAllbt.Text = "모두 바꾸기";
            this.replaceAllbt.UseVisualStyleBackColor = true;
            this.replaceAllbt.Click += new System.EventHandler(this.replaceAllbt_Click);
            // 
            // rightsearch
            // 
            this.rightsearch.Location = new System.Drawing.Point(127, 226);
            this.rightsearch.Name = "rightsearch";
            this.rightsearch.Size = new System.Drawing.Size(75, 23);
            this.rightsearch.TabIndex = 7;
            this.rightsearch.Text = "다음 찾기";
            this.rightsearch.UseVisualStyleBackColor = true;
            this.rightsearch.Click += new System.EventHandler(this.rightsearch_Click);
            // 
            // ViewerSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 261);
            this.Controls.Add(this.rightsearch);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.replaceAllbt);
            this.Controls.Add(this.replacebt);
            this.Controls.Add(this.leftsearch);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ViewerSearch";
            this.Text = "ViewerSearch";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button leftsearch;
        private System.Windows.Forms.Button replacebt;
        private System.Windows.Forms.Button replaceAllbt;
        private System.Windows.Forms.Button rightsearch;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox replaceText;
    }
}