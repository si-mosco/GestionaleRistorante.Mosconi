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

namespace GestionaleRistorante.Mosconi
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

            listView1.Columns.Add("Nome", 75);
            listView1.Columns.Add("Prezzo", 60);
            listView1.Columns.Add("Portata", 75);
            listView1.Columns.Add("Ingredienti", 270);

            listView2.Columns.Add("Nome", 150);
            listView2.Columns.Add("Prezzo", 60);
        }

        double prezzofin = 0;
        string filename = @"Menù.txt";
        public struct Cibo
        {
            public string Nome;
            public double Prezzo;
            public string[] Ingredienti;
            public string Portata;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView1.View = View.Details;
            listView1.FullRowSelect = true;

            listView2.Items.Clear();
            listView2.View = View.Details;
            listView2.FullRowSelect = true;

            textBox1.Text = $"{prezzofin}";

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

            Ordina(listView1);
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(1);
        }

        private void Form3_Activated(object sender, EventArgs e)
        {
            Form3_Load(sender, e);
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string[] valori = new string[] { listView1.SelectedItems[0].SubItems[0].Text, listView1.SelectedItems[0].SubItems[1].Text };

                ListViewItem item = new ListViewItem(valori);
                listView2.Items.Add(item);

                textBox1.Text = $"{double.Parse(textBox1.Text) + double.Parse(listView1.SelectedItems[0].SubItems[1].Text)}";
            }
        }

        public static int Convertiportata(string portata)
        {
            if (portata == "ANTIPASTO")
                return 0;
            else if (portata == "PRIMO")
                return 1;
            else if (portata == "SECONDO")
                return 2;
            else if (portata == "DESSERT")
                return 3;

            return -1;
        }

        public static void Ordina (ListView order)
        {
            for (int i=0; i<order.Items.Count; i++)
            {
                for (int j =i; j<order.Items.Count; j++)
                {
                    if (Convertiportata(order.Items[i].SubItems[2].Text)> Convertiportata(order.Items[j].SubItems[2].Text))
                    {
                        ScambiaElementi(i, j, order);
                    }
                }
            }
        }

        public static void ScambiaElementi(int ind1, int ind2, ListView listuccia)
        {
            string[] backup = new string[] { " ", " ", " ", " " };
            string[] backup1 = new string[] { " ", " ", " ", " " };

            for (int i = 0; i < listuccia.Items[ind1].SubItems.Count - 1; i++)
                backup[i] = listuccia.Items[ind1].SubItems[i].Text;

            for (int i = 0; i < listuccia.Items[ind2].SubItems.Count - 1; i++)
                backup1[i] = listuccia.Items[ind2].SubItems[i].Text;


            for (int i = 0; i < listuccia.Items[ind2].SubItems.Count - 1; i++)
                listuccia.Items[ind2].SubItems[i].Text = backup[i];

            for (int i = 0; i < listuccia.Items[ind1].SubItems.Count - 1; i++)
                listuccia.Items[ind1].SubItems[i].Text = backup1[i];
        }
    }
}
