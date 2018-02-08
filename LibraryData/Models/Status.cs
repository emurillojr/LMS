using System.ComponentModel.DataAnnotations;

namespace LibraryData.Models
{
    public class Status // for Library assets aka books, videos for the status of them  ex. hold, checked out, checked in
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
