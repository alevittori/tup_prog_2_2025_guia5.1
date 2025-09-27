using Ejercicio1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio1
{
    public partial class Form1 : Form
    {
        ControlPatenteChar controlChar;
        ControlPatenteRegex controlRegex;
        string[] patentes;
        public Form1()
        {
            InitializeComponent();
            controlChar = new ControlPatenteChar();
            controlRegex = new ControlPatenteRegex();
            patentes = new string[] { "OXY333", "OYZ 013", "AAA 123", "BCD456", "AB123CD", "YZ5432EF", "QW3456AB" };
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (rbString.Checked)
            {
                foreach (string p in patentes)
                {
                    lbResultados.Items.Add(controlChar.DeterminarTipo(p));
                }
            }
            if (rbRegex.Checked)
            {
                foreach(string p in patentes)
                {
                    lbResultados.Items.Add(controlRegex.DeterminarTipo(p));
                }
            }
        }
    }
}
