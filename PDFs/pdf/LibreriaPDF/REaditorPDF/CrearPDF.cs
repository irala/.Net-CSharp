using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibreriaPDF;
namespace REaditorPDF
{
    public partial class CrearPDF : Form

    {   LibreriaPDF.ClaseLibreria lib = new LibreriaPDF.ClaseLibreria();
        List<LibreriaPDF.Archivos> listaArchivos;
        string foto;


        public CrearPDF()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            lib.crearPDFs(textitulo .Text ,textos.Text ,textautor .Text,foto);
          
            
            
        }

        public List<Archivos> guardarenLista()
        {
            listaArchivos = new List<Archivos>();

            var archivo = new Archivos {
                nombre = textitulo.Text,
                fecha = DateTime.Now,
                ruta = @"C:\Users\Nuria\Documents\Visual Studio 2015\Projects\LibreriaPDF\REaditorPDF\bin\Debug\" + textitulo.Text + ".pdf",


        };
            listaArchivos.Add(archivo);

           
       

            return listaArchivos;
        }
        public void limpiarcampos()
        {
            foreach (Control c in this.Controls)

            {

                if (c is TextBox)

                {

                    c.Text = "";

                    //Enfoco en el primer TextBox

                    this.textos.Focus();

                }

            }
        }


        public void limpiarPDF()
        {
            limpiarUnCampo(textitulo.Text);
            limpiarUnCampo(textautor.Text);
            limpiarUnCampo(textos.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            limpiarUnCampo(textitulo.Text);
        }

        public void limpiarUnCampo(string texto)
        {
            texto = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            limpiarcampos();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            limpiarUnCampo(textos.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            limpiarUnCampo(textautor.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();

        }

        private void CrearPDF_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            Environment.Exit(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //guardar en la base de datos.

            listaArchivos = guardarenLista();

            lib.insertarDatos(listaArchivos);
            limpiarcampos();
        }

        private void button6_Click(object sender, EventArgs e)
        {
          foto = añadirFotoPDF();
        }

        public string añadirFotoPDF()
        {
            OpenFileDialog BuscarImagen = new OpenFileDialog();
            BuscarImagen.Filter = "Archivos de Imagen|*.jpg|*.gif|*.png";
            //Aquí incluiremos los filtros que queramos.
            BuscarImagen.FileName = "";
            BuscarImagen.Title = "Titulo del Dialogo";
            BuscarImagen.InitialDirectory = "C:\\";

            if (BuscarImagen.ShowDialog() == DialogResult.Cancel)
                MessageBox.Show("No se ha cargado ninguna imagen.");
            return BuscarImagen.FileName;
        }
         
    }
}

