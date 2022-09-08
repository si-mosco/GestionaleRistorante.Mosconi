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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        void Cliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Visible = true;
            textBox1.Text = "";
            textBox2.Text = "";
        }

        void Proprietario_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Visible = true;
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form2 Proprietario = new Form2();
            Form3 Cliente = new Form3();
            Proprietario.FormClosed += new FormClosedEventHandler(Proprietario_FormClosed);
            Cliente.FormClosed += new FormClosedEventHandler(Cliente_FormClosed);

            if (textBox1.Text == "Cliente" && textBox2.Text == "Cliente")
            {
                Cliente.Show();
                this.Hide();
            }
            else if (textBox1.Text == "Proprietario" && textBox2.Text == "Proprietario")
            {
                Proprietario.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Valori inseriti Errati");
                textBox1.Text = "";
                textBox2.Text = "";
            }
            this.Hide();
        }
    }
}
