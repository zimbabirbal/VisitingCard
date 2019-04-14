using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitingCard.CustomController;
using VisitingCard.Models;
using VisitingCard.ViewModels;
using Xamarin.Forms;

namespace VisitingCard
{
    public partial class MainPage : ContentPage
    {
        int numCard = 0;
        int gridMode = 0;
        ObservableCollection<CardItem> imageCollection = new ObservableCollection<CardItem>();
        public MainPage()
        {
            InitializeComponent();
            DataSource dataSource = new DataSource();
            imageCollection = dataSource.CollectCardData();
            numCard = imageCollection.Count;
            gridMode = (stklayout.Orientation == StackOrientation.Horizontal) ? Constants.LANDSCAPE_VIEW : Constants.PORTRAIT_VIEW;
            CardItemProjection(imageCollection, numCard, gridMode);

        }

        private void CardItemProjection(ObservableCollection<CardItem> imageCollection, int numCard, int gridMode)
        {
            if (numCard == 0) return;
            var n = (numCard % gridMode) == 0 ? 0 : 1;
            var numRow = numCard < gridMode ? 1 : (n == 0 ? (numCard / gridMode) : (int)numCard / gridMode + 1);
            var numColumn = gridMode;
            var imageCounter = 0;            
            for (int i = 0; i < numRow; i++)
            {
                for (int j = 0; j < numColumn; j++)
                {
                    if (numCard == imageCounter) break;
                    else
                    {
                        var imageItem = new ImageItem
                        {
                            ImageSource = imageCollection[imageCounter].ImageSource,
                            Text = imageCollection[imageCounter].Text + imageCounter.ToString()
                        };
                        imageCounter++;                        
                        imageGrid.Children.Add(imageItem, j, i);
                    }
                }
            }            
        }

        private async void  Next_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ImageTransition());
        }
        //public bool IsPhoto;

    }
}
