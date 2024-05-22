namespace Proyecto_Tablero_de_Ajedrez;

public class Pieza
    {
        public string Tipo { get; private set; }
        public string Color { get; private set; }
        public string Posicion { get; private set; }

        public Pieza(string tipo, string color, string posicion)
        {
            Tipo = tipo;
            Color = color;
            Posicion = posicion;
        }

        public override string ToString()
        {
            return $"Tipo: {Tipo}, Color: {Color}, Posición: {Posicion}";
        }
    }