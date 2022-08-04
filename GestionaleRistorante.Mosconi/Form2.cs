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
        Form4 Cliente = new Form4();
        Form3 Proprietario = new Form3();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Cliente" && textBox2.Text == "Cliente")
            {
                Cliente.Show();
                this.Close();
            }
            else if (textBox1.Text == "Proprietario" && textBox2.Text == "Proprietario")
            {
                Proprietario.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Valori inseriti Errati");
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
