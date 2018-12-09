using System;
using Autofac;
using DependencyInjectionExamples.Factories;
using DependencyInjectionExamples.Interfaces;
using DependencyInjectionExamples.Repositories;
using DependencyInjectionExamples.Services;
using DependencyInjectionExamples.ViewModels;
using DependencyInjectionExamples.Views;
using Xamarin.Forms;

namespace DependencyInjectionExamples
{
    public class DependencyInjectionModule : Module
    {
        public DependencyInjectionModule()
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            //Navigation
            builder.Register(context => Application.Current.MainPage.Navigation).SingleInstance();

            //Views
            builder.RegisterType<MainPage>().SingleInstance();
            builder.RegisterType<ProfilePage>().SingleInstance();
            builder.RegisterType<NotificationPage>().SingleInstance();
            builder.RegisterType<FunPage>().SingleInstance();

            //Repositories
            builder.RegisterType<UserRepository>().As<IUserRepository>().SingleInstance();
            builder.RegisterType<NotificationRepository>().As<INotificationRepository>().SingleInstance();

            //ViewModels
            builder.RegisterType<UserViewModel>();
            builder.RegisterType<MainViewModel>();
            builder.RegisterType<NotificationViewModel>();
            builder.RegisterType<FunViewModel>();

            //Services
            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            builder.RegisterType<SettingsService>().As<ISettingsService>().SingleInstance();

            //Factories
            builder.RegisterType<ViewFactory>().As<IViewFactory>().SingleInstance();
        }
    }
}
