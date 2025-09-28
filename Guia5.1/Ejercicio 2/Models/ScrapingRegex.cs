using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ejercicio_2.Models
{
    internal class ScrapingRegex
    {
        private IntimacionRegexParse parser = new IntimacionRegexParse();

        public Intimacion ExtraerDatos(string texto)
        {
            Intimacion intimacion = new Intimacion();
            string[] lineas = texto.Split('\n');

            foreach (string linea in lineas)
            {
                parser.ProcesarLinea(linea, intimacion);
            }

            return intimacion;
        }
    }
}
