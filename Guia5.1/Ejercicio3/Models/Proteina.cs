using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3.Models
{
    internal class Proteina
    {
        public List<Aminoacido> Aminoacidos { get; set; } = new List<Aminoacido>();

        public string Nombre
        {
            get
            {
                return string.Join("-", Aminoacidos.Select(a => a.Nombre));
            }
        }

        public override string ToString()
        {
            return $" Proteína: {Nombre}";
        }
    }
}
