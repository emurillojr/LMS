using System;

namespace LibraryData.Models
{
    public class Patron
    {
        public int Id { get; set; } // primary key
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string TelephoneNumber { get; set; }

        public virtual LibraryCard LibraryCard { get; set; } // foriegn key   virtual for lazy load
        public virtual LibraryBranch HomeLibraryBranch { get; set; } // foriegn key   virtual for lazy load
    }
}
