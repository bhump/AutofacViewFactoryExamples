using System;
using Autofac;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using DependencyInjectionExamples.Interfaces;
using DependencyInjectionExamples.Services;
using DependencyInjectionExamples.ViewModels;
using DependencyInjectionExamples.Views;
using Xamarin.Forms;

namespace DependencyInjectionExamples
{
    public class Bootstrapper
    {
        public Bootstrapper()
        {
        }

        public static void Initialize()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<DependencyInjectionModule>();
            var container = builder.Build();

            AutofacServiceLocator autofacServiceLocator = new AutofacServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => autofacServiceLocator);

            var viewFactory = container.Resolve<IViewFactory>();

            RegisterViews(viewFactory);

            var page = viewFactory.Resolve<MainViewModel>();
            Application.Current.MainPage = new NavigationPage(page);
        }

        public static void RegisterViews(IViewFactory viewFactory)
        {
            viewFactory.Register<MainViewModel, MainPage>();
            viewFactory.Register<UserViewModel, ProfilePage>();
            viewFactory.Register<NotificationViewModel, NotificationPage>();
            viewFactory.Register<FunViewModel, FunPage>();
        }
    }
}
