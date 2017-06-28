using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVM.Commands;
using AutoLotDAL2.Models;
using AutoLotDAL2.Repos;

namespace MVVM.ViewModels
{
    class MainWindowViewModel
    {
        public IList<Car> Inventory { get; set; }
        public MainWindowViewModel()
        {
            Inventory = new ObservableCollection<Car>(new CarRepo().GetAll());
        }
        private ICommand _changeColorCommand = null;
        public ICommand ChangeColorCmd => _changeColorCommand ?? (_changeColorCommand = new ChangeColorCommand());
        private ICommand _RemoveCarCommand = null;
        public ICommand RemoveCarCmd => _RemoveCarCommand ?? (_RemoveCarCommand = new RemoveCarCommand(Inventory));
        private ICommand _addCarCommand = null;
        public ICommand AddCarCmd => _addCarCommand ?? (_addCarCommand = new AddCarCommand(Inventory));
    }
}
