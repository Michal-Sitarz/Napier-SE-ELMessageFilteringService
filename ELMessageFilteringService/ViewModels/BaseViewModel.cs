using ELMessageFilteringService.Services;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Controls;

namespace ELMessageFilteringService.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnChanged(string propertyChanged)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyChanged));
        }
    }
}
