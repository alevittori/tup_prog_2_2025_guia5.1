using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_2
{
    internal class Intimacion
    {
        public string LugarEmision { get; set; }
        public string FechaEmision { get; set; }
        public string PersonaDemandada { get; set; }
        public string EstudioJuridico { get; set; }
        public string PersonaDemandante { get; set; }
        public string FechaHoraEjecucion { get; set; }
        public string MontoAdeudado { get; set; }

        public override string ToString()
        {
            return $"Lugar de Emisión: {LugarEmision}\r\n" +
                   $"Fecha de Emisión: {FechaEmision}\r\n" +
                   $"Persona Demandada: {PersonaDemandada}\r\n" +
                   $"Estudio Jurídico: {EstudioJuridico}\r\n" +
                   $"Persona Demandante: {PersonaDemandante}\r\n" +
                   $"Fecha y Hora de Ejecución: {FechaHoraEjecucion}\r\n" +
                   $"Monto Adeudado: {MontoAdeudado}";
        }
    }
}
