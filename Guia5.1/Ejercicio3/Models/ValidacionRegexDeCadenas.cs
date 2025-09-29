using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ejercicio3.Models
{
    internal class ValidacionRegexDeCadenas
    {
        public static readonly HashSet<string> CodonesParada = new HashSet<string> { "TAA", "TAG", "TGA" };

        private Dictionary<string, string> codonAminoacido = new Dictionary<string, string>
    {
        { "TTC", "Fenilalanina" }, { "TTT", "Fenilalanina" },
        { "TTA", "Leucina" }, { "TTG", "Leucina" }, { "CTT", "Leucina" }, { "CTC", "Leucina" },
        { "CTA", "Leucina" }, { "CTG", "Leucina" },
        { "ATT", "Isoleucina" }, { "ATC", "Isoleucina" }, { "ATA", "Isoleucina" },
        { "ATG", "Metionina" },
        { "GTT", "Valina" }, { "GTC", "Valina" }, { "GTA", "Valina" }, { "GTG", "Valina" },
        { "TCT", "Serina" }, { "TCC", "Serina" }, { "TCA", "Serina" }, { "TCG", "Serina" },
        { "AGT", "Serina" }, { "AGC", "Serina" },
        { "CCT", "Prolina" }, { "CCC", "Prolina" }, { "CCA", "Prolina" }, { "CCG", "Prolina" },
        { "ACT", "Treonina" }, { "ACC", "Treonina" }, { "ACA", "Treonina" }, { "ACG", "Treonina" },
        { "GCT", "Alanina" }, { "GCC", "Alanina" }, { "GCA", "Alanina" }, { "GCG", "Alanina" },
        { "TAT", "Tirosina" }, { "TAC", "Tirosina" },
        { "CAT", "Histidina" }, { "CAC", "Histidina" },
        { "CAA", "Glutamina" }, { "CAG", "Glutamina" },
        { "AAT", "Asparagina" }, { "AAC", "Asparagina" },
        { "AAA", "Lisina" }, { "AAG", "Lisina" },
        { "GAT", "Aspartato" }, { "GAC", "Aspartato" },
        { "GAA", "Glutamato" }, { "GAG", "Glutamato" },
        { "TGT", "Cisteína" }, { "TGC", "Cisteína" },
        { "TGG", "Tryptófano" },
        { "CGT", "Arginina" }, { "CGC", "Arginina" }, { "CGA", "Arginina" }, { "CGG", "Arginina" },
        { "AGA", "Arginina" }, { "AGG", "Arginina" },
        { "GGT", "Glicina" }, { "GGC", "Glicina" }, { "GGA", "Glicina" }, { "GGG", "Glicina" }
    };

        public bool EsCadenaValida(string cadena, out string cadenaProcesada)
        {
            cadenaProcesada = null;

            // 1. Limpiar y convertir a mayúsculas
            string limpia = Regex.Replace(cadena.ToUpper(), @"[^ATCG]", "");

            // 2. Buscar codón de inicio
            int inicio = limpia.IndexOf("ATG");
            if (inicio == -1) return false;

            // 3. Buscar codón de parada
            Match paradaMatch = Regex.Match(limpia.Substring(inicio), @"(TAA|TAG|TGA)");
            if (!paradaMatch.Success) return false;

            int fin = limpia.IndexOf(paradaMatch.Value, inicio);
            if (fin == -1 || (fin - inicio) % 3 != 0) return false;

            // 4. Extraer codones
            string secuencia = limpia.Substring(inicio, fin - inicio);
            MatchCollection codones = Regex.Matches(secuencia, @"[ATCG]{3}");

            cadenaProcesada = string.Join("-", codones.Cast<Match>().Select(m => m.Value));

            
            return true;
        }

        public List<Aminoacido> ClasificarCodones(string cadenaProcesada)
        {
            List<Aminoacido> lista = new List<Aminoacido>();
            string[] codones = cadenaProcesada.Split('-');

            foreach (string codon in codones)
            {
                if (!CodonesParada.Contains(codon))
                {
                    string nombre = codonAminoacido.TryGetValue(codon, out string n) ? n : "Desconocido";
                    lista.Add(new Aminoacido(codon, nombre));
                }
            }

            return lista;
        }
    }
}
