using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Models
{
    internal class ControlPatenteChar
    {
        // Verifica si todos los caracteres son letras
        private bool EsLetra(string texto)
        {
            foreach (char c in texto)
                if (!char.IsLetter(c))
                    return false;
            return true;
        }

        // Verifica si todos los caracteres son dígitos
        private bool EsNumero(string texto)
        {
            foreach (char c in texto)
                if (!char.IsDigit(c))
                    return false;
            return true;
        }

        // Verifica formato AAA999
        private bool EsAutoViejo(string patente)
        {
            if (patente.Length != 6) return false;
            string letras = patente.Substring(0, 3);
            string numeros = patente.Substring(3, 3);
            return EsLetra(letras) && EsNumero(numeros);
        }

        // Verifica formato AA999AA
        private bool EsAutoNuevo(string patente)
        {
            if (patente.Length != 7) return false;
            string letras1 = patente.Substring(0, 2);
            string numeros = patente.Substring(2, 3);
            string letras2 = patente.Substring(5, 2);
            return EsLetra(letras1) && EsNumero(numeros) && EsLetra(letras2);
        }

        // Verifica formato AA999AAA
        private bool EsMoto(string patente)
        {
            if (patente.Length != 8) return false;
            string letras1 = patente.Substring(0, 2);
            string numeros = patente.Substring(2, 3);
            string letras2 = patente.Substring(5, 3);
            return EsLetra(letras1) && EsNumero(numeros) && EsLetra(letras2);
        }

        // Verifica formato AA9999
        private bool EsAcoplado(string patente)
        {
            if (patente.Length != 6) return false;
            string letras = patente.Substring(0, 2);
            string numeros = patente.Substring(2, 4);
            return EsLetra(letras) && EsNumero(numeros);
        }

        // Método principal
        public string DeterminarTipo(string patente)
        {
            // Eliminar espacios y convertir a mayúsculas
            string limpia = patente.Replace(" ", "").ToUpper();

            if (EsAutoViejo(limpia)) return "Automóvil/Camioneta hasta 2016";
            if (EsAutoNuevo(limpia)) return "Automóvil/Camioneta desde 2016";
            if (EsMoto(limpia)) return "Motocicleta";
            if (EsAcoplado(limpia)) return "Acoplado";
            return "Otro";
        }
    }
}
