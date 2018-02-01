using System.ComponentModel.DataAnnotations;

namespace LibraryData.Models
{
    public class Book : LibraryAsset   // book is a library asset
    {
        [Required]
        public string ISBN { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string DeweyIndex { get; set; }
    }
}
