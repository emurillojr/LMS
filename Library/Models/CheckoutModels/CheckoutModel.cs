using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.CheckoutModels
{
    public class CheckoutModel
    {
        public string LibraryCardId { get; set; }
        public string Title { get; set; } // title of asset book or video
        public int AssetId { get; set; } // id of asset book or video
        public string ImageUrl { get; set; }
        public int HoldCount { get; set; } // # of patrons who have a hold on asset
        public bool IsCheckedOut { get; set; } // if item is checked out or not
    }
}
