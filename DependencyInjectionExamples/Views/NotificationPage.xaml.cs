using System;
using System.Collections.Generic;
using CommonServiceLocator;
using DependencyInjectionExamples.ViewModels;
using Xamarin.Forms;

namespace DependencyInjectionExamples.Views
{
    public partial class NotificationPage : ContentPage
    {
        public NotificationPage()
        {
            InitializeComponent();

            BindingContext = ServiceLocator.Current.GetInstance(typeof(NotificationViewModel));
        }
    }
}
