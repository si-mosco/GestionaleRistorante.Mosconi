using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Net.WebRequestMethods;

namespace GestionaleRistorante.Mosconi
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();

            listView1.Columns.Add("Nome", 75);
            listView1.Columns.Add("Prezzo", 60);
            listView1.Columns.Add("Portata", 75);
            listView1.Columns.Add("Ingredienti", 270);
        }
        string filename = @"Menù.txt";
        public struct Cibo
        {
            public string Nome;
            public double Prezzo;
            public string[] Ingredienti;
            public string Portata;
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView1.View = View.Details;
            listView1.FullRowSelect = true;

            using (StreamReader sr = new StreamReader(filename))
            {
                string line = sr.ReadLine();

                while (line != "+")
                {
                    string[] cose = line.Split(';');
                    string[] items2 = new string[cose.Length - 1];
                    for (int i = 0; i < items2.Length; i++)
                        items2[i] = cose[i];

                    ListViewItem item = new ListViewItem(items2);
                    listView1.Items.Add(item);

                    line = sr.ReadLine();
                }
            }
        }

        private void Form7_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }

        private void Form7_Activated(object sender, EventArgs e)
        {
            Form7_Load(sender, e);
        }
    }
}
