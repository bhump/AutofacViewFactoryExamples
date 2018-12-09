using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DependencyInjectionExamples.Interfaces;

namespace DependencyInjectionExamples.ViewModels
{
    public class BaseViewModel : IViewModel
    {
        public BaseViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
