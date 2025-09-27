using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ejercicio1.Models
{
    internal class ControlPatenteRegex
    {
        private bool EsAutoViejo(string patente)
        {
            return Regex.IsMatch(patente, @"^[A-Z]{3}[0-9]{3}$");
        }

        private bool EsAutoNuevo(string patente)
        {
            return Regex.IsMatch(patente, @"^[A-Z]{2}[0-9]{3}[A-Z]{2}$");
        }

        private bool EsMoto(string patente)
        {
            return Regex.IsMatch(patente, @"^[A-Z]{2}[0-9]{3}[A-Z]{3}$");
        }

        private bool EsAcoplado(string patente)
        {
            return Regex.IsMatch(patente, @"^[A-Z]{2}[0-9]{4}$");
        }

        public string DeterminarTipo(string patente)
        {
            string limpia = patente.Replace(" ", "").ToUpper();

            if (EsAutoViejo(limpia)) return "Automóvil/Camioneta hasta 2016";
            if (EsAutoNuevo(limpia)) return "Automóvil/Camioneta desde 2016";
            if (EsMoto(limpia)) return "Motocicleta";
            if (EsAcoplado(limpia)) return "Acoplado";
            return "Otro";
        }
    }
}
