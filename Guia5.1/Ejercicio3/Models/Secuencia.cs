using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ejercicio3.Models
{
    internal class Secuencia
    {
        public string CadenaOriginal { get; set; }
        public string CadenaProcesada { get; set; }
        public bool Verificada { get; set; }
        public Proteina ProteinaTraducida { get; set; }

        public Secuencia(string cadena)
        {
            CadenaOriginal = cadena;
        }
        public void ProcesarCadena(ValidacionRegexDeCadenas validador)
        {
            Verificada = validador.EsCadenaValida(CadenaOriginal, out string procesada);

            if (Verificada)
            {
                CadenaProcesada = procesada;
                ProteinaTraducida = new Proteina
                {
                    Aminoacidos = validador.ClasificarCodones(procesada)
                };
            }
        }

        public override string ToString()
        {
            return Verificada
                ? $"Secuencia válida: {CadenaProcesada}\n{ProteinaTraducida}"
                : $"Secuencia inválida: {CadenaOriginal}";
        }
    }
}
