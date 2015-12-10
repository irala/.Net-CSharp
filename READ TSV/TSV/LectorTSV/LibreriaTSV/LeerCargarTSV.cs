using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaTSV
{
    public class LeerCargarTSV
    {
        private readonly MetodosyFunciones metodos = new MetodosyFunciones();
        private List<Errores> listaErrores;
        private List<Objeto> listaObjeto;
        private BaseDeDatos bd;
        private string[] cabeceras = new string[]
                            {
                                "id","telefono","nombre","apellido","direccion","correo"
                            };
        #region funcion leerarchivo
        ///<summary>
        ///Leer, cargar y guardar el fichero que vamos a insertar en la base de datos
        ///</summary>
        public List<Errores> LeerCargarArchivo(string fichero)
        {
            listaErrores = new List<Errores>();
            listaObjeto = new List<Objeto>();
            string comprobarExtension = Path.GetExtension(fichero);


            if (!fichero.Equals(""))
            {
                if (comprobarExtension == ".tsv")
                {

                    var x = new Errores();
                    var mensaje = new Errores                    {
                        
                        Mensaje = "Archivo cargado correctamente " + Environment.NewLine,
                    };
                    listaErrores.Add(mensaje);



                    int contadorLineas = 2;

                    string line;

                    // Leer fichero linea a linea
                    using (StreamReader file = new StreamReader(fichero))
                    {


                        var cabecera = "id	nombre	apellidos	direccion	telefono	correo";
                 

                       var primeraLinea = file.ReadLine();
                        var posiciones = new string[cabeceras.Length];
                        for (int i = 0; i < cabeceras.Length; i++)
                        {

                            posiciones[i] = cabeceras[i];

                        }


                            bool errores = false;


                            while ((line = file.ReadLine()) != null)
                            {

                                var obj = new Objeto();

                                try
                                {
                                   
                                    string[] datosProduccion = line.Split('\t');


                                    #region propiedades del objeto
                                
                                    obj.Id = metodos.ComprobarFormato1(datosProduccion, 0, contadorLineas, posiciones, listaErrores);
                                    obj.Nombre=metodos.ComprobarFormato2(datosProduccion, 1, contadorLineas, posiciones, listaErrores);
                                    obj.Apellido=metodos.ComprobarFormato2(datosProduccion, 2, contadorLineas, posiciones, listaErrores);
                                    obj.Direccion=metodos.ComprobarFormato2(datosProduccion,3, contadorLineas, posiciones, listaErrores);
                                    obj.Telefono = metodos.ComprobarFormato1(datosProduccion, 4, contadorLineas, posiciones, listaErrores);
                                    obj.Correo=metodos.ComprobarFormato2(datosProduccion, 5, contadorLineas, posiciones, listaErrores);



                                    #endregion
                                }
                                catch (IndexOutOfRangeException)
                                {

                                    mensaje = new Errores
                                    {

                                        Mensaje =
                                                "Error, campos vacios. Línea : " + contadorLineas +
                                                Environment.NewLine,
                                    };
                                    listaErrores.Add(mensaje);
                                    errores = true;

                                }

                                if (!errores)
                                {
                                    listaObjeto.Add(obj);
                                }

                                contadorLineas++;

                            }


                            if (errores)
                            {
                                var error1 = new Errores()
                                {

                                    Mensaje =
                                            "NO importamos a base de datos" + Environment.NewLine,
                                };
                                listaErrores.Add(error1);
                            }
                            else
                            {
                                //TODO insertar  a la base de datos si se ha rellenado la lista correctamente.
                                bd= new BaseDeDatos();
                                bd.InsertarDatos(listaObjeto);

                                mensaje = new Errores
                                {

                                    Mensaje =
                                            "Carga de datos correctamente en la base de datos" +
                                            Environment.NewLine,
                                };
                                listaErrores.Add(mensaje);
                            }

                            var error = new Errores
                            {

                                Mensaje =
                                        "Fin del fichero." +
                                        Environment.NewLine,
                            };
                            listaErrores.Add(error);
                        
                    }
                }
                else
                {

                    var error = new Errores
                    {

                        Mensaje = "Extensión de archivo no válida " + Environment.NewLine,
                    };
                    listaErrores.Add(error);

                }
            }
            return listaErrores;

        }
        #endregion


    }


}

   