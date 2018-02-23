using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Asset // books
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Year is required")]
        public int Year { get; set; }
        [Required(ErrorMessage = "Cost is required")]
        public decimal Cost { get; set; }
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Number Of Copies is required")]
        public int NumberOfCopies { get; set; }
        [Required(ErrorMessage = "ISBN is required")]
        public string ISBN { get; set; }
        [Required(ErrorMessage = "Author is required")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Dewey Index is required")]
        public string DeweyIndex { get; set; }
        [ForeignKey("Branch")]
        [Required(ErrorMessage = "Location Code is required")]
        public int LocationId { get; set; }
        public Branch Location { get; set; }  // foriegn key relationship between Library asset in a certain branch
    }
}
