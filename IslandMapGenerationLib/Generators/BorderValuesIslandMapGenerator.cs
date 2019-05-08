using IslandMapGenerationLib.Common;
using IslandMapGenerationLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace IslandMapGenerationLib.Generators
{
    public class BorderValuesIslandMapGenerator : IIslandMapGenerator
    {
        private double _distanceFromBorderCoeficient;
        /// <summary>
        /// In range from 1 to 100
        /// </summary>
        public double DistanceFromBorderCoeficient
        {
            get { return _distanceFromBorderCoeficient; }
            set { _distanceFromBorderCoeficient = Math.Min(100, Math.Max(1, value)); }
        }

        private double _deviationCoeficient;
        /// <summary>
        /// In range from 1 to 100
        /// </summary>
        public double DeviationCoeficient
        {
            get { return _deviationCoeficient; }
            set { _deviationCoeficient = Math.Min(100, Math.Max(1, value)); }
        }

        private Random _random;

        public BorderValuesIslandMapGenerator(int? seed = null, int distanceFromBorderCoeficient = 25, int deviationCoeficient = 25)
        {
            _random = seed.HasValue ? new Random(seed.Value) : new Random();
            DistanceFromBorderCoeficient = distanceFromBorderCoeficient;
            DeviationCoeficient = deviationCoeficient;
        }

        public IslandMap Generate(int width, int height)
        {
            if (width <= 0 || height <= 0)
                throw new IndexOutOfRangeException("Width or Height can't be zerro or less");

            IslandMap islandMap = new IslandMap(width, height);

            Coordinates leftUpperCorner = new Coordinates(GetRandomDistance(width), GetRandomDistance(height));
            islandMap.Set(leftUpperCorner, new IslandTitle(1));

            return islandMap;
        }

        private int GetRandomDistance(int interval)
        {
            int distance = (int)(interval / 2d * DistanceFromBorderCoeficient / 100);
            int deviation = (int)(interval / 2d * DeviationCoeficient / 100);

            return _random.Next(
                distance - deviation <= 0 ? 1 : distance - deviation,
                distance + deviation >= interval ? interval : distance + deviation);
        }
    }
}
