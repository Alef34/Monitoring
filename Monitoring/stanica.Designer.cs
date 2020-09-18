namespace Monitoring
{
    partial class stanica
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pgbCPU = new System.Windows.Forms.ProgressBar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // pgbCPU
            // 
            this.pgbCPU.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pgbCPU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgbCPU.ForeColor = System.Drawing.Color.Red;
            this.pgbCPU.Location = new System.Drawing.Point(0, 0);
            this.pgbCPU.Name = "pgbCPU";
            this.pgbCPU.Size = new System.Drawing.Size(51, 51);
            this.pgbCPU.TabIndex = 2;
            this.pgbCPU.Click += new System.EventHandler(this.pgbCPU_Click);
            this.pgbCPU.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pgbCPU_MouseClick);
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ShowAlways = true;
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // stanica
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.pgbCPU);
            this.Name = "stanica";
            this.Size = new System.Drawing.Size(51, 51);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar pgbCPU;
    private System.Windows.Forms.ToolTip toolTip1;
  }
}
