using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaTSV
{
  public  class Errores
    {
        private string _mensaje;
        public string Mensaje
        {
            get { return _mensaje; }
            set { _mensaje = value; }
        }


        public string MostrarErrores(List<Errores> mens)
        {
            string mensaje = "";
            foreach (var e in mens)
            {
                mensaje += e.Mensaje;
            }

            mens.Clear();
            return mensaje;
        }
    }
}
