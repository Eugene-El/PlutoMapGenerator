using IslandMapGenerationLib.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapVisualizationLib
{
    public class MapVisualizator
    {
        [Range(1, 100)]
        public int Scale { get; set; } = 1;

        public Bitmap Visualize(IslandMap map)
        {
            Bitmap bitmap = new Bitmap(map.Width * Scale, map.Height * Scale);
            for (int y = 0; y < map.Height; y++)
            {
                for (int x = 0; x < map.Width; x++)
                {
                    if (map.Get(x, y)?.Value == 1)
                    {
                        Fill(bitmap, x * Scale, y * Scale, (x + 1) * Scale, (y + 1) * Scale, Color.Brown);
                    }
                    else
                    {
                        Fill(bitmap, x * Scale, y * Scale, (x + 1) * Scale, (y + 1) * Scale, Color.Blue);
                    }
                }
            }

            return bitmap;
        }

        private void Fill(Bitmap bitmap, int x1, int y1, int x2, int y2, Color color)
        {
            for (int y = y1; y < y2; y++)
                for (int x = x1; x < x2; x++)
                    bitmap.SetPixel(x, y, color);
        }

    }
}
