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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string[] colors = { "Navy", "Blue", "Aqua", "Teal", "Olive", "Green", "Lime", "Yellow", "Orange", "Red", "Maroon", "Fuchsia", "Purple", "Black", "Silver", "Gray", "White" };
            foreach (string colorName in colors)
            {
                Button btn = new Button()
                {
                    Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(colorName)),
                    Content = colorName,
                    Margin = new Thickness(2),
                    Foreground = Brushes.White
                };
                colorButtons.Children.Add(btn);
            }
        }
    }
}
