using LibraryData.Models;
using System.Collections.Generic;

namespace LibraryData
{
    public interface ILibraryBranch
    {
        IEnumerable<LibraryBranch> GetAll(); // get all librbary branches
        IEnumerable<Patron> GetPatrons(int branchId); // get all patrons by home library branch by branch id
        IEnumerable<LibraryAsset> GetAssets(int branchId); // get librbary assets for a certain branch
        LibraryBranch Get(int branchId); // get library branch
        void Add(LibraryBranch newBranch); // add a library branch
        IEnumerable<string> GetBranchHours(int branchId); // get branch hours
        bool IsBranchOpen(int branchId); // returns a book to determine if branch is open
        //int GetAssetCount(IEnumerable<LibraryAsset> libraryAssets);
        //int GetPatronCount(IEnumerable<Patron> patrons);
        //decimal GetAssetsValue(int id);
    }
}
