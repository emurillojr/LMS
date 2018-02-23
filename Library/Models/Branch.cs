using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Branch
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Telephone Number is required")]
        public string Telephone { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Open Date is required")]
        public DateTime OpenDate { get; set; } // when branch was founded
        public virtual IEnumerable<Patron> Patrons { get; set; } // collection of patrons that belong to that library branch
        public virtual IEnumerable<Asset> LibraryAssets { get; set; } // collection of Library assets that belong to that library branch
        public string ImageUrl { get; set; }
    }
}
