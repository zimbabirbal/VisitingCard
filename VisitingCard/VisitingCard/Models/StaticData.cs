using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace VisitingCard.Models
{
    public class StaticData
    {
        public static ObservableCollection<CardItem> cardItems = new ObservableCollection<CardItem>();
    }
}
