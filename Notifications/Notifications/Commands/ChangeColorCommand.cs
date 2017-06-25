using Notifications.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Notifications.Commands
{
    internal class ChangeColorCommand : CommandBase
    {
        public override bool CanExecute(object parameter) => (parameter as Car) != null;

        public override void Execute(object parameter)
        {
            ((Car)parameter).Color = "Pink";
        }
    }
}
