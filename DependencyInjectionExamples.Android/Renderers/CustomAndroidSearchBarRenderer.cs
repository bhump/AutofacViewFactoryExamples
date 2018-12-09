using System;
using Android.Content;
using Android.Text;
using Android.Widget;
using DependencyInjectionExamples.Droid.Renderers;
using DependencyInjectionExamples.Renderers;
using Xamarin.Forms;
using G = Android.Graphics;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomSearchBar), typeof(CustomAndroidSearchBarRenderer))]
namespace DependencyInjectionExamples.Droid.Renderers
{
    public class CustomAndroidSearchBarRenderer : SearchBarRenderer
    {
        public CustomAndroidSearchBarRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);

            // Get native control (background set in shared code, but can use SetBackgroundColor here)
            SearchView searchView = (base.Control as SearchView);
            searchView.SetInputType(InputTypes.ClassText | InputTypes.TextVariationNormal);

            // Access search textview within control
            int textViewId = searchView.Context.Resources.GetIdentifier("android:id/search_src_text", null, null);
            EditText textView = (searchView.FindViewById(textViewId) as EditText);

            // Set custom colors
            textView.SetBackgroundColor(G.Color.Rgb(225, 225, 225));
            textView.SetTextColor(G.Color.Rgb(74, 189, 172));
            textView.SetHintTextColor(G.Color.Rgb(211, 211, 211));

            // Customize frame color
            int frameId = searchView.Context.Resources.GetIdentifier("android:id/search_plate", null, null);
            Android.Views.View frameView = (searchView.FindViewById(frameId) as Android.Views.View);
            //frameView.SetBackgroundColor(G.Color.Rgb(255, 255, 255));
        }

        void Background_PropertyChanged(object sender, PropertyChangingEventArgs eventArgs)
        {
            SearchView searchView = (base.Control as SearchView);
            searchView.SetInputType(InputTypes.ClassText | InputTypes.TextVariationNormal);

            int frameId = searchView.Context.Resources.GetIdentifier("android:id/search_plate", null, null);

            if (eventArgs.PropertyName == "IsdarkThemEnabled")
            {
                var isDarkTheme = false; //(App.Current as App).IsDarkThemeEnabled; //Can be set from the app from settings, but just set to false for now

                Android.Views.View frameView = (searchView.FindViewById(frameId) as Android.Views.View);

                if (isDarkTheme)
                {
                    frameView.SetBackgroundColor(G.Color.Rgb(51, 48, 46));
                }
                else
                {
                    frameView.SetBackgroundColor(G.Color.Rgb(250, 250, 250));
                }
            }
        }
    }
}
