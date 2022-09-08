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
        string filename = @"Menù.txt";
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
            public bool Eliminato;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cibo Piatto;
            Piatto.Eliminato = true;
            Piatto.Ingredienti = new string[4];

            Piatto.Nome = "";
            Piatto.Prezzo = 0;
            Piatto.Portata = "";
            for (int i = 0; i < 4; i++)
                Piatto.Ingredienti[i] = "";

            bool tri = false;
            if (textBox1.Text != "")
            {
                bool control = false;
                using (StreamReader sr = new StreamReader(filename))
                {
                    string line = sr.ReadLine();
                    while (line != "+" && !control)
                    {
                        //MessageBox.Show($"'{line}'");
                        string[] carta = line.Split(';');
                        if (textBox1.Text.ToUpper() == carta[0])
                            control = true;
                        line = sr.ReadLine();
                    }
                }

                if (control)
                {
                    MessageBox.Show($"Il nome è già esistente");
                    textBox1.Text = "";
                    tri = true;
                }
                else
                    Piatto.Nome = textBox1.Text.ToUpper();

                for (int i = 0; i < textBox1.Text.Length; i++)
                    if (textBox1.Text.Substring(i, 1) == ";") tri = true;

            }
            else
            {
                tri = true;
                MessageBox.Show($"Nome non valido");
            }

            try
            {
                Piatto.Prezzo = double.Parse(textBox2.Text.Replace(".", ","));
            }
            catch
            {
                MessageBox.Show("Prezzo non valido");
                textBox2.Text = "";
                tri = true;
            }

            if (comboBox1.Text!=string.Empty)
                Piatto.Portata = comboBox1.Text;
            else
            {
                MessageBox.Show("Portata non valida");
                tri = true;
            }

            try
            { 
                Piatto.Ingredienti[0] = textBox4.Text;
                for (int i = 0; i < textBox4.Text.Length; i++)
                    if (textBox4.Text.Substring(i, 1) == ";") tri = true;

                Piatto.Ingredienti[1] = textBox5.Text;
                for (int i = 0; i < textBox5.Text.Length; i++)
                    if (textBox5.Text.Substring(i, 1) == ";") tri = true;

                Piatto.Ingredienti[2] = textBox6.Text;
                for (int i = 0; i < textBox6.Text.Length; i++)
                    if (textBox6.Text.Substring(i, 1) == ";") tri = true;

                Piatto.Ingredienti[3] = textBox7.Text;
                for (int i = 0; i < textBox7.Text.Length; i++)
                    if (textBox7.Text.Substring(i, 1) == ";") tri = true;
            }
            catch
            {
                MessageBox.Show("Ingredienti non validi");
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                tri = true;
            }

            if (!tri)
            {
                Aggiungi(Piatto, filename);
                MessageBox.Show("Aggiunta eseguita con successo");
            }
        }
        public static void Aggiungi(Cibo piattino, string filename)
        {
            var Q = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            Q.Close();
            StreamReader sr = new StreamReader(filename);
            StreamWriter sw = new StreamWriter(@"./Menù2.txt");

            string line = "";
            int i = 0;

            while (!sr.EndOfStream || i != 1)
            {
                line = sr.ReadLine();

                if (line != null && (line.Substring(0, 1) != "+" && i == 0))
                {
                    sw.WriteLine(line);
                }
                else
                {
                    sw.WriteLine($"{piattino.Nome.ToUpper()};{piattino.Prezzo};{piattino.Portata.ToUpper()};{piattino.Ingredienti[0].ToUpper()},{piattino.Ingredienti[1].ToUpper()},{piattino.Ingredienti[2].ToUpper()},{piattino.Ingredienti[3].ToUpper()};{piattino.Eliminato};"); 
                    sw.WriteLine("+");
                    i = 1;
                }
            }
            sr.Close();
            sw.Close();

            System.IO.File.Delete(filename);
            System.IO.File.Move(@"./Menù2.txt", filename);
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            comboBox1.Text = string.Empty;

            e.Cancel = true;
            this.Visible = false;
        }
    }
}
