using PlutoMapGenerationModels;
using PlutoMapGenerationViewModels.Helpers;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PlutoMapGenerationViewModels
{
    public class MainViewModel : BindableBase
    {
        readonly MainModel _mainModel = new MainModel();

        public MainViewModel()
        {
            _mainModel.PropertyChanged += (s, e) => { RaisePropertyChanged(e.PropertyName); };

            Generate = new DelegateCommand(() => _mainModel.GetImage() );
        }

        public int Scale
        {
            get { return _mainModel.Scale; }
            set { _mainModel.Scale = value; }
        }

        public int Width
        {
            get { return _mainModel.Width; }
            set { _mainModel.Width = value; }
        }
        public int Height
        {
            get { return _mainModel.Height; }
            set { _mainModel.Height = value; }
        }

        public bool IsGenerationPosible
        {
            get { return _mainModel.IsGenerationPosible; }
        }

        public DelegateCommand Generate { get; private set; }
        public BitmapSource MapImage => _mainModel.MapImage?.ToBitmapImage();
    }
}
