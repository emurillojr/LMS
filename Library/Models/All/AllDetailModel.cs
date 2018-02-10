using LibraryData.Models;
using System;
using System.Collections.Generic;


namespace Library.Models.All
{
    public class AllDetailModel
    {

        // Patron
        public string PatronFirstName { get; set; }
        public string PatronLastName { get; set; }
        public string PatronFullName
        {
            get { return PatronFirstName + " " + PatronLastName; }
        }

        // Branch
        public string BranchName { get; set; }

        // Library Assets
        public string AssetTitle { get; set; }
        public string AssetType { get; set; }
    }
}