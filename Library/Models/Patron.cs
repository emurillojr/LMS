using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Patron
    {
        public int Id { get; set; } // mapped to primary key on SQL table
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Date Of Birth is required")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Telephone Number is required")]
        public string TelephoneNumber { get; set; }
        [ForeignKey("Branch")]
        [Required(ErrorMessage = "Home Library Branch Code is required")]
        public int HomeLibraryBranchId { get; set; }
        public Branch HomeLibraryBranch { get; set; } // foreign key virtual for lazy loading - https://msdn.microsoft.com/en-us/library/jj574232(v=vs.113).aspx
    }
}
