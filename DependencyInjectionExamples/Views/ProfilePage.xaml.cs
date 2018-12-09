using System;
using System.Collections.Generic;
using CommonServiceLocator;
using DependencyInjectionExamples.ViewModels;
using Xamarin.Forms;

namespace DependencyInjectionExamples.Views
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();

            BindingContext = ServiceLocator.Current.GetInstance(typeof(UserViewModel));
        }
    }
}
