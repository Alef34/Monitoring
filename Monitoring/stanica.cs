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
    public string HostName { get; set; }
    public string Linka { get; set; }
    public int SSD { get; set; }
    public int RAM { get; set; }
    public int CPU { get; set; }

    //public int PgbSSDFree
    //{
    //  get { return pgbSSDFree; }
    //  set { pgbSSDFree = value;
    //    pgbSSD.Value = value;
    //  }
    //}


    //public stanica(string hostName)
    public stanica(string hostName, string linka, int ssd, int cpu, int ram)
    {
      InitializeComponent();// generovane systemom
      //pgbCPU.SetState(2);
      HostName = hostName;
      CPU = cpu;
      SSD = ssd;
      RAM = ram;
      Linka = linka;
      //Name = hostName;
      //    pgbSSD.Maximum = 130;
      //    this.label1.Text = HostName;

      toolTip1.SetToolTip(pgbCPU, "Stanica :" + HostName + "\n" + "Linka :" + Linka + "\n" + "Ram :" + RAM + "\n" + "CPU :" + CPU + "\n" + "SSD :" + SSD);
    }

    private void toolTip1_Popup(object sender, PopupEventArgs e)
    {

    }
    private Point Poloha { get; set; }
    private void pgbCPU_MouseClick(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Right)
      {
        Poloha = e.Location;
        Poloha = new Point(Poloha.X / 10 * 10, Poloha.Y / 10 * 10);

        stanica st = (stanica)(((ProgressBar)sender).Parent);

        stanica ff = (stanica)(((ProgressBar)sender).Parent);
        Form3 fff = (Form3)(ff.Parent);

        

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
                  Where(l => l != (st.Linka+"->"+st.HostName+"-->"+st.Location.ToString())).ToList());
              }

            }
        }

      }
    }
    //private void stanica1_DragDrop(object sender, DragEventArgs e)
    //{
    //    ((stanica)e.Data.GetData(typeof(stanica))).Parent = (stanica)sender;
    //}

    //private void stanica1_DragEnter(object sender, DragEventArgs e)
    //{

    //    //if (e.Data.GetDataPresent(DataFormats.FileDrop))
    //        e.Effect = DragDropEffects.Move;
    //    //else
    //    //{
    //    //    String[] strGetFormats = e.Data.GetFormats();
    //    //    e.Effect = DragDropEffects.None;
    //    //}

    //}

    //private void stanica1_MouseDown(object sender, MouseEventArgs e)
    //{
    //    this.DoDragDrop(this, DragDropEffects.Move);
    //}
  }
}
