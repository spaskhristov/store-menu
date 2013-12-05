using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace RestaurantOrderingSystem.UI
{
    //using MVVM Design Pattern
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public ViewModelBase()
        {
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
