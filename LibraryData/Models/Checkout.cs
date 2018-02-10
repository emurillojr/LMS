using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryData.Models
{
    public class Checkout  // used to store a checkout on a LibraryAsset
    {
        public int Id { get; set; }

        [Required]
        public LibraryAsset LibraryAsset { get; set; }  // book or video
        public LibraryCard LibraryCard { get; set; } // one to one relationship with patron
        public DateTime Since { get; set; } // when asset was checked out / due
        public DateTime Until { get; set; } // when asset was checked out / due
    }
}
