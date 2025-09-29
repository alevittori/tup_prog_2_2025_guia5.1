using Ejercicio3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio3
{
    public partial class Form1 : Form
    {
        Analisis unAnalisi;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            unAnalisi = new Analisis();

            string[] lineas = textBox1.Text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string linea in lineas)
            {
                unAnalisi.AgregarSecuencia(linea);
            }

            listBox1.Items.Clear(); 

            foreach (Secuencia se in unAnalisi.SecuenciasValidas)
            {
                listBox1.Items.Add(se.ToString());
            }
        }
    }
}
