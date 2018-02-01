using System;

namespace LibraryData.Models
{
    public class Hold
    {
        public int Id { get; set; }
        public virtual LibraryAsset LibraryAsset { get; set; } // which asset requested
        public virtual LibraryCard LibraryCard { get; set; } // which patrons library card requested hold
        public DateTime HoldPlaced { get; set; } // date hold was placed
    }
}

