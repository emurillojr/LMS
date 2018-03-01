using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tyler_MVC.Models;
using Tyler_MVC.ViewModels.Home;

namespace Tyler_MVC.Controllers
{    
    public class MovieShowController : Controller
    {
        private MovieShowFactory Db = new MovieShowFactory();
        // GET: Movies Shows
        public ActionResult NetflixMoviesShowsList(string searchCriteria)
        {
            var factory = new MovieShowFactory();

            //IQueryable<MovieShow> moviesAndShows = factory.MoviesShows.Where(p => p.CompanyId == 1).OrderBy(p => p.Title);

            //if (searchCriteria != null)
            //{
            //    moviesAndShows = moviesAndShows.Where(p => p.Title.Contains(searchCriteria));  // toupper
            //}

            //Create a list of the movies and shows cars from the DB Table
            var moviesAndShowsList = new MoviesShowsListViewModel(factory.MoviesShows);

            return View(moviesAndShowsList);
        }

     
    }
}