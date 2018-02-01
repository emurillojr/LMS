using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryData.Models
{
    public class LibraryBranch
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Telephone { get; set; }
        public string Description { get; set; }
        public DateTime OpenDate { get; set; } // when branch was founded

        public virtual IEnumerable<Patron> Patrons { get; set; } // collection that belong to that library branch
        public virtual IEnumerable<LibraryAsset> LibraryAsset { get; set; } // collection that belong to that library branch

        public string ImageUrl { get; set; }
    }
}
