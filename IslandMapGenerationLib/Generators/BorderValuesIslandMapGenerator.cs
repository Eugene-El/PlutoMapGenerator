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
        [Range(0, 100)]
        [DefaultValue(25)]
        public double DistanceFromBorderCoeficient { get; set; }

        [Range(0, 100)]
        [DefaultValue(25)]
        public double DeviationCoeficient { get; set; }

        private Random _random;

        public BorderValuesIslandMapGenerator(int? seed = null)
        {
            _random = seed.HasValue ? new Random(seed.Value) : new Random();
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
