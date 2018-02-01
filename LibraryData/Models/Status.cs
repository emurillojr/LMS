using System.ComponentModel.DataAnnotations;

namespace LibraryData.Models
{
    public class Status // for books, videos  for the status of them 
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
