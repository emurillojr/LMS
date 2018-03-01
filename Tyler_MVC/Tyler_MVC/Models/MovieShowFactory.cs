using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.Entity;

namespace Tyler_MVC.Models
{
    public class MovieShowFactory : DbContext
    {
        public DbSet<MovieShow> MoviesShows { get; set; }
        //Default construtor
        public MovieShowFactory() : base("name=DefaultConnection") //Initializes DB
        {
            Database.SetInitializer(new MovieShowInitializer());
        }

        public class MovieShowInitializer : DropCreateDatabaseIfModelChanges<MovieShowFactory>
        {
            protected override void Seed(MovieShowFactory context) //Method to seed the tables with sample data
            {
                base.Seed(context);
                //context.MoviesShows.Add(new MovieShow() { Title = "The Punisher", ImageName = "/Images/Punisher.jpg", Type = 1, CompanyId = 1, RatingId = 1 });
                //context.MoviesShows.Add(new MovieShow() { Title = "The Punisher", ImageName = "/Images/Punisher.jpg", Type = 1, CompanyId = 1, RatingId = 2 });
                //context.MoviesShows.Add(new MovieShow() { Title = "The Punisher", ImageName = "/Images/Punisher.jpg", Type = 1, CompanyId = 1, RatingId = 3 });
                //context.MoviesShows.Add(new MovieShow() { Title = "The Punisher", ImageName = "/Images/Punisher.jpg", Type = 1, CompanyId = 1, RatingId = 4 });
                //context.MoviesShows.Add(new MovieShow() { Title = "The Punisher", ImageName = "/Images/Punisher.jpg", Type = 1, CompanyId = 1, RatingId = 5 });
                //context.MoviesShows.Add(new MovieShow() { Title = "The Punisher", ImageName = "/Images/Punisher.jpg", Type = 1, CompanyId = 2, RatingId = 1 });
                //context.MoviesShows.Add(new MovieShow() { Title = "The Punisher", ImageName = "/Images/Punisher.jpg", Type = 1, CompanyId = 2, RatingId = 2 });
                //context.MoviesShows.Add(new MovieShow() { Title = "The Punisher", ImageName = "/Images/Punisher.jpg", Type = 1, CompanyId = 2, RatingId = 3 });
                //context.MoviesShows.Add(new MovieShow() { Title = "The Punisher", ImageName = "/Images/Punisher.jpg", Type = 1, CompanyId = 2, RatingId = 4 });
                //context.MoviesShows.Add(new MovieShow() { Title = "The Punisher", ImageName = "/Images/Punisher.jpg", Type = 1, CompanyId = 2, RatingId = 5 });
                //context.MoviesShows.Add(new MovieShow() { Title = "The Punisher", ImageName = "/Images/Punisher.jpg", Type = 1, CompanyId = 3, RatingId = 1 });
                //context.MoviesShows.Add(new MovieShow() { Title = "The Punisher", ImageName = "/Images/Punisher.jpg", Type = 1, CompanyId = 3, RatingId = 2 });
                //context.MoviesShows.Add(new MovieShow() { Title = "The Punisher", ImageName = "/Images/Punisher.jpg", Type = 1, CompanyId = 3, RatingId = 3 });
                //context.MoviesShows.Add(new MovieShow() { Title = "The Punisher", ImageName = "/Images/Punisher.jpg", Type = 1, CompanyId = 3, RatingId = 4 });
                //context.MoviesShows.Add(new MovieShow() { Title = "The Punisher", ImageName = "/Images/Punisher.jpg", Type = 1, CompanyId = 3, RatingId = 5 });

                //context.MoviesShows.Add(new MovieShow() { Title = "Brooklyn 99", ImageName = "/Images/Brooklyn99.jpg", Type = 2, CompanyId = 1, RatingId = 1 });
                //context.MoviesShows.Add(new MovieShow() { Title = "Brooklyn 99", ImageName = "/Images/Brooklyn99.jpg", Type = 2, CompanyId = 1, RatingId = 2 });
                //context.MoviesShows.Add(new MovieShow() { Title = "Brooklyn 99", ImageName = "/Images/Brooklyn99.jpg", Type = 2, CompanyId = 1, RatingId = 3 });
                //context.MoviesShows.Add(new MovieShow() { Title = "Brooklyn 99", ImageName = "/Images/Brooklyn99.jpg", Type = 2, CompanyId = 1, RatingId = 4 });
                //context.MoviesShows.Add(new MovieShow() { Title = "Brooklyn 99", ImageName = "/Images/Brooklyn99.jpg", Type = 2, CompanyId = 1, RatingId = 5 });
                //context.MoviesShows.Add(new MovieShow() { Title = "Brooklyn 99", ImageName = "/Images/Brooklyn99.jpg", Type = 2, CompanyId = 2, RatingId = 1 });
                //context.MoviesShows.Add(new MovieShow() { Title = "Brooklyn 99", ImageName = "/Images/Brooklyn99.jpg", Type = 2, CompanyId = 2, RatingId = 2 });
                //context.MoviesShows.Add(new MovieShow() { Title = "Brooklyn 99", ImageName = "/Images/Brooklyn99.jpg", Type = 2, CompanyId = 2, RatingId = 3 });
                //context.MoviesShows.Add(new MovieShow() { Title = "Brooklyn 99", ImageName = "/Images/Brooklyn99.jpg", Type = 2, CompanyId = 2, RatingId = 4 });
                //context.MoviesShows.Add(new MovieShow() { Title = "Brooklyn 99", ImageName = "/Images/Brooklyn99.jpg", Type = 2, CompanyId = 2, RatingId = 5 });
                //context.MoviesShows.Add(new MovieShow() { Title = "Brooklyn 99", ImageName = "/Images/Brooklyn99.jpg", Type = 2, CompanyId = 3, RatingId = 1 });
                //context.MoviesShows.Add(new MovieShow() { Title = "Brooklyn 99", ImageName = "/Images/Brooklyn99.jpg", Type = 2, CompanyId = 3, RatingId = 2 });
                //context.MoviesShows.Add(new MovieShow() { Title = "Brooklyn 99", ImageName = "/Images/Brooklyn99.jpg", Type = 2, CompanyId = 3, RatingId = 3 });
                //context.MoviesShows.Add(new MovieShow() { Title = "Brooklyn 99", ImageName = "/Images/Brooklyn99.jpg", Type = 2, CompanyId = 3, RatingId = 4 });
                //context.MoviesShows.Add(new MovieShow() { Title = "Brooklyn 99", ImageName = "/Images/Brooklyn99.jpg", Type = 2, CompanyId = 3, RatingId = 5 });

            }
        }
    }
}