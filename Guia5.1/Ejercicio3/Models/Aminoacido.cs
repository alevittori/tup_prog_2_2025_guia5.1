using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3.Models
{
    internal class Aminoacido
    {
        public string Codon { get; set; }
        public string Nombre { get; set; }

        public Aminoacido(string codon, string nombre)
        {
            Codon = codon;
            Nombre = nombre;
        }

        public override string ToString()
        {
            return $"{Codon} → {Nombre}";
        }
    }
}
