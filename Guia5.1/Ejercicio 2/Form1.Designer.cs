namespace Ejercicio_2
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbArchivo = new System.Windows.Forms.TextBox();
            this.tbDatos = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExtraer = new System.Windows.Forms.Button();
            this.rbChar = new System.Windows.Forms.RadioButton();
            this.rbRegex = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbArchivo
            // 
            this.tbArchivo.Location = new System.Drawing.Point(17, 21);
            this.tbArchivo.Multiline = true;
            this.tbArchivo.Name = "tbArchivo";
            this.tbArchivo.Size = new System.Drawing.Size(632, 254);
            this.tbArchivo.TabIndex = 0;
            // 
            // tbDatos
            // 
            this.tbDatos.Location = new System.Drawing.Point(17, 26);
            this.tbDatos.Multiline = true;
            this.tbDatos.Name = "tbDatos";
            this.tbDatos.Size = new System.Drawing.Size(632, 214);
            this.tbDatos.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbRegex);
            this.groupBox1.Controls.Add(this.rbChar);
            this.groupBox1.Controls.Add(this.btnExtraer);
            this.groupBox1.Location = new System.Drawing.Point(753, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(301, 233);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Procesar";
            // 
            // btnExtraer
            // 
            this.btnExtraer.Location = new System.Drawing.Point(113, 36);
            this.btnExtraer.Name = "btnExtraer";
            this.btnExtraer.Size = new System.Drawing.Size(81, 69);
            this.btnExtraer.TabIndex = 0;
            this.btnExtraer.Text = "Extraer Datos";
            this.btnExtraer.UseVisualStyleBackColor = true;
            this.btnExtraer.Click += new System.EventHandler(this.btnExtraer_Click);
            // 
            // rbChar
            // 
            this.rbChar.AutoSize = true;
            this.rbChar.Location = new System.Drawing.Point(102, 139);
            this.rbChar.Name = "rbChar";
            this.rbChar.Size = new System.Drawing.Size(121, 20);
            this.rbChar.TabIndex = 1;
            this.rbChar.TabStop = true;
            this.rbChar.Text = "Con Char/String";
            this.rbChar.UseVisualStyleBackColor = true;
            // 
            // rbRegex
            // 
            this.rbRegex.AutoSize = true;
            this.rbRegex.Location = new System.Drawing.Point(102, 186);
            this.rbRegex.Name = "rbRegex";
            this.rbRegex.Size = new System.Drawing.Size(95, 20);
            this.rbRegex.TabIndex = 2;
            this.rbRegex.TabStop = true;
            this.rbRegex.Text = "Con Regex";
            this.rbRegex.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbArchivo);
            this.groupBox2.Location = new System.Drawing.Point(35, 58);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(668, 288);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Texto a Analizar";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbDatos);
            this.groupBox3.Location = new System.Drawing.Point(35, 374);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(668, 265);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos Extraidos";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(955, 570);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(99, 56);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 692);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbArchivo;
        private System.Windows.Forms.TextBox tbDatos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbRegex;
        private System.Windows.Forms.RadioButton rbChar;
        private System.Windows.Forms.Button btnExtraer;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnSalir;
    }
}

