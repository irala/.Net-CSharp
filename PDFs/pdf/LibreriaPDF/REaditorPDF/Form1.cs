using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibreriaPDF;
namespace REaditorPDF
{
    public partial class Form1 : Form
    {
        LibreriaPDF.ClaseLibreria lib = new LibreriaPDF.ClaseLibreria();
        
        public Form1()
        {
            InitializeComponent();
            lib.conexionBD();
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListaPDF lista = new ListaPDF();
            this.Hide();
            lista.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CrearPDF crear = new CrearPDF();
            this.Hide();
            crear.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
         
        }
    }
}
