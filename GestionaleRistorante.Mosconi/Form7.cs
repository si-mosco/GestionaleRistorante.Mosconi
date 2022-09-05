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
        }

        public struct Cibo
        {
            public string Nome;
            public double Prezzo;
            public string[] Ingredienti;
            public string Portata;
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;

            listView1.Columns.Add("Nome");
            listView1.Columns.Add("Prezzo");
            listView1.Columns.Add("Portata");
            listView1.Columns.Add("Ingredienti");


        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader((@"./Menù.txt"));
            string line = sr.ReadLine();

            string[] cose = line.Split(';');
            string[] items2 = new string[cose.Length - 1];
            for (int i = 0; i < items2.Length; i++)
                items2[i] = cose[i];

            ListViewItem item = new ListViewItem(items2);
            listView1.Items.Add(item);
            /*
            string line = "";

            StreamReader sr = new StreamReader((@"./Menù.txt"));

            line = sr.ReadLine();
            while (line!="+")
            {
                if (line.Substring(0, 1) != "§")
                {
                    //Cibo finale = Estrai(line);
                    //MessageBox.Show($"PORTATA: {finale.Portata}\nNOME: {finale.Nome}\nINGREDIENTI: {finale.Ingredienti[0]}, {finale.Ingredienti[1]}, {finale.Ingredienti[2]}, {finale.Ingredienti[3]}\nPREZZO: €{finale.Prezzo}");
                }
                line = sr.ReadLine();
            }
            MessageBox.Show("Fine");*/
        }
        public static void Estrai(string line, string[] items)
        {
            items = line.Split(';');
        }

        private void Form7_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
        }
    }
}
