using System;
using System.Threading.Tasks;
using System.Windows.Input;
using DependencyInjectionExamples.Interfaces;
using DependencyInjectionExamples.Views;
using Xamarin.Forms;

namespace DependencyInjectionExamples.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        private IUserRepository _userRepository;

        private IViewFactory _viewFactory;

        private INavigationService _navigationService;

        public ICommand OpenPageCommand { get; private set; }

        public ICommand OpenModalCommand { get; private set; }

        public UserViewModel(IUserRepository userRepository, IViewFactory viewFactory, INavigationService navigationService)
        {
            _userRepository = userRepository;
            _viewFactory = viewFactory;
            _navigationService = navigationService;

            OpenPageCommand = new Command(async () => await OpenNewPage());
            OpenModalCommand = new Command(async () => await OpenModal());
        }

        public string UserName
        {
            get { return _userRepository.GetUserName(); }
        }

        public string Email
        {
            get { return _userRepository.GetEmail(); }
        }

        private async Task OpenNewPage()
        {
            await _navigationService.PushAsync<FunViewModel>();
        }

        private async Task OpenModal()
        {
            await _navigationService.PushModalAsync<FunViewModel>();
        }
    }
}
