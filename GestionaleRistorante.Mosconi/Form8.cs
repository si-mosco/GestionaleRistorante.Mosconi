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
    public partial class Form8 : Form
    {
        public struct Cibo
        {
            public string Nome;
            public double Prezzo;
            public string[] Ingredienti;
            public string Portata;
            public bool Eliminato;
        }
        public Form8()
        {
            InitializeComponent();
        }

        string filename = @"Menù.txt";

        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private void Form8_FormClosing(object sender, FormClosingEventArgs e)
        {
            textBox1.Text = "";

            e.Cancel = true;
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Name = textBox1.Text.ToUpper();
            string line = "";

            StreamReader sr = new StreamReader(filename);
            StreamWriter sw = new StreamWriter(@"Menù2.txt");

            line = sr.ReadLine();

            Cibo finale;
            finale.Nome = "controllo";
            finale.Prezzo = 0;
            finale.Portata = "";
            finale.Ingredienti = new string[4];
            finale.Ingredienti[0] = "";



            while (line != "+")
            {
                //MessageBox.Show($"'{line}'");
                Cibo nome = Estrai(line);

                if (Name == nome.Nome && nome.Eliminato)
                {
                    finale.Nome = nome.Nome;
                    finale.Prezzo = nome.Prezzo;
                    finale.Portata = nome.Portata;
                    for (int i = 0; i < nome.Ingredienti.Length; i++)
                        finale.Ingredienti[i] = nome.Ingredienti[i];
                    finale.Eliminato = false;

                    sw.WriteLine($"{finale.Nome.ToUpper()};{finale.Prezzo};{finale.Portata.ToUpper()};{finale.Ingredienti[0].ToUpper()},{finale.Ingredienti[1].ToUpper()},{finale.Ingredienti[2].ToUpper()},{finale.Ingredienti[3].ToUpper()};{finale.Eliminato};");
                }
                else
                    sw.WriteLine(line);

                line = sr.ReadLine();
            }

            sw.WriteLine("+");

            sw.Close();
            sr.Close();

            if (finale.Nome == "controllo")
            {
                MessageBox.Show("Cibo non Trovato");
                System.IO.File.Delete(@"Menù2.txt");
            }
            else
            {
                MessageBox.Show("Cibo eliminato con successo");
                System.IO.File.Delete(filename);
                System.IO.File.Move(@"./Menù2.txt", filename);
            }
        }

        public static Cibo Estrai(string line)
        {
            Cibo v;
            v.Ingredienti = new string[4];

            string[] campi = line.Split(';');

            v.Nome = campi[0];
            v.Prezzo = double.Parse(campi[1]);
            v.Portata = campi[2];
            string[] ing = campi[3].Split(',');

            for (int i = 0; i < ing.Length; i++)
                v.Ingredienti[i] = ing[i];

            v.Eliminato = bool.Parse(campi[4]);

            return v;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string line = "";

            StreamReader sr = new StreamReader(filename);
            StreamWriter sw = new StreamWriter(@"Menù2.txt");

            line = sr.ReadLine();

            while (line != "+")
            {
                //MessageBox.Show($"'{line}'");
                Cibo nome = Estrai(line);

                if (nome.Eliminato)
                {
                    sw.WriteLine(line);
                }

                line = sr.ReadLine();
            }

            sw.WriteLine("+");

            sw.Close();
            sr.Close();


            MessageBox.Show("File ricompattao con successo");
            System.IO.File.Delete(filename);
            System.IO.File.Move(@"./Menù2.txt", filename);
        }
    }
}
