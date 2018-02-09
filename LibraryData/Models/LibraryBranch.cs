using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryData.Models
{
    public class LibraryBranch
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)] // example of how to pass attributes
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Telephone { get; set; }
        public string Description { get; set; }
        public DateTime OpenDate { get; set; } // when branch was founded

        public virtual IEnumerable<Patron> Patrons { get; set; } // collection of patrons that belong to that library branch
        public virtual IEnumerable<LibraryAsset> LibraryAssets { get; set; } // collection of Library assets that belong to that library branch

        public string ImageUrl { get; set; }
    }
}
