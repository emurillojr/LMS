namespace Library.ViewModels.Asset
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
        public string CurrentLocation { get; set; }
        public string ImageUrl { get; set; }
    }
}
