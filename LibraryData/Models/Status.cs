using System.ComponentModel.DataAnnotations;

namespace LibraryData.Models
{
    public class Status // used to store the status of a LibraryAsset ex. hold, checked out, checked in
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
