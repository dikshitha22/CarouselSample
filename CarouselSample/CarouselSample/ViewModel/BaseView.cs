using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace CarouselSample.ViewModel
{
   
        public class BaseView : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            public void OnPropertyChanged([CallerMemberName] string name = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }

            protected bool SetProperty<T>(ref T backfield, T value,
                [CallerMemberName]string propertyName = null)
            {
                if (EqualityComparer<T>.Default.Equals(backfield, value))
                {
                    return false;
                }
                backfield = value;
                OnPropertyChanged(propertyName);
                return true;
            }
        }
    
}
