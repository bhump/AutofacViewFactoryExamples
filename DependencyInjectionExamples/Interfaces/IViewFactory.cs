using System;
using Xamarin.Forms;

namespace DependencyInjectionExamples.Interfaces
{
    public interface IViewFactory
    {
        void Register<TViewModel, TView>() where TViewModel : class, IViewModel where TView : Page;

        Page Resolve<TViewModel>() where TViewModel : class, IViewModel;
    }
}
