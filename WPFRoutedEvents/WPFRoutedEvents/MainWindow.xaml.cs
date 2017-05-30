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

namespace WPFRoutedEvents
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string _mouseActivity = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnClickMe_Click(object sender, RoutedEventArgs e)
        {
            AddEvenetInfo(sender, e);
            MessageBox.Show(_mouseActivity, "Your Event Info");

            _mouseActivity = "";
        }

        private void AddEvenetInfo(object sender, RoutedEventArgs e)
        {
            _mouseActivity += string.Format(
                "{0} sent a {1} event named {2}.\n", sender,
                e.RoutedEvent.RoutingStrategy, e.RoutedEvent.Name);
        }

        private void outerEllipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AddEvenetInfo(sender, e);
        }

        private void outerEllipse_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            AddEvenetInfo(sender, e);
        }
    }
}
