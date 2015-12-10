using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibreriaTSV;
namespace LectorTSV
{
    public partial class Form1 : Form
    {
        public LeerCargarTSV leer  = new LeerCargarTSV();
        public Errores error = new Errores();
        public List<Errores> ListaErrores;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           var fichero= Ficheros();
            ListaErrores = leer.LeerCargarArchivo(fichero);
            textBox1.Text += error.MostrarErrores(ListaErrores);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LimpiarTexto();
        }


        #region limpiarcampos
        public void LimpiarTexto()
        {
            foreach (Control c in this.Controls)

            {

                if (c is TextBox)

                {

                    c.Text = "";

                    //Enfoco en el primer TextBox

                    this.textBox1.Focus();

                }

            }
        }
        #endregion
        #region seleccionar fichero 
        private string Ficheros()
        {
            var abrirArchivo = new OpenFileDialog();
            abrirArchivo.Title = "Selecciona archivo .tsv";
            abrirArchivo.Filter = "Archivo tsv (.tsv)|*.tsv|TSV Files (*.*)|*.*";
            abrirArchivo.RestoreDirectory = true;

            if (abrirArchivo.ShowDialog() == DialogResult.Cancel)
            {
              textBox1.Text += "No se escogió ningun archivo" + Environment.NewLine;
            }
            return abrirArchivo.FileName;
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            this.AutoSize = false;
            this.Location = new Point(400, 250);
        }
    }
}
