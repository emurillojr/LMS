using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string ISBN { get; set; }
        public string Author { get; set; }
        public string DeweyIndex { get; set; }
        [ForeignKey("Branch")]
        public int LocationId { get; set; }
        public Branch Location { get; set; }  // foriegn key relationship between Library asset in a certain branch
    }
}
