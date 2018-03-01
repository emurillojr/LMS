using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Tyler_MVC.Models
{
    public class RatingFactory : DbContext
    {
        public DbSet<Rating> Ratings { get; set; }
        //Default construtor
        public RatingFactory() : base("name=DefaultConnection") //Initializes DB
        {
            Database.SetInitializer(new RatingInitializer());
        }

        public class RatingInitializer : DropCreateDatabaseIfModelChanges<RatingFactory>
        {
            protected override void Seed(RatingFactory context) //Method to seed the tables with sample data
            {
                base.Seed(context);
                //context.Ratings.Add(new Rating() { RatingName = "G", RatingDesc = "General Audiences." });
                //context.Ratings.Add(new Rating() { RatingName = "PG", RatingDesc = "Parental Guidance Suggested." });
                //context.Ratings.Add(new Rating() { RatingName = "PG-13", RatingDesc = "Parents Strongly Cautioned." });
                //context.Ratings.Add(new Rating() { RatingName = "R", RatingDesc = "Restricted. Under 17 requires accompanying parent or adult guardian." });
                //context.Ratings.Add(new Rating() { RatingName = "NC-17", RatingDesc = "Adults Only. No One 17 and Under Admitted." });

                //context.Ratings.Add(new Rating() { RatingName = "TV-Y7", RatingDesc = "This program is designed for children age 7 and above." });
                //context.Ratings.Add(new Rating() { RatingName = "TV-G", RatingDesc = "Most parents would find this program suitable for all ages." });
                //context.Ratings.Add(new Rating() { RatingName = "TV-PG", RatingDesc = "Parental guidance is recommended; these programs may be unsuitable for younger children." });
                //context.Ratings.Add(new Rating() { RatingName = "TV-14", RatingDesc = "This program contains some material that many parents would find unsuitable for children under 14 years of age." });
                //context.Ratings.Add(new Rating() { RatingName = "TV-MA", RatingDesc = "This program is intended to be viewed by adults and therefore may be unsuitable for children under 17." });
            }
        }
    }
}