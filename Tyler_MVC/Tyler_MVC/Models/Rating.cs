using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tyler_MVC.Models
{
    public class Rating
    {
        [Key]
        public int RatingId { get; set; }

        [Required(ErrorMessage = "Rating Name is required")]
        public string RatingName { get; set; }

        [Required(ErrorMessage = "Rating Desc is required")]
        public string RatingDesc { get; set; }


        public virtual ICollection<MovieShow> MoviesShows { get; set; }


    }
}