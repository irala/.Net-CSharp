using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaPDF
{
   public class Archivos
    {
        private int ID;
        public int id
        {
            get { return ID; }
            set { ID = value; }
        }

        private string Nombre;
        public string nombre
        {
            get { return Nombre; }
            set { Nombre = value; }
        }

        private DateTime Fecha;
        public DateTime fecha
        {
            get { return Fecha; }
            set { Fecha = value; }
        }

        private string Ruta;
        public string ruta
        {
            get { return Ruta; }
            set { Ruta = value; }
        }

    }
}
