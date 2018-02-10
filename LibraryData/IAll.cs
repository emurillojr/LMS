using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData
{
    public interface IAll
    {
        IEnumerable<Patron> GetAllPatrons(); // returns collection of all patrons
        IEnumerable<LibraryBranch> GetAllLibraryBranches(); // get all librbary branches
        IEnumerable<LibraryAsset> GetAllLibraryAssets(); // returns a collection of all of the assets
    }
}
