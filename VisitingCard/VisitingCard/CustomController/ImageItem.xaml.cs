using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VisitingCard.CustomController
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageItem : Frame
    {
        public ImageItem()
        {
            InitializeComponent();
        }
        public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(
           propertyName: nameof(ImageSource),
           returnType: typeof(string),
           declaringType: typeof(ImageItem),
           defaultValue: String.Empty,
           defaultBindingMode: BindingMode.OneWay
           );
        public string ImageSource
        {
            get
            { return (string)GetValue(ImageSourceProperty); }
            set
            {
                SetValue(ImageSourceProperty, value);
            }
        }
        public static readonly BindableProperty TextProperty = BindableProperty.Create(
           propertyName: nameof(Text),
           returnType: typeof(string),
           declaringType: typeof(ImageItem),
           defaultValue: String.Empty,
           defaultBindingMode: BindingMode.OneWay
           );
        public string Text
        {
            get
            { return (string)GetValue(TextProperty); }
            set
            {
                SetValue(TextProperty, value);
            }
        }
        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == ImageSourceProperty.PropertyName)
            {
                image.Source = ImageSource;
            }
            else if ( propertyName == TextProperty.PropertyName)
            {
                lbl.Text = Text;
            }
        }
    }
}