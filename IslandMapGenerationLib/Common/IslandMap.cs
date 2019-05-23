using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandMapGenerationLib.Common
{
    public class IslandMap
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        protected IslandTitle[,] _map;

        
        public IslandMap(int width, int height)
        {
            Width = width;
            Height = height;
            _map = new IslandTitle[Height, Width];    
        }

        public IslandTitle Get(int x, int y)
        {
            if (x < 0 || y < 0 || x > Width || y > Height)
                throw new IndexOutOfRangeException("X or Y is out of range");

            return _map[y, x];
        }
        public IslandTitle Get(Coordinates coordinates) { return Get(coordinates.X, coordinates.Y); }

        public void Set(int x, int y, IslandTitle title)
        {
            if (x < 0 || y < 0 || x >= Width || y >= Height)
                throw new IndexOutOfRangeException("X or Y is out of range");

            _map[y, x] = title;
        }
        public void Set(Coordinates coordinates, IslandTitle title) { Set(coordinates.X, coordinates.Y, title); }
    }
}
