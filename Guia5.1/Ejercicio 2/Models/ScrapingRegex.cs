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
        public Intimacion ExtraerDatos(string texto)
        {
            Intimacion intimacion = new Intimacion();

            // Lugar y Fecha de Emisión
            Match lugarFechaMatch = Regex.Match(texto, @"(?<lugar>\w+),\s*(?<fecha>(\d{1,2}(/|-)\d{1,2}(/|-)\d{2,4}|\d{1,2} de \w+ de \d{4}))");
            if (lugarFechaMatch.Success)
            {
                intimacion.LugarEmision = lugarFechaMatch.Groups["lugar"].Value;
                intimacion.FechaEmision = lugarFechaMatch.Groups["fecha"].Value;
            }

            // Persona Demandada
            Match demandadoMatch = Regex.Match(texto, @"Sr\(a\)\s*(?<nombre>[A-ZÁÉÍÓÚÑa-záéíóúñ]+(?:\s+[A-ZÁÉÍÓÚÑa-záéíóúñ]+)+)");
            if (demandadoMatch.Success)
            {
                intimacion.PersonaDemandada = demandadoMatch.Groups["nombre"].Value;
            }

            // Estudio Jurídico
            Match estudioMatch = Regex.Match(texto, @"despacho\s+JUR[IÍ]DICO\s+(?<estudio>[A-Z&\s]+)");
            if (estudioMatch.Success)
            {
                intimacion.EstudioJuridico = estudioMatch.Groups["estudio"].Value.Trim();
            }

            // Persona Demandante
            Match demandanteMatch = Regex.Match(texto, @"corporativo\s+(?<nombre>[A-ZÁÉÍÓÚÑa-záéíóúñ]+(?:\s+[A-ZÁÉÍÓÚÑa-záéíóúñ]+)+)");
            if (demandanteMatch.Success)
            {
                intimacion.PersonaDemandante = demandanteMatch.Groups["nombre"].Value;
            }

            // Fecha y Hora de Ejecución
            Match ejecucionMatch = Regex.Match(texto, @"a las\s+(?<hora>\d{1,2}:\d{2})\s+horas del día\s+(?<dia>\d{1,2})\s+de\s+(?<mes>\w+)\s+del año\s+(?<anio>\d{4})");
            if (ejecucionMatch.Success)
            {
                intimacion.FechaHoraEjecucion = $"{ejecucionMatch.Groups["hora"].Value} del día {ejecucionMatch.Groups["dia"].Value} de {ejecucionMatch.Groups["mes"].Value} del año {ejecucionMatch.Groups["anio"].Value}";
            }

            // Monto Adeudado
            Match montoMatch = Regex.Match(texto, @"cantidad de\s+\$(?<monto>[\d\.,]+)");
            if (montoMatch.Success)
            {
                intimacion.MontoAdeudado = $"${montoMatch.Groups["monto"].Value}";
            }

            return intimacion;
        }
    }
}
