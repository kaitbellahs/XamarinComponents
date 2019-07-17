using Foundation;
using TestCompenents.iOS.Components;
using TestCompenents.sharedComponents;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(sharedLabel), typeof(CustomLabel))]
namespace TestCompenents.iOS.Components
{
    public class CustomLabel : LabelRenderer
    {
        string text = "This is an iOS test label";

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            var View = (sharedLabel)Element;
            if (View == null) return;

            var Attribute = new NSAttributedStringDocumentAttributes();
            var NsError = new NSError();

            View.Text = string.IsNullOrEmpty(View.Text) ? text : View.Text;

            Control.AttributedText = new NSAttributedString(View.Text, Attribute, ref NsError);

        }
    }
}
