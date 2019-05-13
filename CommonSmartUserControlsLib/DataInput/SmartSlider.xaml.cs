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



        public int Minimum
        {
            get { return (int)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Minimum.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinimumProperty =
            DependencyProperty.Register(nameof(Minimum), typeof(int), typeof(SmartSlider), new PropertyMetadata(0));


        public int Maximum
        {
            get { return (int)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Maximum.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register(nameof(Maximum), typeof(int), typeof(SmartSlider), new PropertyMetadata(100));




        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(nameof(Text), typeof(string), typeof(SmartSlider), new PropertyMetadata("Value:"));




        public Visibility LabelVisibility
        {
            get { return (Visibility)GetValue(LabelVisibilityProperty); }
            set { SetValue(LabelVisibilityProperty, value); }
        }
        // Using a DependencyProperty as the backing store for LabelVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelVisibilityProperty =
            DependencyProperty.Register(nameof(LabelVisibility), typeof(Visibility), typeof(SmartSlider), new PropertyMetadata(Visibility.Collapsed));



        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set {
                if (value > Maximum)
                    value = Maximum;
                else if (value < Minimum)
                    value = Minimum;
                SetValue(ValueProperty, value);
            }
        }
        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(nameof(Value), typeof(int), typeof(SmartSlider),
                new PropertyMetadata(0, new PropertyChangedCallback(ValueChanged)));
        private static void ValueChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs args)
        {
            SmartSlider smartSlider = (SmartSlider)depObj;
            Slider slider = smartSlider.CentralSlider;
            slider.Value = (int)args.NewValue;
        }

        private void MinusBtn_Click(object sender, RoutedEventArgs e)
        {
            Value--;
        }

        private void PlusBtn_Click(object sender, RoutedEventArgs e)
        {
            Value++;
        }

        private void Grid_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
                Value++;
            else if (e.Delta < 0)
                Value--;
        }
    }
}
