using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CommonSmartUserControlsLib.DataInput
{
    /// <summary>
    /// Interaction logic for SmartSlider.xaml
    /// </summary>
    public partial class SmartSlider : UserControl
    {
        public SmartSlider()
        {
            InitializeComponent();
        }

        private int _value = 0;
        public int Value
        {
            get { return _value; }
            set
            {
                CentralSlider.Value = _value = value;
            }
        }
    }
}
