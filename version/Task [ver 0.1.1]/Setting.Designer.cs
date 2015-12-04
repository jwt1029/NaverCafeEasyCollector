namespace practice0CSharp
{
    partial class Setting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setting));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textviewerText = new System.Windows.Forms.TextBox();
            this.textviewerButton = new System.Windows.Forms.Button();
            this.commentText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.commentButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textviewerText);
            this.groupBox1.Controls.Add(this.textviewerButton);
            this.groupBox1.Controls.Add(this.commentText);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.commentButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(493, 74);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "기본 경로";
            // 
            // textviewerText
            // 
            this.textviewerText.Enabled = false;
            this.textviewerText.Location = new System.Drawing.Point(98, 43);
            this.textviewerText.Name = "textviewerText";
            this.textviewerText.Size = new System.Drawing.Size(351, 21);
            this.textviewerText.TabIndex = 5;
            // 
            // textviewerButton
            // 
            this.textviewerButton.Image = ((System.Drawing.Image)(resources.GetObject("textviewerButton.Image")));
            this.textviewerButton.Location = new System.Drawing.Point(451, 42);
            this.textviewerButton.Name = "textviewerButton";
            this.textviewerButton.Size = new System.Drawing.Size(23, 22);
            this.textviewerButton.TabIndex = 6;
            this.textviewerButton.UseVisualStyleBackColor = true;
            this.textviewerButton.Click += new System.EventHandler(this.textviewerButton_Click);
            // 
            // commentText
            // 
            this.commentText.Enabled = false;
            this.commentText.Location = new System.Drawing.Point(98, 16);
            this.commentText.Name = "commentText";
            this.commentText.Size = new System.Drawing.Size(351, 21);
            this.commentText.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Text Viewer";
            // 
            // commentButton
            // 
            this.commentButton.Image = ((System.Drawing.Image)(resources.GetObject("commentButton.Image")));
            this.commentButton.Location = new System.Drawing.Point(451, 15);
            this.commentButton.Name = "commentButton";
            this.commentButton.Size = new System.Drawing.Size(23, 22);
            this.commentButton.TabIndex = 5;
            this.commentButton.UseVisualStyleBackColor = true;
            this.commentButton.Click += new System.EventHandler(this.commentButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Comment";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(422, 213);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(83, 36);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(333, 213);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(83, 36);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 261);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.groupBox1);
            this.Name = "Setting";
            this.Text = "Setting";
            this.Load += new System.EventHandler(this.Setting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox commentText;
        private System.Windows.Forms.Button commentButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textviewerText;
        private System.Windows.Forms.Button textviewerButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
    }
}