
namespace impositionApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDPI = new System.Windows.Forms.TextBox();
            this.bttnRun = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPagesPerSig = new System.Windows.Forms.TextBox();
            this.tbHeightIn = new System.Windows.Forms.TextBox();
            this.tbWidthIN = new System.Windows.Forms.TextBox();
            this.bttnFixText = new System.Windows.Forms.Button();
            this.tboutputPath = new System.Windows.Forms.TextBox();
            this.tbinputPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(92, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 15);
            this.label4.TabIndex = 18;
            this.label4.Text = "DPI";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 17;
            this.label3.Text = "Width (in)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "Hieght (in)";
            // 
            // tbDPI
            // 
            this.tbDPI.Location = new System.Drawing.Point(123, 156);
            this.tbDPI.Name = "tbDPI";
            this.tbDPI.Size = new System.Drawing.Size(421, 23);
            this.tbDPI.TabIndex = 15;
            this.tbDPI.Text = "655";
            this.tbDPI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bttnRun
            // 
            this.bttnRun.Location = new System.Drawing.Point(12, 194);
            this.bttnRun.Name = "bttnRun";
            this.bttnRun.Size = new System.Drawing.Size(532, 23);
            this.bttnRun.TabIndex = 10;
            this.bttnRun.Text = "Run";
            this.bttnRun.UseVisualStyleBackColor = true;
            this.bttnRun.Click += new System.EventHandler(this.bttnRun_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "pages per signature";
            // 
            // tbPagesPerSig
            // 
            this.tbPagesPerSig.Location = new System.Drawing.Point(123, 69);
            this.tbPagesPerSig.Name = "tbPagesPerSig";
            this.tbPagesPerSig.Size = new System.Drawing.Size(421, 23);
            this.tbPagesPerSig.TabIndex = 11;
            this.tbPagesPerSig.Text = "32";
            this.tbPagesPerSig.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbHeightIn
            // 
            this.tbHeightIn.Location = new System.Drawing.Point(123, 127);
            this.tbHeightIn.Name = "tbHeightIn";
            this.tbHeightIn.Size = new System.Drawing.Size(421, 23);
            this.tbHeightIn.TabIndex = 13;
            this.tbHeightIn.Text = "8.5";
            this.tbHeightIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbWidthIN
            // 
            this.tbWidthIN.Location = new System.Drawing.Point(123, 98);
            this.tbWidthIN.Name = "tbWidthIN";
            this.tbWidthIN.Size = new System.Drawing.Size(421, 23);
            this.tbWidthIN.TabIndex = 12;
            this.tbWidthIN.Text = "5.5";
            this.tbWidthIN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bttnFixText
            // 
            this.bttnFixText.Location = new System.Drawing.Point(22, 345);
            this.bttnFixText.Name = "bttnFixText";
            this.bttnFixText.Size = new System.Drawing.Size(211, 23);
            this.bttnFixText.TabIndex = 19;
            this.bttnFixText.Text = "Fix text";
            this.bttnFixText.UseVisualStyleBackColor = true;
            this.bttnFixText.Click += new System.EventHandler(this.bttnFixText_Click);
            // 
            // tboutputPath
            // 
            this.tboutputPath.Location = new System.Drawing.Point(123, 40);
            this.tboutputPath.Name = "tboutputPath";
            this.tboutputPath.Size = new System.Drawing.Size(421, 23);
            this.tboutputPath.TabIndex = 20;
            this.tboutputPath.Text = "M:\\Google Drive\\!Art\\Hobbit\\RuneBook\\Output\\";
            this.tboutputPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbinputPath
            // 
            this.tbinputPath.Location = new System.Drawing.Point(123, 11);
            this.tbinputPath.Name = "tbinputPath";
            this.tbinputPath.Size = new System.Drawing.Size(421, 23);
            this.tbinputPath.TabIndex = 21;
            this.tbinputPath.Text = "M:\\Google Drive\\!Art\\Hobbit\\RuneBook\\Pages\\";
            this.tbinputPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 15);
            this.label5.TabIndex = 22;
            this.label5.Text = "Output Path";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(53, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 15);
            this.label6.TabIndex = 23;
            this.label6.Text = "Input Path";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 227);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbinputPath);
            this.Controls.Add(this.tboutputPath);
            this.Controls.Add(this.bttnFixText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbDPI);
            this.Controls.Add(this.bttnRun);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPagesPerSig);
            this.Controls.Add(this.tbHeightIn);
            this.Controls.Add(this.tbWidthIN);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDPI;
        private System.Windows.Forms.Button bttnRun;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPagesPerSig;
        private System.Windows.Forms.TextBox tbHeightIn;
        private System.Windows.Forms.TextBox tbWidthIN;
        private System.Windows.Forms.Button bttnFixText;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox tboutputPath;
        private System.Windows.Forms.TextBox tbinputPath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

