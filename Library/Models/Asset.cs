using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Asset // books
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public decimal Cost { get; set; }

        public string ImageUrl { get; set; }

        public int NumberOfCopies { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string DeweyIndex { get; set; }

        public virtual Branch Location { get; set; }  // foriegn key relationship between Library asset in a certain branch
    }
}
