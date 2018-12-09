using System;
using System.Collections.Generic;
using Autofac;
using DependencyInjectionExamples.Interfaces;
using Xamarin.Forms;

namespace DependencyInjectionExamples.Factories
{
    public class ViewFactory : IViewFactory
    {
        private readonly Dictionary<Type, Type> _map = new Dictionary<Type, Type>();
        private readonly IComponentContext _componentContext;

        public ViewFactory(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }

        void IViewFactory.Register<TViewModel, TView>()
        {
            _map[typeof(TViewModel)] = typeof(TView);
        }

        Page IViewFactory.Resolve<TViewModel>()
        {
            TViewModel viewModel = _componentContext.Resolve<TViewModel>();

            var viewType = _map[typeof(TViewModel)];
            var view = _componentContext.Resolve(viewType) as Page;

            view.BindingContext = viewModel;

            return view;
        }
    }
}
