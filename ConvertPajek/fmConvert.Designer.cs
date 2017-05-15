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
            this.SuspendLayout();
            // 
            // btnLoadMdf
            // 
            this.btnLoadMdf.Location = new System.Drawing.Point(34, 12);
            this.btnLoadMdf.Name = "btnLoadMdf";
            this.btnLoadMdf.Size = new System.Drawing.Size(126, 23);
            this.btnLoadMdf.TabIndex = 0;
            this.btnLoadMdf.Text = "Load .mdf File";
            this.btnLoadMdf.UseVisualStyleBackColor = true;
            this.btnLoadMdf.Click += new System.EventHandler(this.btnLoadMdf_Click);
            // 
            // fmConvert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 264);
            this.Controls.Add(this.btnLoadMdf);
            this.Name = "fmConvert";
            this.Text = "Convert To Pajek";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoadMdf;
    }
}

