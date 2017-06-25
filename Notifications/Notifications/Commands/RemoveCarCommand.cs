using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notifications.Models;

namespace Notifications.Commands
{
    internal class RemoveCarCommand : CommandBase
    {
        private readonly IList<Car> _inventory;

        public RemoveCarCommand(IList<Car> inventory)
        {
            _inventory = inventory;
        }

        public override bool CanExecute(object parameter) =>
            (parameter as Car) != null && _inventory != null && _inventory.Count != 0;

        public override void Execute(object parameter)
        {
            _inventory.Remove((Car)parameter);
        }
    }
}
