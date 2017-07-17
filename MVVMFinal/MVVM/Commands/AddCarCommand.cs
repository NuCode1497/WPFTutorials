using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLotDAL2.Models;

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
            var maxCount = _inventory?.Select(x => x.CarId).DefaultIfEmpty().Max() ?? 0;
            _inventory?.Add(new Car { CarId = ++maxCount, Color = "Yellow", Make = "VW", CarNickName = "Birdie", IsChanged = false });
        }

        public override bool CanExecute(object parameter) => true;
    }
}
