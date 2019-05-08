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

        public DelegateCommand Generate { get; private set; }
        public BitmapSource MapImage => _mainModel.MapImage?.ToBitmapImage();
    }
}
