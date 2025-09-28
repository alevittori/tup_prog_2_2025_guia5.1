using Ejercicio_2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_2
{
    public partial class Form1 : Form
    {
        List<Intimacion> intimaciones;
        ScrapingChar analizarChar;
        ScrapingRegex analizarRegex;

        string texto = @"Paraná, 20 de Diciembre de 2024
Sr(a) Medina Noemí, El despacho JURÍDICO GUTIERREZ & ASOCIADOS, mediante el
presente EXHORTO EXTRA JUDICIAL de  cobro se le Notifica:
Basados en el  en  el préstamo emitido por el corporativo LEANDRO KRUGER,
se ejecutará a las 16:00 horas del día 1 de enero del año 2024, UNA
DILIGENCIA DE RECUPERACIÓN DE CARTERA EN SU DOMICILIO, debido a la EVASIÓN 
DE PAGO consumada contra mi cliente, por el adeudo de su crédito por la
cantidad de $6.000,00 (seis mil pesos).";

        public Form1()
        {
            InitializeComponent();
            intimaciones = new List<Intimacion>();
            analizarChar = new ScrapingChar();
            analizarRegex = new ScrapingRegex();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Gracias por usar nuestros sistemas", "Salir");
            Close();
        }

        private void btnExtraer_Click(object sender, EventArgs e)
        {
            string texto = tbArchivo.Text;
            if (rbChar.Checked)
            {
                Intimacion intimacionConDatos;
                intimacionConDatos = analizarChar.ExtraerDatos(texto);
                if(intimacionConDatos != null)
                {
                    intimaciones.Add(intimacionConDatos);
                    tbDatos.Text = intimacionConDatos.ToString();
                }
            }
            if (rbRegex.Checked)
            {
                Intimacion intimacionConDatos;
                intimacionConDatos = analizarRegex.ExtraerDatos(texto);
                if(intimacionConDatos!= null)
                {
                    intimaciones.Add(intimacionConDatos);
                    tbDatos.Text = intimacionConDatos.ToString();
                }

            }

        }
    }
}
