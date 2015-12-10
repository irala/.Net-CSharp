using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;


namespace LibreriaPDF
{
    public class ClaseLibreria
    {

      
        List<Archivos> listaArchivos = new List<Archivos>();
      
        public MySqlConnection _conexion =
          new MySqlConnection(string.Format(@"SERVER={0};DATABASE={1};UID={2};PWD={3};PORT={4}",
                                            Properties.Settings.Default.localhost,
                                            Properties.Settings.Default.database, Properties.Settings.Default.usuario,
                                            Properties.Settings.Default.contraseña, Properties.Settings.Default.puerto));
        
        public void conexionBD()
        {

            try
            {

                _conexion.Open();
                //1.confirmacion de la conexion de la base de datos.
              


            }
            catch (MySqlException me)
            {
              

                _conexion.Close();
            }
        }

        

        public List<Archivos> listarArchivos()
        {
            _conexion.Open();

            MySqlCommand consulta = _conexion.CreateCommand();
            consulta.CommandText = "SELECT * FROM lista_archivo";

            MySqlDataReader reader;
            //la conexion debe de estar abierta.
            reader = consulta.ExecuteReader();
            while (reader.Read())
            {
                Archivos archivos  = new Archivos();
                
                archivos.id = Convert.ToInt32(reader["Id_archivo"].ToString());
                archivos.nombre = reader["nombre_archivo"].ToString();
                archivos .fecha =Convert .ToDateTime ( reader["fecha_creacion"].ToString());
                archivos.ruta= reader["ruta_archivo"].ToString();
              
                
                listaArchivos.Add(archivos);

            }

          //  dataGridView1.DataSource = listacontactos;

            //reader.Dispose();
            _conexion.Close();

            return listaArchivos;
        }

        public string  seleccionarArchivos(int id)
        {
            _conexion.Open();

            MySqlCommand consulta = _conexion.CreateCommand();
            consulta.CommandText = "SELECT * FROM lista_archivo WHERE Id_archivo= "+ id;
            
            string ruta = "";
            MySqlDataReader reader;
            //la conexion debe de estar abierta.
            reader = consulta.ExecuteReader();
            while (reader.Read())
            {
                Archivos archivos = new Archivos();

                archivos.id = Convert.ToInt32(reader["Id_archivo"].ToString());
                archivos.nombre = reader["nombre_archivo"].ToString();
                archivos.fecha = Convert.ToDateTime(reader["fecha_creacion"].ToString());
                archivos.ruta = reader["ruta_archivo"].ToString();
                ruta = archivos.ruta;

            }
            
           
            _conexion.Close();
            

            return ruta;
        }
       

        public void insertarDatos(List<LibreriaPDF .Archivos>listaArchvos)
        {
            Archivos archi = new Archivos();
            _conexion.Open();
            try
            {
                MySqlCommand comando =
                         new MySqlCommand(
                             @"INSERT INTO lista_archivo(nombre_archivo,fecha_creacion,ruta_archivo) VALUES
                                                       (@nombre_archivo,@fecha_creacion,@ruta_archivo)");


                foreach (var lista in listaArchvos)
                {
                    comando.Connection = _conexion;
                    comando.Parameters.AddWithValue("@nombre_archivo", lista.nombre);
                    comando.Parameters.AddWithValue("@fecha_creacion", lista.fecha);
                    comando.Parameters.AddWithValue("@ruta_archivo", lista.ruta);

                    comando.ExecuteNonQuery();
                }
                    

               
                
            }
            catch (Exception ee)
            {

            }

            //cierro conexion.
            _conexion.Close();

        }

      

        public void crearPDFs(string texto1, string texto2, string texto3,string foto)
        {
            if (texto1 == "" || texto2 == "" || texto3 == "")
            {
                
           
            }
            else
            {
                Document document = new Document();
                
                
                if (texto1 == "")
                {
                  
                    
                }
                else
                    PdfWriter.GetInstance(document,

                                  new FileStream(texto1 + ".pdf",

                                         FileMode.OpenOrCreate));


                document.Open();
                //cambiar tipo de letra
                Chunk chunk = new Chunk(texto2,

                FontFactory.GetFont("VERDANA",

                            30,

                        iTextSharp.text.Font.ITALIC));
                //probar luego estilos pra el pdf.


                document.Add(new Paragraph(chunk));



                // Creamos la imagen y le ajustamos el tamaño
                //@"C:\Users\Nuria\Desktop\fotos\Potato_gif.gif"
              
                if (foto != null)
                {
                   
               
                    iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(foto);
                    imagen.BorderWidth = 0;
                    imagen.Alignment = Element.ALIGN_RIGHT;
                    float percentage = 0.0f;
                    percentage = 150 / imagen.Width;
                    imagen.ScalePercent(percentage * 100);

                    // Insertamos la imagen en el documento
                    document.Add(imagen);


                }
                //else{
                   
                //}



                document.AddTitle(texto1);
                
                document.AddAuthor(texto3);
                string carpeta = @"C:\Users\Nuria\Documents\Visual Studio 2015\Projects\LibreriaPDF\REaditorPDF\bin\Debug\PDFS\";
                string nombreArchivo = carpeta + texto1+ ".pdf";
                document.Close();
               

                
            }



        }
     


    }
}
