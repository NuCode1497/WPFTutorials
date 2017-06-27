using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM.Models;

namespace MVVM.Commands
{
    internal class AddCarCommand : CommandBase
    {
        private readonly IList<Car> _inventory;

        public AddCarCommand(IList<Car> inventory)
        {
            _inventory = inventory;
        }

        public override void Execute(object parameter)
        {
            var maxCount = _inventory?.Max(x => x.CarId) ?? 0;
            _inventory?.Add(new Car { CarId = ++maxCount, Color = "Yellow", Make = "VW", PetName = "Birdie", IsChanged = false });
        }

        public override bool CanExecute(object parameter) => true;
    }
}
