using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tyler_MVC.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "Company Name is required")]
        public string Name { get; set; }

        public virtual ICollection<MovieShow> MoviesShows { get; set; } 
      


    }
}