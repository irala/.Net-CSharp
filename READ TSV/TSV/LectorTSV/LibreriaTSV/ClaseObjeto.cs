using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaTSV
{
  public  class Objeto
    {
        private int? _id;

        public int? Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private string _apellido;

        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        private string _direccion;

        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }
        private int? _telefono;

        public int? Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        private string _correo;

        public string Correo
        {
            get { return _correo; }
            set { _correo = value; }
        }

        private int? _valor;
        public int? Valor
        {
            get { return _valor; }
            set { _valor = value; }
        }

        private string _valort;
        public string ValorT
        {
            get { return _valort; }
            set { _valort = value; }
        }


    }
}
