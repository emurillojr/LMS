using System.ComponentModel.DataAnnotations;

namespace LibraryData.Models
{
    public class Video : LibraryAsset   // video is a library asset, inherits LibraryAsset
    {
        [Required]
        public string Director { get; set; }
    }
}
