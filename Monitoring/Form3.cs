using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monitoring
{


    public partial class Form3 : Form
    {

        private Point Poloha { get; set; }
        private int velkostStanice = 25;

        List<string> lines = new List<string>();

        public Form3()
        {
            InitializeComponent();

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }



        private void Form3_Paint(object sender, PaintEventArgs e)
        {
            Graphics l = e.Graphics;
            Pen p = new Pen(Color.Gray, 1);

            p.Width = 1;

            for (int i = 0; i < this.Width; i = i + 10)
            {
                l.DrawLine(new Pen(Color.Gray, 1) { DashPattern = new float[] { 1, 1 } }, i, 0, i, this.Height);
            }

            for (int i = 0; i < this.Width; i = i + 10)
            {
                l.DrawLine(new Pen(Color.Gray, 1) { DashPattern = new float[] { 1, 1 } }, 0, i, this.Width, i);
            }

            // l.Dispose();
        }

        private void Form3_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Poloha = e.Location;
                Poloha = new Point(Poloha.X / 10 * 10, Poloha.Y / 10 * 10);

                //this.ContextMenuStrip = contextMenuStrip1;
                //contextMenuStrip1.Show(e.Location);
                NaplnZoznamy();
                VlozStanicu(Poloha);


            }


        }

        private void VlozStanicu(Point poloha)
        {
            Form4 frm = new Form4(poloha);
            //ControlExtension.Draggable(frm, true);
            frm.Polozky = lines;
            frm.Location = poloha;
            frm.ShowDialog();
            if (frm.HostName != "")
            {
                string meno = frm.HostName.Substring(frm.HostName.IndexOf("->") + 2);
                string linka = frm.HostName.Substring(0, frm.HostName.IndexOf("->"));
                stanica sta = new stanica(meno, linka, 10, 0, 0);
                sta.Location = poloha;
                sta.Size = new Size(velkostStanice, velkostStanice);
                this.Controls.Add(sta);

                using (System.IO.StreamWriter file =
                  new System.IO.StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), "Ulozene", "suradnice.txt"), true))
                {
                    file.WriteLine(frm.HostName + "-->" + poloha.ToString());
                }

            }
        }

        private void contextMenuStrip1_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {

        }

        private void contextMenuStrip1_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            this.ContextMenuStrip = null;
        }




        private void Form3_Load(object sender, EventArgs e)
        {

            NaplnZoznamy();

        }

        private void NaplnZoznamy()
        {
            string[] nazvyLiniek = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "HostName")).GetFiles("*.txt").Select(o => o.Name).ToArray();
            string[] UlozeneStanice = System.IO.File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "Ulozene", "suradnice.txt"));
            Dictionary<string, Point> UlozeneSuradnice = new Dictionary<string, Point>();
            foreach (var info in UlozeneStanice)
            {

                string iii = info.Substring(info.IndexOf("-->") + 3);


                var myStringWhichCantBeChanged = iii;
                var g = Regex.Replace(myStringWhichCantBeChanged, @"[\{\}a-zA-Z=]", "").Split(',');

                Point pointResult = new Point(
                                  int.Parse(g[0]),
                                  int.Parse(g[1]));


                UlozeneSuradnice.Add(info.Substring(0, info.IndexOf("-->")), pointResult);

            }
            lines = new List<string>();
            foreach (string linka in nazvyLiniek)
            {

                foreach (string stanica in System.IO.File.ReadLines(Path.Combine(Directory.GetCurrentDirectory(), "HostName", linka)))
                {
                    if (!UlozeneStanice.Select(o => o.Substring(0, o.IndexOf("-->"))).Contains<string>(linka.Substring(0, linka.Length - 4) + "->" + stanica))
                    {
                        lines.Add(linka.Substring(0, linka.Length - 4) + "->" + stanica);
                    }
                    else
                    {

                        Point umiestnenie = UlozeneSuradnice[linka.Substring(0, linka.Length - 4) + "->" + stanica];
                        Form4 frm = new Form4(umiestnenie);
                        //ControlExtension.Draggable(frm, true);

                        stanica sta = new stanica(stanica, linka.Substring(0, linka.Length - 4), 0, 0, 0);
                        sta.Location = umiestnenie;
                        sta.Size = new Size(velkostStanice, velkostStanice);
                        this.Controls.Add(sta);


                    }
                }
            }
        }
    }
}
