using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ejercicio_2.Models
{
    internal class IntimacionRegexParse
    {
        public void ProcesarLinea(string linea, Intimacion intimacion)
        {
            if (intimacion.LugarEmision == null || intimacion.FechaEmision == null)
                ExtraerLugarYFecha(linea, intimacion);

            if (intimacion.PersonaDemandada == null)
                ExtraerDemandado(linea, intimacion);

            if (intimacion.EstudioJuridico == null)
                ExtraerEstudioJuridico(linea, intimacion);

            if (intimacion.PersonaDemandante == null)
                ExtraerDemandante(linea, intimacion);

            if (intimacion.FechaHoraEjecucion == null)
                ExtraerFechaHoraEjecucion(linea, intimacion);

            if (intimacion.MontoAdeudado == null)
                ExtraerMonto(linea, intimacion);
        }

        private void ExtraerLugarYFecha(string linea, Intimacion intimacion)
        {
            Match match = Regex.Match(linea, @"(?<lugar>\w+),\s*(?<fecha>(\d{1,2}(/|-)\d{1,2}(/|-)\d{2,4}|\d{1,2} de \w+ de \d{4}))");
            if (match.Success)
            {
                intimacion.LugarEmision = match.Groups["lugar"].Value;
                intimacion.FechaEmision = match.Groups["fecha"].Value;
            }
        }

        private void ExtraerDemandado(string linea, Intimacion intimacion)
        {
            Match match = Regex.Match(linea, @"Sr\(a\)\s*(?<nombre>[A-ZÁÉÍÓÚÑa-záéíóúñ]+(?:\s+[A-ZÁÉÍÓÚÑa-záéíóúñ]+)+)");
            if (match.Success)
            {
                intimacion.PersonaDemandada = match.Groups["nombre"].Value;
            }
        }

        private void ExtraerEstudioJuridico(string linea, Intimacion intimacion)
        {
            Match match = Regex.Match(linea, @"despacho\s+JUR[IÍ]DICO\s+(?<estudio>[A-Z&\s]+)");
            if (match.Success)
            {
                intimacion.EstudioJuridico = match.Groups["estudio"].Value.Trim();
            }
        }

        private void ExtraerDemandante(string linea, Intimacion intimacion)
        {
            Match match = Regex.Match(linea, @"corporativo\s+(?<nombre>[A-ZÁÉÍÓÚÑa-záéíóúñ]+(?:\s+[A-ZÁÉÍÓÚÑa-záéíóúñ]+)+)");
            if (match.Success)
            {
                intimacion.PersonaDemandante = match.Groups["nombre"].Value;
            }
        }

        private void ExtraerFechaHoraEjecucion(string linea, Intimacion intimacion)
        {
            Match match = Regex.Match(linea, @"a las\s+(?<hora>\d{1,2}:\d{2})\s+horas del día\s+(?<dia>\d{1,2})\s+de\s+(?<mes>\w+)\s+del año\s+(?<anio>\d{4})");
            if (match.Success)
            {
                intimacion.FechaHoraEjecucion = $"{match.Groups["hora"].Value} del día {match.Groups["dia"].Value} de {match.Groups["mes"].Value} del año {match.Groups["anio"].Value}";
            }
        }

        private void ExtraerMonto(string linea, Intimacion intimacion)
        {
            Match match = Regex.Match(linea, @"cantidad de\s+\$(?<monto>[\d\.,]+)");
            if (match.Success)
            {
                intimacion.MontoAdeudado = $"${match.Groups["monto"].Value}";
            }
        }
    }
}
