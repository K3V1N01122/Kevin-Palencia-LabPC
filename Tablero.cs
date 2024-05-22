namespace Proyecto_Tablero_de_Ajedrez;
public class Tablero
    {
        public Pieza[,] Casillas { get; private set; }

        public Tablero()
        {
            Casillas = new Pieza[8, 8];
        }

        public void AgregarPieza(Pieza pieza)
        {
            int fila = pieza.Posicion[1] - '1';
            int columna = pieza.Posicion[0] - 'a';
            if (Casillas[fila, columna] == null)
            {
                Casillas[fila, columna] = pieza;
            }
            else
            {
                throw new Exception("Ya existe una pieza en esa posición.");
            }
        }

        public List<string> MovimientosValidosDama(string posicion, string color)
        {
            List<string> movimientos = new List<string>();
            int fila = posicion[1] - '1';
            int columna = posicion[0] - 'a';

            int[] direcciones = { -1, 0, 1 };
            foreach (int df in direcciones)
            {
                foreach (int dc in direcciones)
                {
                    if (df == 0 && dc == 0) continue;
                    int r = fila, c = columna;
                    while (true)
                    {
                        r += df; c += dc;
                        if (r < 0 || r >= 8 || c < 0 || c >= 8) break;
                        if (Casillas[r, c] == null)
                        {
                            movimientos.Add($"{(char)('a' + c)}{r + 1}, vacía");
                        }
                        else
                        {
                            if (Casillas[r, c].Color != color) // Verificar color para posibles capturas
                            {
                                movimientos.Add($"{(char)('a' + c)}{r + 1}, {Casillas[r, c].Tipo}");
                                break;
                            }
                        }
                    }
                }
            }
            return movimientos;
        }

        public void ImprimirTablero()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Casillas[i, j] == null)
                        Console.Write(" . ");
                    else
                        Console.Write($"{Casillas[i, j].Tipo[0]} ");
                }
                Console.WriteLine();
            }
        }
    }
