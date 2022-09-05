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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        string filename = @"Menù.txt";
        bool controllino = false;

        public struct Cibo
        {
            public string Nome;
            public double Prezzo;
            public string[] Ingredienti;
            public string Portata;
            public bool Eliminato;
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            for (int i=0; i<checkedListBox1.Items.Count; i++)
                checkedListBox1.SetItemChecked(i, false);

            e.Cancel = true;
            this.Visible = false;
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        { 
            if (textBox1.Text=="" || textBox2.Text==""|| checkedListBox1.CheckedItems.Count == 0)
            {
                MessageBox.Show("Valori non Validi");
            }
            else
            {
                //ricerca
                string Name = textBox1.Text.ToUpper();
                string line = "";

                StreamReader sr = new StreamReader(filename);
                StreamWriter sw = new StreamWriter(@"./Menù2.txt");

                line = sr.ReadLine();

                while (line != "+")
                {
                    Cibo piattino = Estrai(line);
                    piattino.Eliminato = true;

                    if (Name == piattino.Nome)
                    {
                        if (checkedListBox1.GetItemChecked(0) == true)
                        {
                            try
                            {
                                double nuovo = double.Parse(textBox2.Text);
                                piattino.Prezzo = nuovo;
                                sw.WriteLine($"{piattino.Nome.ToUpper()};{piattino.Prezzo};{piattino.Portata.ToUpper()};{piattino.Ingredienti[0].ToUpper()},{piattino.Ingredienti[1].ToUpper()},{piattino.Ingredienti[2].ToUpper()},{piattino.Ingredienti[3].ToUpper()};{piattino.Eliminato};");
                            }
                            catch
                            {
                                controllino = true;
                                MessageBox.Show("Prezzo non valido");
                                textBox2.Text = "";
                            }
                        }
                        else if(checkedListBox1.GetItemChecked(1) == true)
                        {
                            if (textBox2.Text.ToUpper() == "ANTIPASTO" || textBox2.Text.ToUpper() == "PRIMO" || textBox2.Text.ToUpper() == "SECONDO" || textBox2.Text.ToUpper() == "DESSERT")
                            {
                                piattino.Portata = textBox2.Text.ToUpper();
                                sw.WriteLine($"{piattino.Nome.ToUpper()};{piattino.Prezzo};{piattino.Portata.ToUpper()};{piattino.Ingredienti[0].ToUpper()},{piattino.Ingredienti[1].ToUpper()},{piattino.Ingredienti[2].ToUpper()},{piattino.Ingredienti[3].ToUpper()};{piattino.Eliminato};");
                            }
                            else
                            {
                                controllino = true;
                                MessageBox.Show("Portata non valida");
                                textBox2.Text = "";
                            }
                        }
                        else if(checkedListBox1.GetItemChecked(2) == true)
                        {
                            MessageBox.Show("ingrediente 0");
                            piattino.Ingredienti[0] = textBox2.Text.ToUpper();
                            sw.WriteLine($"{piattino.Nome.ToUpper()};{piattino.Prezzo};{piattino.Portata.ToUpper()};{piattino.Ingredienti[0].ToUpper()},{piattino.Ingredienti[1].ToUpper()},{piattino.Ingredienti[2].ToUpper()},{piattino.Ingredienti[3].ToUpper()};{piattino.Eliminato};");
                        }
                        else if (checkedListBox1.GetItemChecked(3) == true)
                        {
                            MessageBox.Show("ingrediente 1");
                            piattino.Ingredienti[1] = textBox2.Text.ToUpper();
                            sw.WriteLine($"{piattino.Nome.ToUpper()};{piattino.Prezzo};{piattino.Portata.ToUpper()};{piattino.Ingredienti[0].ToUpper()},{piattino.Ingredienti[1].ToUpper()},{piattino.Ingredienti[2].ToUpper()},{piattino.Ingredienti[3].ToUpper()};{piattino.Eliminato};");
                        }
                        else if (checkedListBox1.GetItemChecked(4) == true)
                        {
                            MessageBox.Show("ingrediente 2");
                            piattino.Ingredienti[2] = textBox2.Text.ToUpper();
                            sw.WriteLine($"{piattino.Nome.ToUpper()};{piattino.Prezzo};{piattino.Portata.ToUpper()};{piattino.Ingredienti[0].ToUpper()},{piattino.Ingredienti[1].ToUpper()},{piattino.Ingredienti[2].ToUpper()},{piattino.Ingredienti[3].ToUpper()};{piattino.Eliminato};");
                        }
                        else if (checkedListBox1.GetItemChecked(5) == true)
                        {
                            MessageBox.Show("ingrediente 3");
                            piattino.Ingredienti[3] = textBox2.Text.ToUpper();
                            sw.WriteLine($"{piattino.Nome.ToUpper()};{piattino.Prezzo};{piattino.Portata.ToUpper()};{piattino.Ingredienti[0].ToUpper()},{piattino.Ingredienti[1].ToUpper()},{piattino.Ingredienti[2].ToUpper()},{piattino.Ingredienti[3].ToUpper()};{piattino.Eliminato};");
                        }
                    }
                    if (Name != piattino.Nome||controllino)
                        sw.WriteLine(line);
                    controllino = false;

                    line = sr.ReadLine();
                }
                MessageBox.Show("uscito");
                sw.WriteLine("+");

                sr.Close();
                sw.Close();

                System.IO.File.Delete(filename);
                System.IO.File.Move(@"./Menù2.txt", filename);
            }
        }

        public static Cibo Estrai(string line)
        {
            Cibo v;
            v.Eliminato = true;
            v.Ingredienti = new string[4];

            string[] campi = line.Split(';');

            v.Nome = campi[0];
            v.Prezzo = double.Parse(campi[1]);
            v.Portata = campi[2];

            string[] ing = campi[3].Split(',');
            for (int i = 0; i < ing.Length; i++)
                v.Ingredienti[i] = ing[i];

            return v;
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < checkedListBox1.Items.Count; ix++)
                if (ix != e.Index) checkedListBox1.SetItemChecked(ix, false);
        }
    }
}
