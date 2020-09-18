using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Monitoring
{
    public partial class stanica : UserControl
    {

        float ramSize = 8;
        float ssdSize = 128;

        public bool IsRemovable;
        public string HostName { get; set; }
        public string Linka { get; set; }


        private float cpu;
        private float ram;
        private float ssd;

        public float SSD
        {
            get { return ssd; }
            set
            {
                ssd = value;
                NastavToolTip();
                int percento = (int)Math.Round((ssdSize - value) / ssdSize * 100, 0);
                pgbCPU.Value = percento;
                if (percento > 0 && percento <= 60)
                    pgbCPU.SetState(1); // green - normal status
                else if (percento > 60 && percento <= 80)
                    pgbCPU.SetState(3); // yelow - warning status
                else
                    pgbCPU.SetState(2); // red - error
            }
        }


        public float RAM
        {
            get { return ram; }
            set
            {
                ram = value;
                int percento = (int)Math.Round((ramSize - value) / ramSize * 100, 0);
                pgbCPU.Value = percento;
                NastavToolTip();
                if (percento > 0 && percento <= 20)
                    pgbCPU.SetState(0);
                else if (percento > 20 && percento <= 60)
                    pgbCPU.SetState(1);
                else
                    pgbCPU.SetState(2);
            }
        }


        public float CPU
        {
            get { return cpu; }
            set
            {
                cpu = value;
                pgbCPU.Value = (int)(Math.Round(value, 0));

            }
        }

        public string SledovanaVlastnost;



        public stanica(string hostName, string linka, int ssd, int cpu, int ram, bool isRemovable = true)
        {
            InitializeComponent();
            IsRemovable = isRemovable;
            SledovanaVlastnost = "SSDA";
            HostName = hostName;

            if (SledovanaVlastnost == "CPU") CPU = cpu;
            if (SledovanaVlastnost == "SSD") SSD = ssd;
            if (SledovanaVlastnost == "RAM") RAM = ram;
            Linka = linka;
            //Name = hostName;
            //    pgbSSD.Maximum = 130;
            //    this.label1.Text = HostName;

            NastavToolTip();
        }

        private void NastavToolTip()
        {
            toolTip1.SetToolTip(pgbCPU, "Stanica :" + HostName + "\n" + "Linka :" + Linka + "\n" + "Ram (free):" + RAM + "\n" + "CPU :" + CPU + "\n" + "SSD (free):" + SSD );
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }
        private Point Poloha { get; set; }
        private void pgbCPU_MouseClick(object sender, MouseEventArgs e)
        {
            if (IsRemovable)
                if (e.Button == MouseButtons.Right)
                {
                    Poloha = e.Location;
                    Poloha = new Point(Poloha.X / 10 * 10, Poloha.Y / 10 * 10);

                    stanica st = (stanica)(((ProgressBar)sender).Parent);

                    stanica ff = (stanica)(((ProgressBar)sender).Parent);
                    Editor fff = (Editor)(ff.Parent);



                    for (int i = 0; i < fff.Controls.Count; i++)
                    {
                        if (fff.Controls[i] is stanica)
                            if (st.HostName == ((stanica)(fff.Controls[i])).HostName)
                            {
                                if (MessageBox.Show("Naozaj vymatať?", "Pozor", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    fff.Controls.Remove(fff.Controls[i]);
                                    File.WriteAllLines(Path.Combine(Directory.GetCurrentDirectory(), "Ulozene", "suradnice.txt"),
                                      File.ReadLines(Path.Combine(Directory.GetCurrentDirectory(), "Ulozene", "suradnice.txt")).
                                      Where(l => l != (st.Linka + "->" + st.HostName + "-->" + st.Location.ToString())).ToList());
                                }

                            }
                    }

                }
        }

        private void pgbCPU_Click(object sender, EventArgs e)
        {

        }
    }
}
