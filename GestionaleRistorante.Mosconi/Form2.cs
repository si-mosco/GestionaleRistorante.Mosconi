using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionaleRistorante.Mosconi
{
    public partial class Form2 : Form
    {
        Form4 Aggiunta = new Form4();
        Form5 Ricerca = new Form5();
        Form6 Modifica = new Form6();
        Form7 Visualizza = new Form7();
        Form8 Elimina = new Form8();
        Form9 Recupera = new Form9();

        bool chiusura = true;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(chiusura)
            Environment.Exit(1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Aggiunta.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Ricerca.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Modifica.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Visualizza.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Elimina.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Recupera.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            chiusura = false;
        }
    }
}
