using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Tyler_MVC.Models
{
    public class CompanyFactory : DbContext
    {
        public DbSet<Company> Companys { get; set; }
        //Default construtor
        public CompanyFactory() : base("name=DefaultConnection") //Initializes DB
        {
            Database.SetInitializer(new CompanyInitializer());
        }

        public class CompanyInitializer : DropCreateDatabaseIfModelChanges<CompanyFactory>
        {
            protected override void Seed(CompanyFactory context) //Method to seed the tables with sample data
            {
                base.Seed(context);
                //context.Companys.Add(new Company() { Name = "Netflix" }); //1
                //context.Companys.Add(new Company() { Name = "Hulu" }); // 2
                //context.Companys.Add(new Company() { Name = "Amazon" }); //3

            }

        }
    }
}