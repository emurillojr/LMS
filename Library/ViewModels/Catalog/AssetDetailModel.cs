

namespace Library.ViewModels.Catalog
{
    public class AssetDetailModel
    {
        public int AssetId { get; set; }
        public string Title { get; set; }
        public string AuthorOrDirector { get; set; }
        public string Type { get; set; } // book or video
        public int Year { get; set; }
        public string ISBN { get; set; }
        public string DeweyCallNumber { get; set; }
        //public string Status { get; set; } // display for checked out, lost, or available
        //public decimal Cost { get; set; }
        public string CurrentLocation { get; set; }
        public string ImageUrl { get; set; }
        //public string PatronName { get; set; }
        //public Checkout LatestCheckout { get; set; } // checkout object
        //public IEnumerable<CheckoutHistory> CheckoutHistory { get; set; } // set of checkout all patrons have placed on asset
        //public IEnumerable<AssetHoldModel> CurrentHolds { get; set; } // call current holds
    }
    //public class AssetHoldModel
    //{
    //    public string PatronName { get; set; }
    //    public string HoldPlaced { get; set; }
    //}
    
}
