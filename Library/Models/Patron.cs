using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Patron
    {
        public int Id { get; set; } // mapped to primary key on SQL table
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string TelephoneNumber { get; set; }
        [ForeignKey("Branch")]
        public int HomeLibraryBranchId { get; set; }
        public Branch HomeLibraryBranch { get; set; } // foreign key virtual for lazy loading - https://msdn.microsoft.com/en-us/library/jj574232(v=vs.113).aspx
    }
}
