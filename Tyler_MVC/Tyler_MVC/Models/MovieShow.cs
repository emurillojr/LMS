using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Tyler_MVC.Models
{
    public class MovieShow
    {
        //This is where the db logic goes
        //ID, title, img url, rating, movies/show(bit)
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        public string ImageName { get; set; }

        [Required(ErrorMessage = "Type is required")]
        public int Type { get; set; }  //if move value is 1 : if show value is 2//

        
        [Required(ErrorMessage = "Company is required")]
        public int CompanyId { get; set; }
        public Company CompanyName { get; set; }  // foriegn key relationship between Library asset in a certain branch


        [Required(ErrorMessage = "Rating is required")]
        public int RatingId { get; set; }
        public Rating RatingName { get; set; }  // foriegn key relationship between Library asset in a certain branch



    }
}