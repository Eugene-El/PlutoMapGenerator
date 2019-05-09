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
                RaisePropertyChanged(nameof(Scale));
                _mapVisualizator.Scale = value;
            }
        }
    }
}
