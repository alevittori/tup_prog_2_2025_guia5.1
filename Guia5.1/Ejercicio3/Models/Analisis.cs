using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3.Models
{
    internal class Analisis
    {
        public List<Secuencia> SecuenciasValidas { get; set; } = new List<Secuencia>();
        public List<Secuencia> SecuenciasInvalidas { get; set; } = new List<Secuencia>();

        private ValidacionRegexDeCadenas validador = new ValidacionRegexDeCadenas();

        public void AgregarSecuencia(string cadena)
        {
            Secuencia secuencia = new Secuencia(cadena);
            secuencia.ProcesarCadena(validador);

            if (secuencia.Verificada)
                SecuenciasValidas.Add(secuencia);
            else
                SecuenciasInvalidas.Add(secuencia);
        }

        
    }
}
