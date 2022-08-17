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
    public partial class Form4 : Form
    {
        public Form4()
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

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cibo Piatto;
            Piatto.Ingredienti = new string[4];

            Piatto.Nome = "";
            Piatto.Prezzo = 0;
            Piatto.Portata = "";
            for (int i = 0; i < 4; i++)
                Piatto.Ingredienti[i] = "";

            try
            {
                Piatto.Nome = textBox1.Text;
            }
            catch
            {
                MessageBox.Show("Nome non valido");
                textBox1.Text = "";
            }

            try
            {
                Piatto.Prezzo = double.Parse(textBox2.Text);
            }
            catch
            {
                MessageBox.Show("Prezzo non valido");
                textBox2.Text = "";
            }

            if (textBox3.Text == "Antipasti" || textBox3.Text == "Primi" || textBox3.Text == "Secondi" || textBox3.Text == "Dessert")
                Piatto.Portata = textBox3.Text;
            else
            {
                MessageBox.Show("Portata non valida");
                textBox3.Text = "";
            }

            try
            {
                Piatto.Ingredienti[0] = textBox4.Text;
                Piatto.Ingredienti[1] = textBox5.Text;
                Piatto.Ingredienti[2] = textBox6.Text;
                Piatto.Ingredienti[3] = textBox7.Text;
            }
            catch
            {
                MessageBox.Show("Ingredienti non validi");
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
            }

            Aggiungi(Piatto);

            MessageBox.Show("Aggiunta eseguita con successo");
        }
        public static void Aggiungi(Cibo piattino)
        {
            StreamReader sr = new StreamReader((@"./Menù.txt"));
            StreamWriter sw = new StreamWriter(@"./Menù2.txt");

            string line = "";
            int i = 0;

            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();

                if (line.Substring(0, 1) != " " && i == 0)
                {
                    sw.WriteLine(line);
                }
                else
                {
                    sw.WriteLine($"|{piattino.Nome}|,{piattino.Prezzo},_{piattino.Portata}_#{piattino.Ingredienti[0]}#@{piattino.Ingredienti[1]}@°{piattino.Ingredienti[2]}°^{piattino.Ingredienti[3]}^");
                    sw.WriteLine("+");
                    i = 1;
                }
            }
            sr.Close();
            sw.Close();

            System.IO.File.Delete(@"./Menù.txt");
            System.IO.File.Move(@"./Menù2.txt", @"./Menù.txt");
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
        }
    }
}
