using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_2.Models
{
    internal class IntimacionParser
    {
        public void ProcesarLinea(string linea, Intimacion intimacion)
        {
            string l = linea.Trim();

            if (intimacion.LugarEmision == null && intimacion.FechaEmision == null)
                AnalizarLugarYFecha(l, intimacion);

            if (intimacion.PersonaDemandada == null && intimacion.EstudioJuridico == null)
                AnalizarDemandadoYEstudio(l, intimacion);

            if (intimacion.PersonaDemandante == null)
                AnalizarDemandante(l, intimacion);

            if (intimacion.FechaHoraEjecucion == null)
                AnalizarFechaHoraEjecucion(l, intimacion);

            if (intimacion.MontoAdeudado == null)
                AnalizarMonto(l, intimacion);
        }

        private void AnalizarLugarYFecha(string l, Intimacion intimacion)
        {
            if (!l.Contains(",")) return;

            int coma = l.IndexOf(',');
            string posibleLugar = l.Substring(0, coma).Trim();
            string posibleFecha = l.Substring(coma + 1).Trim();

            bool esFechaLarga = posibleFecha.Contains("de");
            bool esFechaCorta = posibleFecha.Count(c => c == '/') == 2;
            bool esFechaGuion = posibleFecha.Count(c => c == '-') == 2;

            string[] partes = posibleFecha.Split(new char[] { '/', '-' });
            int gruposNumericos = partes.Count(p => p.All(char.IsDigit));
            bool esFechaNumericaValida = gruposNumericos == 3;

            if (esFechaLarga || esFechaCorta || (esFechaGuion && esFechaNumericaValida))
            {
                intimacion.LugarEmision = posibleLugar;
                intimacion.FechaEmision = posibleFecha;
            }
        }

        private void AnalizarDemandadoYEstudio(string l, Intimacion intimacion)
        {
            if (!l.StartsWith("Sr")) return;

            int coma = l.IndexOf(',');
            string persona = l.Substring(0, coma).Replace("Sr(a)", "").Trim();
            intimacion.PersonaDemandada = persona;

            int despachoIndex = l.IndexOf("despacho");
            int comaDespacho = l.IndexOf(',', despachoIndex);
            if (despachoIndex != -1 && comaDespacho != -1)
            {
                string estudio = l.Substring(despachoIndex + 9, comaDespacho - despachoIndex - 9).Trim();
                intimacion.EstudioJuridico = estudio;
            }
        }

        private void AnalizarDemandante(string l, Intimacion intimacion)
        {
            int index = l.IndexOf("corporativo");
            if (index != -1)
            {
                string nombre = l.Substring(index + "corporativo".Length).Trim().Replace(",", "");
                intimacion.PersonaDemandante = nombre;
            }
        }

        private void AnalizarFechaHoraEjecucion(string l, Intimacion intimacion)
        {
            int desde = l.IndexOf("a las");
            if (desde != -1)
            {
                string ejecucion = l.Substring(desde + 6).Trim();
                intimacion.FechaHoraEjecucion = ejecucion.Replace("UNA", "").Trim();
            }
        }

        private void AnalizarMonto(string l, Intimacion intimacion)
        {
            int index = l.IndexOf('$');
            if (index == -1) return; // No hay símbolo de monto

            int fin = l.IndexOf('(', index);
            if (fin == -1 || fin <= index) return; // No hay paréntesis o está mal ubicado

            string monto = l.Substring(index, fin - index).Trim();
            intimacion.MontoAdeudado = monto;
        }
    }
}
