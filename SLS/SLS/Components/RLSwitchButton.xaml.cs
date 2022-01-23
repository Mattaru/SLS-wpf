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

namespace SLS.Components
{
    /// <summary>
    /// Interaction logic for RLSwitchButton.xaml
    /// </summary>
    public partial class RLSwitchButton : UserControl
    {
        #region Icon

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register(
                nameof(Icon),
                typeof(string),
                typeof(RLSwitchButton),
                new PropertyMetadata(default(string)));

        public string Icon
        {
            get => (string)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        #endregion

        #region IsChecked

        public static readonly DependencyProperty IsCheckedProperty =
            DependencyProperty.Register(
                nameof(IsChecked),
                typeof(bool),
                typeof(RLSwitchButton),
                new PropertyMetadata(default(bool)));

        public bool IsChecked
        {
            get => (bool)GetValue(IsCheckedProperty);
            set => SetValue(IsCheckedProperty, value);
        }

        #endregion

        #region Command

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register(
                nameof(Command),
                typeof(ICommand),
                typeof(RLSwitchButton),
                new PropertyMetadata(null));

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        #endregion

        public RLSwitchButton()
        {
            InitializeComponent();
        }
    }
}
