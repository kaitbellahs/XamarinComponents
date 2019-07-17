using TestCompenents.Droid.Components;
using TestCompenents.sharedComponents;
using Xamarin.Forms;
using Android.Content;
using Xamarin.Forms.Platform.Android;
using Android.Widget;

[assembly: ExportRenderer(typeof(sharedLabel), typeof(CustomLabel))]
namespace TestCompenents.Droid.Components
{
    public class CustomLabel : LabelRenderer
    {
        string text = "This is an android test label";
        public CustomLabel(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            var View = (sharedLabel)Element;
            if (View == null) return;

            Control.SetText(string.IsNullOrEmpty(View.Text) ? text : View.Text, TextView.BufferType.Spannable);
        }
    }
}
