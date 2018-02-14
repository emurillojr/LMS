using System.ComponentModel.DataAnnotations;

namespace Library.Models.Items
{
    public class Book : Asset   // book is a library asset, inherits LibraryAsset
    {
        [Required]
        public string ISBN { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string DeweyIndex { get; set; }
    }
}
