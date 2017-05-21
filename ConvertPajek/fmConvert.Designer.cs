namespace ConvertPajek
{
    partial class fmConvert
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
            this.btnLoadMdf = new System.Windows.Forms.Button();
            this.btnLoadArticle = new System.Windows.Forms.Button();
            this.btnLoadCitation = new System.Windows.Forms.Button();
            this.btnLoadArticleFile = new System.Windows.Forms.Button();
            this.btnLoadCitationFile = new System.Windows.Forms.Button();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoadMdf
            // 
            this.btnLoadMdf.Location = new System.Drawing.Point(51, 18);
            this.btnLoadMdf.Name = "btnLoadMdf";
            this.btnLoadMdf.Size = new System.Drawing.Size(126, 23);
            this.btnLoadMdf.TabIndex = 0;
            this.btnLoadMdf.Text = "Load .mdf File";
            this.btnLoadMdf.UseVisualStyleBackColor = true;
            this.btnLoadMdf.Click += new System.EventHandler(this.btnLoadMdf_Click);
            // 
            // btnLoadArticle
            // 
            this.btnLoadArticle.Location = new System.Drawing.Point(231, 14);
            this.btnLoadArticle.Name = "btnLoadArticle";
            this.btnLoadArticle.Size = new System.Drawing.Size(182, 23);
            this.btnLoadArticle.TabIndex = 1;
            this.btnLoadArticle.Text = "Import Article";
            this.btnLoadArticle.UseVisualStyleBackColor = true;
            this.btnLoadArticle.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnLoadCitation
            // 
            this.btnLoadCitation.Location = new System.Drawing.Point(231, 43);
            this.btnLoadCitation.Name = "btnLoadCitation";
            this.btnLoadCitation.Size = new System.Drawing.Size(182, 23);
            this.btnLoadCitation.TabIndex = 2;
            this.btnLoadCitation.Text = "Import ArticleCitation";
            this.btnLoadCitation.UseVisualStyleBackColor = true;
            this.btnLoadCitation.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnLoadArticleFile
            // 
            this.btnLoadArticleFile.Location = new System.Drawing.Point(231, 108);
            this.btnLoadArticleFile.Name = "btnLoadArticleFile";
            this.btnLoadArticleFile.Size = new System.Drawing.Size(182, 23);
            this.btnLoadArticleFile.TabIndex = 3;
            this.btnLoadArticleFile.Text = "Import Article from .csv file";
            this.btnLoadArticleFile.UseVisualStyleBackColor = true;
            this.btnLoadArticleFile.Click += new System.EventHandler(this.btnLoadArticleFile_Click);
            // 
            // btnLoadCitationFile
            // 
            this.btnLoadCitationFile.Location = new System.Drawing.Point(231, 138);
            this.btnLoadCitationFile.Name = "btnLoadCitationFile";
            this.btnLoadCitationFile.Size = new System.Drawing.Size(182, 23);
            this.btnLoadCitationFile.TabIndex = 4;
            this.btnLoadCitationFile.Text = "Import ArticleCitation from .csv file";
            this.btnLoadCitationFile.UseVisualStyleBackColor = true;
            this.btnLoadCitationFile.Click += new System.EventHandler(this.btnLoadCitationFile_Click);
            // 
            // tbUsername
            // 
            this.tbUsername.Location = new System.Drawing.Point(94, 34);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(100, 26);
            this.tbUsername.TabIndex = 5;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(94, 66);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(100, 26);
            this.tbPassword.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Username";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbPassword);
            this.groupBox1.Controls.Add(this.tbUsername);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Setup Neo4j Connection";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Password";
            // 
            // fmConvert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 264);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnLoadCitationFile);
            this.Controls.Add(this.btnLoadArticleFile);
            this.Controls.Add(this.btnLoadCitation);
            this.Controls.Add(this.btnLoadArticle);
            this.Controls.Add(this.btnLoadMdf);
            this.Name = "fmConvert";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Convert To Pajek";
            this.Load += new System.EventHandler(this.fmConvert_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoadMdf;
        private System.Windows.Forms.Button btnLoadArticle;
        private System.Windows.Forms.Button btnLoadCitation;
        private System.Windows.Forms.Button btnLoadArticleFile;
        private System.Windows.Forms.Button btnLoadCitationFile;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
    }
}

