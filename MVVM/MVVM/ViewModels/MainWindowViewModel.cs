using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM.Models;
using System.Windows.Input;
using MVVM.Commands;

namespace MVVM.ViewModels
{
    class MainWindowViewModel
    {
        public IList<Car> Inventory { get; set; }
        public MainWindowViewModel()
        {
            Inventory = new ObservableCollection<Car>
            {
                new Car {CarId=1,Color="Blue",Make="Chevy",PetName="Kit",IsChanged=false},
                new Car {CarId=2,Color="Red",Make="Ford",PetName="Red Rider",IsChanged=false},
            };
        }
        private ICommand _changeColorCommand = null;
        public ICommand ChangeColorCmd => _changeColorCommand ?? (_changeColorCommand = new ChangeColorCommand());
        private ICommand _RemoveCarCommand = null;
        public ICommand RemoveCarCmd => _RemoveCarCommand ?? (_RemoveCarCommand = new RemoveCarCommand(Inventory));
        private ICommand _addCarCommand = null;
        public ICommand AddCarCmd => _addCarCommand ?? (_addCarCommand = new AddCarCommand(Inventory));
    }
}
