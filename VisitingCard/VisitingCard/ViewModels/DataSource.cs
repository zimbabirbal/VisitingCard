using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using VisitingCard.Models;

namespace VisitingCard.ViewModels
{
    public class DataSource
    {              

        public ObservableCollection<CardItem> CollectCardData()
        {
            //StaticData.cardItems.Add(new CardItem { ImageSource = "https://images.unsplash.com/photo-1511823794984-b87716139b88?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&w=1000&q=80", Text = "Pokhara" });
            return StaticData.cardItems;
        }
    }
}
