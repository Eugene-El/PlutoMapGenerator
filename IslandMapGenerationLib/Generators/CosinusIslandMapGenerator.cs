using IslandMapGenerationLib.Common;
using IslandMapGenerationLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandMapGenerationLib.Generators
{
    public class CosinusIslandMapGenerator : IIslandMapGenerator
    {
        public int AngleCount { get; set; }
        public double DeviationCoeficent { get; set; }
        public int SmoothingIterations { get; set; }

        private Random _random;

        public CosinusIslandMapGenerator(int angleCount = 180, double deviationCoeficent = 25, int smoothingIterations = 3)
        {
            AngleCount = angleCount;
            DeviationCoeficent = deviationCoeficent;
            SmoothingIterations = smoothingIterations;
            _random = new Random();
        }

        public IslandMap Generate(int width, int height)
        {
            IslandMap map = new IslandMap(width, height);

            List<Coordinates> coords = new List<Coordinates>();

            double deviation = DeviationCoeficent * width / 200;

            // Generating
            for (int i = 1; i <= AngleCount; i++)
            {
                double angle = 360d / AngleCount * i;
                double trueDistance = height / 2; /// Math.Cos(ToRadian(angle));
                int distance = _random.Next((int)(trueDistance - deviation), (int)(trueDistance + deviation));

                int xDist = (int)(Math.Sin(ToRadian(angle)) * distance);
                int yDist = (int)(Math.Cos(ToRadian(angle)) * distance);

                int x = Validate(width / 2 + xDist, width);
                int y = Validate(height / 2 - yDist, height);

                coords.Add(new Coordinates(x, y));
            }

            // Smoothing
            for (int i = 0; i < SmoothingIterations; i++)
            {
                for (int j = 1; j < coords.Count; j++)
                {
                    coords[j - 1] = (coords[j - 1] + coords[j]) / 2;
                }
                coords[coords.Count - 1] = (coords.Last() + coords.First()) / 2;
            }

            // Drawing border
            for (int i = 1; i < coords.Count; i++)
                DrawLine(map, coords[i - 1], coords[i]);
            DrawLine(map, coords.First(), coords.Last());

            // Fill inside part
            Stack<Coordinates> pixelsToColor = new Stack<Coordinates>();
            pixelsToColor.Push(new Coordinates(width / 2, height / 2));



            while (pixelsToColor.Count > 0)
            {
                Coordinates coordinates = pixelsToColor.Pop();

                Coordinates[] probableCoords = new Coordinates[] {
                    new Coordinates(coordinates.X - 1, coordinates.Y),
                    new Coordinates(coordinates.X + 1, coordinates.Y),
                    new Coordinates(coordinates.X, coordinates.Y - 1),
                    new Coordinates(coordinates.X, coordinates.Y + 1)
                };

                map.Set(coordinates, new IslandTitle(1));
                for (int i = 0; i < probableCoords.Length; i++)
                    if (probableCoords[i].Y >= 0 && probableCoords[i].X >= 0 &&
                        probableCoords[i].Y < height && probableCoords[i].X < width &&
                        !coords.Any(c => c == probableCoords[i]) &&
                        map.Get(probableCoords[i]) == null)
                        pixelsToColor.Push(probableCoords[i]);
            }


            // Return map
            return map;
        }

        private int Validate(int value, int max)
        {
            if (value < 0)
                return 0; 
            if (value >= max)
                return max - 1;
            return value;
        }

        private double ToRadian(double value)
        {
            return value * Math.PI / 180d;
        }

        /// <summary>
        /// Bresenham line algorithm
        /// </summary>
        /// <param name="map"></param>
        /// <param name="coords1"></param>
        /// <param name="coords2"></param>
        private void DrawLine(IslandMap map, Coordinates coords1, Coordinates coords2)
        {
            Coordinates coords = new Coordinates(coords1);
            int dx = Math.Abs(coords2.X - coords.X), sx = coords.X < coords2.X ? 1 : -1;
            int dy = Math.Abs(coords2.Y - coords.Y), sy = coords.Y < coords2.Y ? 1 : -1;
            int err = (dx > dy ? dx : -dy) / 2,
                e2;
            while (true)
            {
                map.Set(coords.X, coords.Y, new IslandTitle(1));
                if (coords.X == coords2.X && coords.Y == coords2.Y) break;
                e2 = err;
                if (e2 > -dx) { err -= dy; coords.X += sx; }
                if (e2 < dy) { err += dx; coords.Y += sy; }
            }
        }
    }
}
