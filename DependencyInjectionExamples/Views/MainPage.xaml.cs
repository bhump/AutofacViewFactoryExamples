using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyInjectionExamples.Interfaces;
using DependencyInjectionExamples.Repositories;
using DependencyInjectionExamples.ViewModels;
using Xamarin.Forms;

namespace DependencyInjectionExamples.Views
{
    public partial class MainPage : TabbedPage
    {
        public MainPage(UserViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }
    }
}
