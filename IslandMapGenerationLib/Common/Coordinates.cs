using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandMapGenerationLib.Common
{
    public class Coordinates
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }
        public Coordinates(int value) : this(value, value) { }
        public Coordinates(Coordinates coordinates) : this(coordinates.X, coordinates.Y) { }

        public static Coordinates operator +(Coordinates coords1, Coordinates coords2)
        {
            return new Coordinates(coords1.X + coords2.X, coords1.Y + coords2.Y);
        }

        public static Coordinates operator /(Coordinates coords1, int value)
        {
            return new Coordinates(coords1.X / value, coords1.Y / value);
        }
    }
}
