using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using DependencyInjectionExamples.Interfaces;
using DependencyInjectionExamples.Views;
using Xamarin.Forms;

namespace DependencyInjectionExamples.Services
{
    public class NavigationService : INavigationService
    {
        private readonly Lazy<INavigation> _navigationLazy;
        private readonly IViewFactory _viewFactory;

        private INavigation _navigation
        {
            get { return _navigationLazy.Value; }
        }

        public NavigationService(Lazy<INavigation> navigation, IViewFactory viewFactory)
        {
            _navigationLazy = navigation;
            _viewFactory = viewFactory;
        }

        public async Task PopAsync()
        {
            await _navigation.PopAsync();
        }

        public async Task PopModalAsync()
        {
            await _navigation.PopModalAsync();
        }

        public async Task PopToRootAsync()
        {
            await _navigation.PopToRootAsync();
        }

        public async Task PushAsync<TViewModel>() where TViewModel : class, IViewModel
        {
            var view = _viewFactory.Resolve<TViewModel>();
            await _navigation.PushAsync(view);
        }

        public async Task PushModalAsync<TViewModel>(bool withNavigationPage = true) where TViewModel : class, IViewModel
        {
            var view = _viewFactory.Resolve<TViewModel>();
            
            if (withNavigationPage)
            {
                view = new NavigationPage(view);
            }

            await _navigation.PushModalAsync(view);
        }
    }
}