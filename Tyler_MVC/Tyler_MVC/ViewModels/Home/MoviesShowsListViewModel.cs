using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Tyler_MVC.Models;

namespace Tyler_MVC.ViewModels.Home
{
    public class MoviesShowsListViewModel
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageName { get; set; }
        public int Type { get; set; }



        public int CompanyId { get; set; }
        public string CompanyName { get; set; } 

       public int RatingId { get; set; }
        public string RatingName { get; set; }

    }
}