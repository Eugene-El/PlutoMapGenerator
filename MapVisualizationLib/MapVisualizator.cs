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
            Bitmap bitmap = new Bitmap(map.Width * Scale, map.Height * Scale); ;
            Graphics graphics = Graphics.FromImage(bitmap);
            for (int y = 0; y < map.Height; y++)
            {
                for (int x = 0; x < map.Width; x++)
                {
                    if (map.Get(x, y)?.Value == 1)
                    {
                        graphics.FillRectangle(new SolidBrush(Color.Brown), x * Scale, y * Scale, Scale, Scale);
                    }
                    else
                    {
                        graphics.FillRectangle(new SolidBrush(Color.Blue), x * Scale, y * Scale, Scale, Scale);
                    }
                }
            }
            return bitmap;
        }


    }
}
