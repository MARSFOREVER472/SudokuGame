using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        public Button[,] buttons = new Button[n * n, n * n]; // Variable para los botones del tablero.

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
                    buttons[i, j] = new Button(); // Nuevo botón declarado.
                }

            }
            // MatrixTransposition(); // Llamado del método anterior.
            // SwapRowsInBlock(); // Llamado del método anterior.
            // SwapColumnsInBlock(); // Llamado del método anterior.
            // SwapBlocksInRow(); // Llamado del método anterior.
            // SwapBlocksInColumn(); // Llamado del método anterior.

            Random r = new Random(); // Variable aleatoria.
            for (int i = 0; i < 10; i++) // En filas.
            {
                ShuffleMap(r.Next(0, 5)); // Lo haremos por 5 veces.
            }
            CreateMap(); // Llamado del método anterior.
            HideCells(); // Llamado del método anterior.
        }

        // Crearemos un método que pueda ocultar celdas del tablero.
        public void HideCells()
        {
            int N = 40; // 40 números se visualizan en este tablero.
            Random r = new Random(); // Variable aleatoria.

            while (N > 0)
            {
                for (int i = 0; i < n * n; i++) // Filas.
                {
                    for (int j = 0; j < n * n; j++) // Columnas.
                    {
                        if (!string.IsNullOrEmpty(buttons[i, j].Text))
                        {
                           int a = r.Next(0, 3); // Se ocultan números en las celdas del tablero.
                           buttons[i, j].Text = a == 0 ? "" : buttons[i, j].Text; // Se ingresa un número en bloques.
                           buttons[i, j].Enabled = a == 0 ? true : false;

                           // Se disminuye cada número de los bloques.

                           if (a == 0)
                            N--;

                            if (N <= 0) // Si se realizó este procedimiento con números aleatorios del tablero en columnas.
                                break;
                        }
                    }

                    if (N <= 0) // Si se realizó este procedimiento con números aleatorios del tablero en filas.
                        break;
                }
            }
        }

        // Método que permita entremezclar una matriz entre métodos anteriores con un switch y cases:

        public void ShuffleMap(int i)
        {
            switch (i)
            {
                case 0: // Si es una matriz transpuesta.
                    MatrixTransposition();
                    break;

                case 1: // Si una matriz se intercambia en filas por bloques.
                    SwapRowsInBlock();
                    break;

                case 2: // Si una matriz se intercambia en columnas por bloques.
                    SwapColumnsInBlock();
                    break;

                case 3: // Si una matriz se intercambia en bloques por filas.
                    SwapBlocksInRow();
                    break;

                case 4: // Si una matriz se intercambia en bloques por columnas.
                    SwapBlocksInColumn();
                    break;

                default: // Probaremos con la matriz transpuesta.
                    MatrixTransposition();
                    break;
            }
        }

        public void SwapBlocksInRow() // Método que permite intercambiar bloques en filas.
        {
            Random r = new Random(); // Variable aleatoria para los números de los bloques.
            var block1 = r.Next(0, n); // Variable para el bloque 1 (A intercambiar).
            var block2 = r.Next(0, n); // Variable para el bloque 2 (Intercambiado).

            // Mientras el bloque a intercambiar será el intercambiado en filas.

            while (block1 == block2)
                block2 = r.Next(0, n); // Se intercambia con este bloque en fila.
            block1 *= n; // Bloque 1.
            block2 *= n; // Bloque 2.

            // Recorremos por filas y columnas mediante ciclos for para el intercambio.

            for (int i = 0; i < n * n; i++) // En filas.
            {
                var k = block2; // Variable del bloque ya intercambiado.

                for (int j = block1; j < block1 + n; j++) // El valor de la matriz transpuesta se intercambia mediante un resultado de k.
                {
                    var temp = map[j, i];
                    map[j, i] = map[k, i];
                    map[k, i] = temp;
                    k++;
                }
            } 
        }

        public void SwapBlocksInColumn() // Método que permite intercambiar bloques en filas.
        {
            Random r = new Random(); // Variable aleatoria para los números de los bloques.
            var block1 = r.Next(0, n); // Variable para el bloque 1 (A intercambiar).
            var block2 = r.Next(0, n); // Variable para el bloque 2 (Intercambiado).

            // Mientras el bloque a intercambiar será el intercambiado en filas.

            while (block1 == block2)
                block2 = r.Next(0, n); // Se intercambia con este bloque en fila.
            block1 *= n; // Bloque 1.
            block2 *= n; // Bloque 2.

            // Recorremos por filas y columnas mediante ciclos for para el intercambio.

            for (int i = 0; i < n * n; i++) // En filas.
            {
                var k = block2; // Variable del bloque ya intercambiado.

                for (int j = block1; j < block1 + n; j++) // El valor de la matriz transpuesta se intercambia mediante un resultado de k.
                {
                    var temp = map[i, j];
                    map[i, j] = map[i, k];
                    map[i, k] = temp;
                    k++;
                }
            }
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

        // Haremos el mismo proceso pero esta vez en columnas.

        public void SwapColumnsInBlock()
        {
            Random rnd = new Random(); // Variable Aleatoria.
            var block = rnd.Next(0, n); // Variable para bloques que se intercambian en columnas.
            var row1 = rnd.Next(0, n); // Variable para la fila 1.
            var line1 = block * n + row1; // La línea 1 es el intercambio en bloques para la fila 1.
            var row2 = rnd.Next(0, n); // Variable para la fila 2.

            // Crearemos un ciclo while para realizar el proceso de intercambiar 2 filas.

            while (row1 == row2)
                row2 = rnd.Next(0, n); // Fila 2.
            var line2 = block * n + row2; // La línea 2 es el intercambio en bloques para la fila 2.

            // El proceso anterior se repite a tal punto de que se declararon variables.

            for (int i = 0; i < n * n; i++) // Solamente en columnas para realizar el intercambio.
            {
                var temp = map[i, line1];
                map[i, line1] = map[i, line2];
                map[i, line2] = temp;
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
                    button.Size = new Size(sizeButton, sizeButton); // El tamaño del botón se define por el ancho y la altura.
                    buttons[i, j] = button;
                    button.Text = map[i, j].ToString(); // Se agrega texto a los botones de una matriz.
                    button.Click += OnCellPressed;
                    button.Location = new Point(j * sizeButton, i * sizeButton); // Se define la posición de cada botón mediante el ancho y su altura.
                    this.Controls.Add(button); // Añade un botón.
                }
            }
        }

        // Método que verifica al presionar una celda de botón.

        public void OnCellPressed(object sender, EventArgs e)
        {
            Button pressedButton = sender as Button; // Cuando se presiona un botón.
            string buttonText = pressedButton.Text; // Variable que involucra a los botones con un texto.
            if (string.IsNullOrEmpty(buttonText)) // Si el número aumenta en 1 al presionar un botón.
            {
                pressedButton.Text = "1"; // Aumenta simplemente en 1 por baldosa del tablero.
            }

            else // En caso contrario cuando es un 10.
            {
                int num = int.Parse(buttonText); // Variable numérica.
                num++; // Aumenta en 1 el contador (Número).
                if (num == 10) // Si los números son en 10 en total.
                    num = 1; // Cuando es 1 en la celda.
                pressedButton.Text = num.ToString(); // Al presionar un botón, convierte en una cadena de caracteres.



            }
            

        }

        // Nuevo método para el botón del juego...

        private void button1_Click(object sender, EventArgs e)
        {
            // Para las filas del tablero...

            for (int i = 0; i < n * n; i++)
            {
                // Para las columnas del tablero...

                for (int j = 0; j < n * n; j++)
                {
                    var botonTexto = buttons[i, j].Text; // Para cada botón del tablero.

                    if (botonTexto != map[i, j].ToString()) // Si el procedimiento efectuado no es válido...
                    {
                        MessageBox.Show("Buscaando la zonah >:( ...");
                        return;
                    }
                }
            }

            MessageBox.Show("Bien hecho!");
            GenerateMap(); // Llamado del método anterior.
        }
    }
}
