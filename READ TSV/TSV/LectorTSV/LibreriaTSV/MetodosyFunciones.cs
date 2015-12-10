using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaTSV
{
   public class MetodosyFunciones
    {

        private BaseDeDatos bd = new BaseDeDatos();
        private List<Errores> mensajesLog = new List<Errores>();
        private List<Objeto> listaProduccion = new List<Objeto>();

        #region constructores
        public MetodosyFunciones(List<Errores> mensajesLog)
        {
            this.mensajesLog = mensajesLog;
        }

        public  MetodosyFunciones()
        {

        }
        #endregion


        #region comprobaciones de numeros

        public enum FormatoValidoNumerico
        {
            NumeroCorrecto,
            NumeroIncorrecto,
            Nulo,
            Vacio
        }

        public FormatoValidoNumerico ComprobarNumeroCorrecto(string datos)
        {
            if (datos == "#N/A")
                return FormatoValidoNumerico.Nulo;
            int id = -1;
            if (int.TryParse(datos, out id))
                return FormatoValidoNumerico.NumeroCorrecto;
            if (datos == "")
                return FormatoValidoNumerico.Vacio;
            return FormatoValidoNumerico.NumeroIncorrecto;

        }


        public int? ComprobarFormato1(string[] datosProduccion, int posi, int linea, string[] columna, List<Errores> mens)
        {
            var prod = new Objeto();


            switch (ComprobarNumeroCorrecto(datosProduccion[posi]))
            {
                case FormatoValidoNumerico.NumeroCorrecto:
                    var valor = 0;
                    Int32.TryParse(datosProduccion[posi], out valor);
                    prod.Valor = valor;
                    break;
                case FormatoValidoNumerico.NumeroIncorrecto:
                    var error = new Errores
                    {

                        Mensaje =
                            "Error de formato. Columna: " + columna[posi] + ", Línea :" + linea +
                            Environment.NewLine,
                    };
                    mens.Add(error);
                    break;
                case FormatoValidoNumerico.Nulo:
                    prod.Valor = null;
                    break;
            }
            return prod.Valor;
        }

        #endregion

        #region comprobacion de texto

        public enum FormatoValidoTexto
        {   Correcto,
            Nulo,
            Vacio
        }

        public FormatoValidoTexto ComprobarTextoCorrecto(string datos)
        {
            if (datos == null)
                return FormatoValidoTexto.Nulo;          
            if (datos == "")
                return FormatoValidoTexto.Vacio;
            return FormatoValidoTexto.Correcto;

        }

        public string ComprobarFormato2(string[] datosProduccion, int posi, int linea, string[] columna, List<Errores> mens)
        {
            var prod = new Objeto();


            switch (ComprobarTextoCorrecto(datosProduccion[posi]))
            {
                case FormatoValidoTexto.Correcto:
                    prod.ValorT = datosProduccion[posi];
                    break;
                case FormatoValidoTexto.Vacio:
                    var error = new Errores
                    {

                        Mensaje =
                            "Error de formato. Columna: " + columna[posi] + ", Línea :" + linea +
                            Environment.NewLine,
                    };
                    mens.Add(error);
                    break;
                case FormatoValidoTexto.Nulo:
                    prod.ValorT = null;
                    break;
            }
            return prod.ValorT;
        }


        #endregion






    }


}