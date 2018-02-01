using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryData.Models
{
    public class LibraryCard
    {
        public int Id { get; set; }

        public decimal Fees { get; set; } // overdue fees

        public DateTime Created { get; set; } // created date

        public virtual IEnumerable<Checkout> Checkouts { get; set; } // collection of checkouts for library card
    }
}
