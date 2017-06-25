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
using Notifications.Commands;

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

        private ICommand _changeColorCommand = null;
        public ICommand ChangeColorCmd => _changeColorCommand ?? (_changeColorCommand = new ChangeColorCommand());
        private ICommand _RemoveCarCommand = null;
        public ICommand RemoveCarCmd => _RemoveCarCommand ?? (_RemoveCarCommand = new RemoveCarCommand(_inventory));
        private ICommand _addCarCommand = null;
        public ICommand AddCarCmd => _addCarCommand ?? (_addCarCommand = new AddCarCommand(_inventory));
    }
}
