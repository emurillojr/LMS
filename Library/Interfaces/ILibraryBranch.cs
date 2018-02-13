using Library.Models;
using Library.Models.Asset;
using System.Collections.Generic;

namespace Library.Interfaces
{
    public interface ILibraryBranch
    {
        IEnumerable<LibraryBranch> GetAll(); // get all librbary branches
        IEnumerable<Patron> GetPatrons(int branchId); // get all patrons by home library branch by branch id
        IEnumerable<LibraryAsset> GetAssets(int branchId); // get librbary assets for a certain branch
        LibraryBranch Get(int branchId); // get library branch
    }
}
