using System;
using DependencyInjectionExamples.iOS.Renderers;
using DependencyInjectionExamples.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomSearchBar), typeof(CustomiOSSearchBarRenderer))]
namespace DependencyInjectionExamples.iOS.Renderers
{
    public class CustomiOSSearchBarRenderer : SearchBarRenderer
    {
        public CustomiOSSearchBarRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);

            UISearchBar bar = this.Control;

            bar.SearchBarStyle = UISearchBarStyle.Minimal;
            bar.AutocapitalizationType = UITextAutocapitalizationType.None;
            bar.AutocorrectionType = UITextAutocorrectionType.No;
            bar.KeyboardType = UIKeyboardType.ASCIICapable;
            bar.TintColor = UIColor.FromRGB(74, 100, 172); //Different tint colors to show the renderer is working properly on both platforms.

            if (e.NewElement != null)
            {
                e.NewElement.TextColor = Color.FromRgb(74, 100, 172);
                e.NewElement.CancelButtonColor = Color.FromRgb(74, 100, 172);
            }
        }
    }
}
