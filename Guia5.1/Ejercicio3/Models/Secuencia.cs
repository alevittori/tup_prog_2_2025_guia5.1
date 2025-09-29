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
            Verificada = validador.EsCadenaValida(CadenaOriginal, out string procesada); //verificamos si es una cadena valida, y retornamo el conjunto de aminoacidos

            if (Verificada)
            {
                CadenaProcesada = procesada;
                ProteinaTraducida = new Proteina //creamos una proteina
                {
                    Aminoacidos = validador.ClasificarCodones(procesada) // y aca le pasamos los aminoacidos obtenido en la validacion de cadena
                };
            }
        }

        public override string ToString()
        {
            return Verificada
                ? $"Secuencia válida: {CadenaProcesada}\n{ProteinaTraducida} "
                : $"Secuencia inválida: {CadenaOriginal} ";
        }
    }
}
