namespace Library.ViewModels.Asset
{
    public class AssetIndexListingModel
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string AuthorOrDirector { get; set; }
        public string ISBN { get; set; }
        public string DeweyCallNumber { get; set; }
        public int LocationId { get; set; }
        public string CurrentLocation { get; set; }
    }
}
