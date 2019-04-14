using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitingCard.CustomController;
using VisitingCard.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VisitingCard
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ImageTransition : ContentPage
	{
        public ImageTransition()
        {
            InitializeComponent();
        }
        private async void PickPhoto_Clicked(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                //DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                return;
            }
            var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,

            });


            if (file == null)
                return;

            image.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                //file.Dispose();
                return stream;
            });

            StaticData.cardItems.Add(new CardItem { ImageSource=file.Path, Text=@"Here mine"});
            file.Dispose();

        }

        private async void CapturePhoto_Clicked(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                //DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Test",
                SaveToAlbum = true,
                CompressionQuality = 75,
                CustomPhotoSize = 50,
                PhotoSize = PhotoSize.MaxWidthHeight,
                MaxWidthHeight = 2000,
                DefaultCamera = CameraDevice.Front
            });

            if (file == null)
                return;
            image.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                //file.Dispose();
                return stream;
            });
            //DisplayAlert("File Location", file.Path, "OK");
            StaticData.cardItems.Add(new CardItem { ImageSource = file.Path, Text = @"Here mine" });
            file.Dispose();
        }

        private async void Back_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}