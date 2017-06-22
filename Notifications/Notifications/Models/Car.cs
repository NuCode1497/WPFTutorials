using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Notifications.Models
{
    public class Car : INotifyPropertyChanged
    {
        private int _carId;
        private string _make;
        private string _color;
        private string _petName;
        private bool _isChanged;

        public int CarId
        {
            get { return _carId; }
            set
            {
                if (value == _carId) return;
                _carId = value;
                OnPropertyChanged();
            }
        }
        public string Make
        {
            get { return _make; }
            set
            {
                if (value == _make) return;
                _make = value;
                OnPropertyChanged();
            }
        }
        public string Color
        {
            get { return _color; }
            set
            {
                if (value == _color) return;
                _color = value;
                OnPropertyChanged(nameof(Color));
            }
        }
        public string PetName
        {
            get { return _petName; }
            set
            {
                if (value == _petName) return;
                _petName = value;
                OnPropertyChanged();
            }
        }

        public bool IsChanged
        {
            get { return _isChanged; }
            set
            {
                if (value == IsChanged) return;
                _isChanged = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        internal void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (propertyName != nameof(IsChanged)) IsChanged = true;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
