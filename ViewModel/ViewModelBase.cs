using System;
using System.ComponentModel;

namespace Remeberme.ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

      

        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class ChangePageEventArgs : EventArgs
    {
        public string GotoPage { get; set; }
    }
}
