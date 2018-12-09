using System;
using System.Threading.Tasks;
using System.Windows.Input;
using DependencyInjectionExamples.Interfaces;
using Xamarin.Forms;

namespace DependencyInjectionExamples.ViewModels
{
    public class FunViewModel : BaseViewModel
    {
        private INavigationService _navigationSerivce;

        public ICommand CloseCommand { get; private set; }

        public string FunText { get { return "I'm some awsome fun text."; } }

        public FunViewModel(INavigationService navigationService)
        {
            _navigationSerivce = navigationService;

            CloseCommand = new Command(async () => await CloseModal());
        }

        private async Task CloseModal()
        {
            await _navigationSerivce.PopModalAsync();
        }
    }
}
