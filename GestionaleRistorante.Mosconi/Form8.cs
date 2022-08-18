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
        }
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private void Form8_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ricerca
            string Name = textBox1.Text;
            string line = "";

            StreamReader sr = new StreamReader((@"./Menù.txt"));
            StreamWriter sw = new StreamWriter(@"./Menù2.txt");

            line = sr.ReadLine();

            while (line != "+")
            {
                Cibo nome = Estrai(line);

                if (Name == nome.Nome)
                {
                    sw.WriteLine($"§|{nome.Nome}|,{nome.Prezzo},_{nome.Portata}_#{nome.Ingredienti[0]}#@{nome.Ingredienti[1]}@°{nome.Ingredienti[2]}°^{nome.Ingredienti[3]}^");
                }
                else
                    sw.WriteLine(line);
            }
            sw.WriteLine("+");

            sr.Close();
            sw.Close();

            System.IO.File.Delete(@"./Menù.txt");
            System.IO.File.Move(@"./Menù2.txt", @"./Menù.txt");
        }

        public static Cibo Estrai(string line)
        {
            Cibo v;
            v.Ingredienti = new string[4];

            string[] caratteri = new string[7] { "|", ",", "_", "#", "@", "°", "^" };
            int[] fineCaratteri = new int[7];
            for (int j = 0; j < 7; j++)
            {
                for (int i = 1; i < line.Length; i++)
                {
                    if (line.Substring(i, 1) == caratteri[j])
                    {
                        fineCaratteri[j] = i;
                    }
                }
            }

            v.Nome = line.Substring(1, fineCaratteri[0] - 1);
            v.Prezzo = double.Parse(line.Substring(fineCaratteri[0] + 2, (fineCaratteri[1]) - (fineCaratteri[0] + 2)));
            v.Portata = line.Substring(fineCaratteri[1] + 2, (fineCaratteri[2] - 1) - (fineCaratteri[1] + 2) + 1);
            v.Ingredienti[0] = line.Substring(fineCaratteri[2] + 2, (fineCaratteri[3] - 1) - (fineCaratteri[2] + 2) + 1);
            v.Ingredienti[1] = line.Substring(fineCaratteri[3] + 2, (fineCaratteri[4] - 1) - (fineCaratteri[3] + 2) + 1);
            v.Ingredienti[2] = line.Substring(fineCaratteri[4] + 2, (fineCaratteri[5] - 1) - (fineCaratteri[4] + 2) + 1);
            v.Ingredienti[3] = line.Substring(fineCaratteri[5] + 2, (line.Length - 1) - (fineCaratteri[5] + 2));
            return v;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader((@"./Menù.txt"));
            StreamWriter sw = new StreamWriter(@"./Menù2.txt");

            string line = sr.ReadLine();
            while (line != "+")
            {
                if (line.Substring(0,1)!="§")
                    sw.WriteLine(line);
            }
            sw.WriteLine("+");

            sr.Close();
            sw.Close();

            System.IO.File.Delete(@"./Menù.txt");
            System.IO.File.Move(@"./Menù2.txt", @"./Menù.txt");
        }
    }
}
