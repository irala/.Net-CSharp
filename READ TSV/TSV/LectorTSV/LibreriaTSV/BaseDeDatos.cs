using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaTSV
{
    class BaseDeDatos
    {
        #region comando insertar
        string _comandoInsertar = @"INSERT INTO contactos(telefono,nombre,apellido,direccion,correo) VALUES
                                                       (@telefono,@nombre,@apellido,@direccion,@correo)";

        #endregion

        #region insertarDatos

        public void InsertarDatos(List<Objeto> listaProd)
        {
            try
            {

                using (
                    MySqlConnection conexion =
                        new MySqlConnection(string.Format(@"SERVER={0};DATABASE={1};UID={2};PWD={3};PORT={4}",
                                                          Properties.Settings.Default.localhost,
                                                          Properties.Settings.Default.basededatos,
                                                          Properties.Settings.Default.usuario,
                                                          Properties.Settings.Default.contraseña,
                                                          Properties.Settings.Default.puerto)))
                {
                    conexion.Open();
                    foreach (var l in listaProd)
                    {
                        MySqlCommand comando =
                            new MySqlCommand(_comandoInsertar);



                        comando.Connection = conexion;
                        comando.Parameters.AddWithValue("@telefono", l.Telefono);
                        comando.Parameters.AddWithValue("@nombre", l.Nombre);
                        comando.Parameters.AddWithValue("@apellido", l.Apellido);
                        comando.Parameters.AddWithValue("@direccion", l.Direccion);
                        comando.Parameters.AddWithValue("@correo", l.Correo);
                      

                        comando.ExecuteNonQuery();

                    }

                }

            }
            catch (Exception ee)
            {
                var error = new Errores()
                {
                    Mensaje = "Error :" + ee + Environment.NewLine,
                };
            }

        }

        #endregion

    }

}
