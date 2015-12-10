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
using System.Web;

namespace REaditorPDF
{
    public partial class ListaPDF : Form
    {
        LibreriaPDF.ClaseLibreria lib = new LibreriaPDF.ClaseLibreria();
        public ListaPDF()
        {
            InitializeComponent();
            //listar todo lo que exista en la bd.
            dataGridView1.DataSource = lib.listarArchivos();
        }

        private void Atrás_Click(object sender, EventArgs e)
        {
            //vuelve al menú.
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }

        private void Ver_Click(object sender, EventArgs e)
        {
            //ir al visualizador de pdf´s
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            VerPDF ver = new VerPDF();
            
            this.Hide();
            ver.Show();
            ver.axAcroPDF1.Show();
            

            
            var i = dataGridView1.SelectedCells[0].RowIndex;
            //devuelve la fila que seleccionas.
            var x = e.RowIndex;
            x = x + 1;

            string ruta=lib.seleccionarArchivos(x);
            ver.axAcroPDF1.LoadFile(ruta);
           
        }

        private void ListaPDF_FormClosed(object sender, FormClosedEventArgs e)
        {
           
            Environment.Exit(1);
        }


       public void dataGridView1_SelectedIndexChanged(object sender, DataGridView e)
        {
           
        }

        private void ListaPDF_Load(object sender, EventArgs e)
        {

        }
    }
}
