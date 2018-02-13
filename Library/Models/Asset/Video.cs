using System.ComponentModel.DataAnnotations;

namespace Library.Models.Asset
{
    public class Video : LibraryAsset   // video is a library asset, inherits LibraryAsset
    {
        [Required]
        public string Director { get; set; }
    }
}
