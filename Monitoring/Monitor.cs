﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monitoring
{
    public partial class Monitor : Form
    {

        string[] StavRAM;
        string[] StavSSD;
        Dictionary<string, float> StaniceSSD;
        Dictionary<string, float> StaniceRAM;

        List<string> lines = new List<string>();
        public Monitor()
        {
            InitializeComponent();
        }

        private void Monitor_Load(object sender, EventArgs e)
        {
            NaplnZoznamy();
            NacitajZvolene();
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

                        stanica sta = new stanica(stanica, linka.Substring(0, linka.Length - 4), 0, 0, 0, false);
                        sta.Location = umiestnenie;
                        sta.Size = new Size(Aplikacia.VelkostStanice, Aplikacia.VelkostStanice);
                        this.Controls.Add(sta);


                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NacitajZvolene();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            NacitajZvolene();
        }

        private void NacitajZvolene()
        {

            if (rbAll.Checked)
            {
                NacitajVsetky();
            }
            else if (rbCPU.Checked)
            {
                NacitajCPU();
            }
            else if (rbRAM.Checked)
            {
                NacitajRamky();
            }
            else if (rbSSD.Checked)
            {
                NacitajSSD();
            }
            else { }
        }

        private void NacitajVsetky()
        {
            NacitajCPU();
            NacitajRamky();
            NacitajSSD();
            rbSSD.Checked = true;
            string meno;

            float mSSD=-1;
            float mRAM=-1;
            int percentoSSD;
            int percentoRAM;

            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i] is stanica)
                {
                    try
                    {
                        mSSD = -1;
                        mRAM = -1;
                        meno = ((stanica)this.Controls[i]).HostName;
                        mSSD =StaniceSSD[meno];
                        mRAM = StaniceRAM[meno];
                        percentoSSD = (int)Math.Round((Aplikacia.ssdSize - mSSD) / Aplikacia.ssdSize * 100, 0);
                        percentoRAM = (int)Math.Round((Aplikacia.ramSize - mRAM) / Aplikacia.ramSize * 100, 0);

                        if (percentoRAM <= percentoSSD)
                        {
                            ((stanica)this.Controls[i]).SledovanaVlastnost = "RAM";
                            ((stanica)this.Controls[i]).RAM = mRAM;
                        }
                        else 
                        {
                            ((stanica)this.Controls[i]).SledovanaVlastnost = "SSD";
                            ((stanica)this.Controls[i]).SSD = mSSD;
                        }

                    }
                    catch (Exception)
                    {
                        if (mSSD == -1)
                        {
                            ((stanica)this.Controls[i]).SledovanaVlastnost = "SSD";
                            ((stanica)this.Controls[i]).SSD = 0;
                        }
                        else if (mRAM == -1)
                        {
                            ((stanica)this.Controls[i]).SledovanaVlastnost = "RAM";
                            ((stanica)this.Controls[i]).RAM = 0;
                        }
                    }
                }
            }
        }



        private void NacitajCPU()
        {

        }

        private void NacitajSSD()
        {
            StavSSD = System.IO.File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "RAM", "SSD.txt"));
            StaniceSSD = new Dictionary<string, float>();
            foreach (var info in StavSSD)
            {
                if (info != "")
                {
                    string stan = info.Substring(0, info.IndexOf(" "));
                    float velkost = float.Parse(info.Substring(info.IndexOf(" ") + 3));
                    StaniceSSD.Add(stan, ((float)velkost));
                }
            }
            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i] is stanica)
                {
                    try
                    {
                        ((stanica)this.Controls[i]).SledovanaVlastnost = "SSD";
                        ((stanica)this.Controls[i]).SSD = StaniceSSD[((stanica)this.Controls[i]).HostName];
                    }
                    catch (Exception)
                    {
                        ((stanica)this.Controls[i]).SledovanaVlastnost = "SSDA";
                        ((stanica)this.Controls[i]).SSD = 0;
                    }
                }
            }
        }

        private void NacitajRamky()
        {
            StavRAM = System.IO.File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "RAM", "RAM.txt"));
            StaniceRAM = new Dictionary<string, float>();
            foreach (var info in StavRAM)
            {
                if (info != "")
                {
                    string stan = info.Substring(0, info.IndexOf(" "));
                    float velkost;

                    var numberString = info.Substring(info.IndexOf(" ") + 2);

                    var cultureInfo = CultureInfo.InvariantCulture;
                    if (Regex.IsMatch(numberString, @"^(:?[\d,]+\.)*\d+$"))
                    {
                        cultureInfo = new CultureInfo("en-US");
                    }
                    else if (Regex.IsMatch(numberString, @"^(:?[\d.]+,)*\d+$"))
                    {
                        cultureInfo = new CultureInfo("sk-SK");
                    }
                    NumberStyles styles = NumberStyles.Number;
                    bool isFloat = float.TryParse(numberString, styles, cultureInfo, out velkost);
                    StaniceRAM.Add(stan, ((float)velkost));
                }
            }
            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i] is stanica)
                {
                    try
                    {
                        ((stanica)this.Controls[i]).SledovanaVlastnost = "RAM";
                        ((stanica)this.Controls[i]).RAM = StaniceRAM[((stanica)this.Controls[i]).HostName];
                    }
                    catch (Exception)
                    {
                        ((stanica)this.Controls[i]).SledovanaVlastnost = "RAMA";
                        ((stanica)this.Controls[i]).RAM = 0;
                    }
                }
            }
        }

        private void ZmenaRB(object sender, EventArgs e)
        {
            NacitajZvolene();
        }
    }
}
