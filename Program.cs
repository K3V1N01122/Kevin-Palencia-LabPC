using Proyecto_Tablero_de_Ajedrez;
class Program
    {
        static void Main(string[] args)
        {
            Tablero tablero = new Tablero();
            try
            {
                Console.WriteLine("Ingrese el número de piezas a agregar:");
                int n = int.Parse(Console.ReadLine());

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"Pieza {i + 1}:");
                    Console.Write("Tipo de pieza (alfil, peón, caballo, torre, dama, rey): ");
                    string tipo = Console.ReadLine().ToLower();
                    Console.Write("Color (blanco o negro): ");
                    string color = Console.ReadLine().ToLower();
                    Console.Write("Posición (ejemplo: e4): ");
                    string posicion = Console.ReadLine().ToLower();

                    Pieza pieza = new Pieza(tipo, color, posicion);
                    tablero.AgregarPieza(pieza);
                }

                Console.WriteLine("\nEstado actual del tablero:");
                tablero.ImprimirTablero();

                Console.Write("\nIngrese la posición de una dama para evaluar sus movimientos (ejemplo: g4): ");
                string posDama = Console.ReadLine().ToLower();
                Console.Write("Color de la dama (blanco o negro): ");
                string colorDama = Console.ReadLine().ToLower();
                List<string> movimientos = tablero.MovimientosValidosDama(posDama, colorDama);
                if (movimientos.Count > 0)
                {
                    Console.WriteLine("Los posibles movimientos son:");
                    for (int i = 0; i < movimientos.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {movimientos[i]}");
                    }
                }
                else
                {
                    Console.WriteLine("No hay movimientos disponibles para una dama en esa posición.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
