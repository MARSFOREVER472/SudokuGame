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
            MatrixTransposition(); // Llamado del método anterior.
            SwapRowsInBlock(); // Llamado del método anterior.
            CreateMap(); // Llamado del método anterior.
        }

        public void SwapRowsInBlock() // Método que permite intercambiar filas en bloques.
        {
            Random rnd = new Random(); // Variable Aleatoria.
            var block = rnd.Next(0, n); // Variable para bloques que se intercambian en filas.
            var row1 = rnd.Next(0, n); // Variable para la fila 1.
            var line1 = block * n + row1; // La línea 1 es el intercambio en bloques para la fila 1.
            var row2 = rnd.Next(0, n); // Variable para la fila 2.

            // Crearemos un ciclo while para realizar el proceso de intercambiar 2 filas.

            while (row1 == row2)
                row2 = rnd.Next(0, n); // Fila 2.
            var line2 = block * n + row2; // La línea 2 es el intercambio en bloques para la fila 2.
            for (int i = 0; i < n * n; i++) // Solamente en filas para realizar el intercambio.
            {
                var temp = map[line1, i];
                map[line1, i] = map[line2, i];
                map[line2, i] = temp;
            }
        }

        // Método que permite crear una matriz transpuesta.

        public void MatrixTransposition()
        {
            int[,] tMap = new int[n * n, n * n]; // Variable para crear una matriz transpuesta.

            // Recorremos por filas y columnas mediante ciclos for.

            for (int i = 0; i < n * n; i++) // Filas.
            {
                for (int j = 0; j < n * n; j++) // Columnas.
                {
                    tMap[i, j] = map[j, i]; // Se crea una matriz transpuesta.
                }
            }
            map = tMap; // La matriz original pasaría a ser una matriz transpuesta.
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
