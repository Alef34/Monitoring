using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monitoring
{
  public partial class Form4 : Form
  {
    public string HostName { get; set; }

    public List<string> Polozky { get; set; }

    public Form4(Point poloha)
    {
      InitializeComponent();
      HostName = "";
    }

    private void toolStripButton1_Click(object sender, EventArgs e)
    {
      HostName = "";
      this.Close();
    }

    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void listBox1_DoubleClick(object sender, EventArgs e)
    {
      HostName = listBox1.SelectedItem.ToString();
      this.Close();
    }

    private void Form4_Load(object sender, EventArgs e)
    {
      foreach (string riadok in Polozky)
      {
        listBox1.Items.Add(riadok);
      }
    }
  }
}
