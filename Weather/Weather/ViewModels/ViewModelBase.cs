using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.ViewModels
{

    /// <summary>
    /// Base class for all View Models.
    /// </summary>
    public class ViewModelBase : System.ComponentModel.INotifyPropertyChanged {

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;    

        public ViewModelBase() {}
        
        protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}
