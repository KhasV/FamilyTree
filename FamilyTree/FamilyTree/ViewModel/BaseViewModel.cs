using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FamilyTree.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string arg)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(arg));
        }
    } 
}
