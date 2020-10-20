using Android.Widget;
using IpFinder.Controls;
using IpFinder.Droid.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Application = Android.App.Application;

[assembly: ExportRenderer(typeof(BorderLessSearchBar), typeof(BorderLessSearchBarRender))]
namespace IpFinder.Droid.Renders
{
    public class BorderLessSearchBarRender : SearchBarRenderer
    {
        public BorderLessSearchBarRender() : base(Application.Context)
        {


        }

        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);


            if (this.Control != null)
            {
                LinearLayout linearLayout = this.Control.GetChildAt(0) as LinearLayout;
                linearLayout = linearLayout.GetChildAt(2) as LinearLayout;
                linearLayout = linearLayout.GetChildAt(1) as LinearLayout;
                linearLayout.Background = null;
            }
        }
    }
}