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

namespace GestionaleRistorante.Mosconi
{
    public partial class Form5 : Form
    {
        public Form5()
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

        string filename = @"Menù.txt";

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Name = textBox1.Text;
            string line = "";

            StreamReader sr = new StreamReader(filename);

            line = sr.ReadLine();

            Cibo finale;
            finale.Nome = "controllo";
            finale.Prezzo = 0;
            finale.Portata = "";
            finale.Ingredienti = new string[4];
            finale.Ingredienti[0] = "";



            while (line!="+")
            {
                Cibo nome = Estrai(line);

                if (Name == nome.Nome)
                {
                    finale.Nome = nome.Nome;
                    finale.Prezzo = nome.Prezzo;
                    finale.Portata = nome.Portata;
                    for (int i = 0; i < nome.Ingredienti.Length; i++)
                        finale.Ingredienti[i] = nome.Ingredienti[i];
                }

                line = sr.ReadLine();
            }

            if (finale.Nome == "controllo")
                MessageBox.Show("Cibo non Trovato");
            else
                MessageBox.Show($"PORTATA: {finale.Portata}\nNOME: {finale.Nome}\nINGREDIENTI: {finale.Ingredienti[0]}, {finale.Ingredienti[1]}, {finale.Ingredienti[2]}, {finale.Ingredienti[3]}\nPREZZO: €{finale.Prezzo}");
        }

        public static Cibo Estrai(string line)
        {
            Cibo v;
            v.Ingredienti = new string[4];

            string[] campi = line.Split(';');

            v.Nome = campi[0];
            v.Prezzo = double.Parse(campi[1]);
            v.Portata = campi[2];
            v.Ingredienti[0] = campi[3];
            v.Ingredienti[1] = campi[4];
            v.Ingredienti[2] = campi[5];
            v.Ingredienti[3] = campi[6];

            return v;
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            textBox1.Text = "";

            e.Cancel = true;
            this.Visible = false;
        }
    }
}
