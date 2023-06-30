using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuApp
{
    public partial class Form1 : Form
    {
        const int n = 3; // Matriz n de 3*3.
        const int sizeButton = 50; // Definimos el tamaño inicial de un botón de la matriz.
        public int[,] map = new int[n * n, n * n]; // Filas por Columnas de n números.

        // Método de ejecución.
        public Form1()
        {
            InitializeComponent(); // Llamado del método inicial.
            GenerateMap(); // Llamado del método anterior.
        }

        // Método que permite generar una matriz de 3*3

        public void GenerateMap()
        {
            for (int i = 0; i < n * n; i++) // Por filas.
            {
                for (int j = 0; j < n * n; j++) // Por columnas.
                {
                    map[i, j] = (i * n + i / n + j) % (n * n) + 1; // Se crea una matriz dando un resultado total de filas por columnas.
                }
            }
            CreateMap(); // Llamado del método anterior.
        }

        // Método que crea una matriz al generarla.

        public void CreateMap()
        {
            for (int i = 0; i < n * n; i++) // Por filas.
            {
                for (int j = 0; j < n * n; j++) // Por columnas.
                {
                    Button button = new Button(); // Agregaremos automáticamente un nuevo botón como parte de una matriz generada.
                    button.Size = new Size(sizeButton, sizeButton); // El tamaño del botón se define por el ancho y la altura.}
                    button.Text = map[i, j].ToString(); // Se agrega texto a los botones de una matriz.
                    button.Location = new Point(j * sizeButton, i * sizeButton); // Se define la posición de cada botón mediante el ancho y su altura.
                    this.Controls.Add(button); // Añade un botón.
                }
            }
        }

        
    }
}
