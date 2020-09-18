using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monitoring
{
  public partial class Form1 : Form
  {

    private int vyska = 150;
    private int sirka = 95;

    //private List<string> staniceL1 = new List<string>() { "EXT1SKMH6000363", "EXT1SKMH6000347", "EXT1SKMH6000381" };
    //private List<Point> pozicieL1 = new List<Point>() { new Point(10, 20), new Point(120, 20), new Point(230, 20), new Point(340, 20) };


    private List<string> staniceL1 = new List<string>(); 
    private List<string> staniceL2 = new List<string>();
    private List<string> staniceL3 = new List<string>();
    private List<int> ssdFree = new List<int>();

    private List<int> cpu = new List<int>();
    private List<int> memory = new List<int>();

    private List<Point> pozicieL1 = new List<Point>();
    private List<Point> pozicieL2 = new List<Point>();
    private List<Point> pozicieL3 = new List<Point>();

    private List<string> skupina1 = new List<string>() { "EXT1SKMH6000363", "EXT1SKMH6000381", "EXT1SKMH6000322" };
    private List<string> skupina2 = new List<string>() { "EXT1SKMH6000347", "EXT1SKMH6000331" };
    private List<string> skupina3 = new List<string>();


    //private List<string> staniceL2 = new List<string>() { "HostName 1", "HostName 2" };
    //private List<Point> pozicieL2 = new List<Point>() { new Point(10, 180), new Point(120, 180) };

    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {

      //NacitajHodnoty();
      //DoplnStanice();
      //UpravHodnoty();
    }

    private void NacitajHodnoty()
    {
            string[] lines = System.IO.File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "RAM\\SSD.txt"));

            //@"C:\Users\JuloJenis\source\repos\Monitoring\Desktop\); ; ;

      staniceL1.Clear();
      ssdFree.Clear();

      int poradie = 0;
      foreach (string line in lines)
      {
        if (line.Length > 2)
          if (line.Substring(0, 3) == "EXT")
          {
            if (skupina1.Contains(line.Substring(0, 15)))
            {
              staniceL1.Add(line.Substring(0, 15)); //loading hostname
              ssdFree.Add(Convert.ToInt32(line.Substring(18, line.Length - 18)));
              pozicieL1.Add(new Point(10 + 110 * poradie, 20));
              poradie += 1;
            }
          }
      }


      poradie = 0;
      foreach (string line in lines)
      {
        if (line.Length > 2)
          if (line.Substring(0, 3) == "EXT")
          {
            if (skupina2.Contains(line.Substring(0, 15)))
            {
              staniceL2.Add(line.Substring(0, 15)); //loading hostname
              ssdFree.Add(Convert.ToInt32(line.Substring(18, line.Length - 18)));
              pozicieL2.Add(new Point(10 + 110 * poradie, 200));
              poradie += 1;
            }
          }
      }

      poradie = 0;
      foreach (string line in lines)
      {
        if (line.Length > 2)
          if (line.Substring(0, 3) == "EXT")
          {
            if (!(skupina2.Contains(line.Substring(0, 15))) && !(skupina1.Contains(line.Substring(0, 15))))
            {
              staniceL2.Add(line.Substring(0, 15)); //loading hostname
              ssdFree.Add(Convert.ToInt32(line.Substring(18, line.Length - 18)));
              pozicieL2.Add(new Point(10 + 110 * poradie, 400));
              poradie += 1;
            }
          }
      }

    }

    private void DoplnStanice()
    {
      //for (int i = 0; i < staniceL1.Count; i++)
      //{
      //  var uc = new stanica(staniceL1[i]);
      //  uc.Location = pozicieL1[i]; // Location = 0,0 lavz hornz roh
      //  uc.Name = staniceL1[i];
      //  uc.Width = sirka;
      //  uc.Height = vyska;
      //  this.Controls.Add(uc); // prida to na hlavne okno
      //}

      //for (int i = 0; i < staniceL2.Count; i++)
      //{
      //  var uc = new stanica(staniceL2[i]);
      //  uc.Location = pozicieL2[i]; // Location = 0,0 lavz hornz roh
      //  uc.Name = staniceL2[i];
      //  uc.Width = sirka;
      //  uc.Height = vyska;
      //  this.Controls.Add(uc); // prida to na hlavne okno
      //}

      //for (int i = 0; i < staniceL3.Count; i++)
      //{
      //  var uc = new stanica(staniceL3[i]);
      //  uc.Location = pozicieL3[i]; // Location = 0,0 lavz hornz roh
      //  uc.Name = staniceL3[i];
      //  uc.Width = sirka;
      //  uc.Height = vyska;
      //  this.Controls.Add(uc); // prida to na hlavne okno
      //}


    }

    private void button1_Click(object sender, EventArgs e)
    {

            //NacitajHodnoty();
            //UpravHodnoty();



    }

    private void UpravHodnoty()
    {
      for (int i = 0; i < staniceL1.Count; i++)
      {
        //((stanica)(Controls[staniceL1[i]])).PgbSSDFree = ssdFree[i];
      }
    }
  }
}
