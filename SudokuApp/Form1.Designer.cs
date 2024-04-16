namespace SudokuApp
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
            this.validarJuego = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // validarJuego
            // 
            this.validarJuego.BackColor = System.Drawing.Color.Red;
            this.validarJuego.Location = new System.Drawing.Point(685, 13);
            this.validarJuego.Name = "validarJuego";
            this.validarJuego.Size = new System.Drawing.Size(125, 50);
            this.validarJuego.TabIndex = 0;
            this.validarJuego.Text = "Validar";
            this.validarJuego.UseVisualStyleBackColor = false;
            this.validarJuego.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 744);
            this.Controls.Add(this.validarJuego);
            this.Name = "Form1";
            this.Text = "Sudoku";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button validarJuego;
    }
}

