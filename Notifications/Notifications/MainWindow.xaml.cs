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
using Notifications.Models;
using System.Collections.ObjectModel;

namespace Notifications
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //readonly Inventory _inventory;
        readonly ObservableCollection<Car> _inventory;
        public MainWindow()
        {
            InitializeComponent();

            //_inventory = new Inventory(new List<Car>
            _inventory = new ObservableCollection<Car>
            {
                new Car {CarId=1,Color="Blue",Make="Chevy",PetName="Kit",IsChanged=false},
                new Car {CarId=2,Color="Red",Make="Ford",PetName="Red Rider",IsChanged=false},
            };
            //});
            cboCars.ItemsSource = _inventory;
        }

        private void btnAddCar_Click(object sender, RoutedEventArgs e)
        {
            var maxCount = _inventory?.Max(x => x.CarId) ?? 0;
            _inventory.Add(new Car { CarId = ++maxCount, Color = "Yellow", Make = "VW", PetName = "Birdie" });
        }

        private void btnChangeColor_Click(object sender, RoutedEventArgs e)
        {
            var car = _inventory.FirstOrDefault(x => x.CarId == ((Car)cboCars.SelectedItem)?.CarId);
            if (car != null) car.Color = "Pink";
        }

        private void btnRemoveCar_Click(object sender, RoutedEventArgs e)
        {
            _inventory.RemoveAt(0);
        }
    }
}
