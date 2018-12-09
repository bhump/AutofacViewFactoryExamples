using System;
using System.Threading.Tasks;

namespace DependencyInjectionExamples.Interfaces
{
    public interface INavigationService
    {
        Task PopAsync();

        Task PopModalAsync();

        Task PopToRootAsync();

        Task PushAsync<TViewModel>() where TViewModel : class, IViewModel;

        Task PushModalAsync<TViewModel>(bool withNavigationPage = true) where TViewModel : class, IViewModel;
    }
}
