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

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Name = textBox1.Text;
            string line = "";

            StreamReader sr = new StreamReader((@"./Menù.txt"));

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
                    finale = nome;
                }

                line = sr.ReadLine();
            }

            if (finale.Nome == "controllo")
                MessageBox.Show("Cibo non Trovato");
            else
                MessageBox.Show($"{finale.Portata} - {finale.Nome} ({finale.Ingredienti[0]}, {finale.Ingredienti[1]}, {finale.Ingredienti[2]}, {finale.Ingredienti[3]}) - {finale.Prezzo} €");
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
            v.Portata = line.Substring(fineCaratteri[1] + 2, (fineCaratteri[2] - 1) - (fineCaratteri[1] + 2)+1);
            v.Ingredienti[0] = line.Substring(fineCaratteri[2] + 2, (fineCaratteri[3] - 1) - (fineCaratteri[2] + 2)+1);
            v.Ingredienti[1] = line.Substring(fineCaratteri[3] + 2, (fineCaratteri[4] - 1) - (fineCaratteri[3] + 2)+1);
            v.Ingredienti[2] = line.Substring(fineCaratteri[4] + 2, (fineCaratteri[5] - 1) - (fineCaratteri[4] + 2)+1);
            v.Ingredienti[3] = line.Substring(fineCaratteri[5] + 2, (line.Length - 1) - (fineCaratteri[5] + 2));
            return v;
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
        }
    }
}
