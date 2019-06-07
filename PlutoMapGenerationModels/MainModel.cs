using IslandMapGenerationLib.Generators;
using IslandMapGenerationLib.Interfaces;
using MapVisualizationLib;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlutoMapGenerationModels
{
    public class MainModel : BindableBase
    {
        private MapVisualizator _mapVisualizator = new MapVisualizator();
        private IIslandMapGenerator _mapGenerator = new CosinusIslandMapGenerator() { };


        public void GetImage()
        {
            IsGenerationPosible = false;
            Task.Factory.StartNew(() =>
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var map = _mapGenerator.Generate(Width, Height);
                watch.Stop();
                Debug.Print("Map generated in " + watch.ElapsedMilliseconds + " ms");
                watch.Reset();
                watch.Start();
                MapImage = _mapVisualizator.Visualize(map);
                watch.Stop();
                Debug.Print("Map visualized in " + watch.ElapsedMilliseconds + " ms");
                RaisePropertyChanged(nameof(MapImage));
                IsGenerationPosible = true;
            });
        }

        public Bitmap MapImage { get; private set; }


        private bool _isGenerationPosible = true;
        public bool IsGenerationPosible {
            get { return _isGenerationPosible; }
            private set {
                _isGenerationPosible = value;
                RaisePropertyChanged(nameof(IsGenerationPosible));
            }
        }

        public int Scale {
            get { return _mapVisualizator.Scale; }
            set
            {
                _mapVisualizator.Scale = value;
                RaisePropertyChanged(nameof(Scale));
            }
        }

        private int _width = 100;
        private int _height = 100;
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
