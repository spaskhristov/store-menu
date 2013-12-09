using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace RestaurantOrderingSystem
{
    //using MVVM Design Pattern
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public ViewModelBase()
        {
        }

        //private string _colorString = "Red";
        //public string ColorString
        //{
        //    get { return _colorString; }
        //    set
        //    {
        //        if (_colorString != value)
        //        {
        //            _colorString = value;
        //            OnPropertyChanged("ColorString");
        //        }
        //    }
        //}

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
