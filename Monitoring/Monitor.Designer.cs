namespace Monitoring
{
    partial class Monitor
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Monitor));
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.rbSSD = new System.Windows.Forms.RadioButton();
      this.rbRAM = new System.Windows.Forms.RadioButton();
      this.rbCPU = new System.Windows.Forms.RadioButton();
      this.rbAll = new System.Windows.Forms.RadioButton();
      this.label1 = new System.Windows.Forms.Label();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox1.Controls.Add(this.rbSSD);
      this.groupBox1.Controls.Add(this.rbRAM);
      this.groupBox1.Controls.Add(this.rbCPU);
      this.groupBox1.Controls.Add(this.rbAll);
      this.groupBox1.Location = new System.Drawing.Point(943, 107);
      this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
      this.groupBox1.Size = new System.Drawing.Size(84, 150);
      this.groupBox1.TabIndex = 1;
      this.groupBox1.TabStop = false;
      // 
      // rbSSD
      // 
      this.rbSSD.AutoSize = true;
      this.rbSSD.Location = new System.Drawing.Point(8, 108);
      this.rbSSD.Margin = new System.Windows.Forms.Padding(4);
      this.rbSSD.Name = "rbSSD";
      this.rbSSD.Size = new System.Drawing.Size(57, 21);
      this.rbSSD.TabIndex = 3;
      this.rbSSD.Text = "SSD";
      this.rbSSD.UseVisualStyleBackColor = true;
      // 
      // rbRAM
      // 
      this.rbRAM.AutoSize = true;
      this.rbRAM.Location = new System.Drawing.Point(8, 79);
      this.rbRAM.Margin = new System.Windows.Forms.Padding(4);
      this.rbRAM.Name = "rbRAM";
      this.rbRAM.Size = new System.Drawing.Size(59, 21);
      this.rbRAM.TabIndex = 2;
      this.rbRAM.Text = "RAM";
      this.rbRAM.UseVisualStyleBackColor = true;
      // 
      // rbCPU
      // 
      this.rbCPU.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.rbCPU.AutoSize = true;
      this.rbCPU.Location = new System.Drawing.Point(8, 50);
      this.rbCPU.Margin = new System.Windows.Forms.Padding(4);
      this.rbCPU.Name = "rbCPU";
      this.rbCPU.Size = new System.Drawing.Size(57, 21);
      this.rbCPU.TabIndex = 1;
      this.rbCPU.Text = "CPU";
      this.rbCPU.UseVisualStyleBackColor = true;
      // 
      // rbAll
      // 
      this.rbAll.AutoSize = true;
      this.rbAll.Checked = true;
      this.rbAll.Location = new System.Drawing.Point(8, 22);
      this.rbAll.Margin = new System.Windows.Forms.Padding(4);
      this.rbAll.Name = "rbAll";
      this.rbAll.Size = new System.Drawing.Size(44, 21);
      this.rbAll.TabIndex = 0;
      this.rbAll.TabStop = true;
      this.rbAll.Text = "All";
      this.rbAll.UseVisualStyleBackColor = true;
      // 
      // label1
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.label1.Location = new System.Drawing.Point(943, 71);
      this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(83, 28);
      this.label1.TabIndex = 4;
      this.label1.Text = "Reload";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.label1.Click += new System.EventHandler(this.label1_Click);
      // 
      // Monitor
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
      this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
      this.ClientSize = new System.Drawing.Size(1067, 554);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.groupBox1);
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "Monitor";
      this.Text = "Monitor";
      this.Load += new System.EventHandler(this.Monitor_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbSSD;
        private System.Windows.Forms.RadioButton rbRAM;
        private System.Windows.Forms.RadioButton rbCPU;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.Label label1;
    }
}