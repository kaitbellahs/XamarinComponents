using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace TestCompenents.sharedComponents
{
    public enum ValidationModes
    {
        Email,
        MinMax
    }

    public partial class TextField : BaseController
    {
        public TextField()
        {
            InitializeComponent();


            TextEntry.TextChanged += (s, e) =>
            {
                bool isTextValid = this.Validate(e.NewTextValue);
                InvalidTextLabel.IsVisible = !isTextValid;
                if (isTextValid) this.Text = e.NewTextValue;
            };
        }



        private bool Validate(string text)
        {
            switch (this.ValidMode)
            {
                case ValidationModes.Email:
                    //Poor man's email validation here... :-)
                    return text.Contains("@") && text.Contains(".");
                case ValidationModes.MinMax:
                    return text.Length >= this.Min && text.Length <= this.Max;
                default:
                    return false;
            }
        }

        public ValidationModes ValidMode { get; set; }

        public int Min { get; set; }
        public int Max { get; set; }

        public string InvalidText
        {
            get { return InvalidTextLabel.Text; }
            set { InvalidTextLabel.Text = value; }
        }

        public string Header
        {
            get { return HeaderLabel.Text; }
            set { HeaderLabel.Text = value; }
        }

        [Obsolete]
        public static readonly BindableProperty TextProperty = BindableProperty.Create<TextField, string>(p => p.Text, null, propertyChanged: OnTextChanged);

        private static void OnTextChanged(BindableObject bindable, string oldvalue, string newvalue)
        {
            TextField origin = (TextField)bindable;
            Entry textBox = origin.FindByViewPrivate<Entry>("TextEntry");
            textBox.Text = newvalue;
        }

        [Obsolete]
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

    }
}
