using System;

namespace LibraryData.Models
{
    public class Patron 
    {
        // properties
        public int Id { get; set; } // mapped to primary key on SQL table
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string TelephoneNumber { get; set; }

        public virtual LibraryCard LibraryCard { get; set; } // foreign key virtual for lazy loading - https://msdn.microsoft.com/en-us/library/jj574232(v=vs.113).aspx
        public virtual LibraryBranch HomeLibraryBranch { get; set; } // foreign key virtual for lazy loading - https://msdn.microsoft.com/en-us/library/jj574232(v=vs.113).aspx
    }

    
}
