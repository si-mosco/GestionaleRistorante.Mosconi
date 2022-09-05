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
        Form2 Proprietario = new Form2();
        Form3 Cliente = new Form3();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "Cliente" && textBox2.Text == "Cliente")
            {
                Cliente.Show();
                this.Visible = false;
            }
            else if (textBox1.Text == "Proprietario" && textBox2.Text == "Proprietario")
            {
                Proprietario.Show();
                this.Visible=false;
            }
            else
            {
                MessageBox.Show("Valori inseriti Errati");
                textBox1.Text = "";
                textBox2.Text = "";
            }
            this.Hide();
            Proprietario.Show();
        }
    }
}
