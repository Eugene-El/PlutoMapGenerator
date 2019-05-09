using IslandMapGenerationLib.Generators;
using MapVisualizationLib;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlutoMapGenerationModels
{
    public class MainModel : BindableBase
    {
        private MapVisualizator _mapVisualizator = new MapVisualizator();
        private BorderValuesIslandMapGenerator _mapGenerator = new BorderValuesIslandMapGenerator() { };

        public void GetImage()
        {
            MapImage = _mapVisualizator.Visualize(_mapGenerator.Generate(100, 100));
            RaisePropertyChanged(nameof(MapImage));
        }

        public Bitmap MapImage { get; private set; }

        public int Scale {
            get { return _mapVisualizator.Scale; }
            set
            {
                _mapVisualizator.Scale = value;
                RaisePropertyChanged(nameof(Scale));
            }
        }

        private int _width;
        private int _height;
        public int Width
        {
            get { return _width; }
            set
            {
                _width = value;
                RaisePropertyChanged(nameof(Width));
            }
        }
        public int Height
        {
            get { return _height; }
            set
            {
                _height = value;
                RaisePropertyChanged(nameof(Height));
            }
        }
    }
}
