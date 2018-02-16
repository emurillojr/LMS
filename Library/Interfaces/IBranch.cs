using Library.Models;
using System.Collections.Generic;

namespace Library.Interfaces
{
    public interface IBranch
    {
        IEnumerable<Branch> GetAll(); // get all librbary branches
        IEnumerable<Patron> GetPatrons(int branchId); // get all patrons by home library branch by branch id
        IEnumerable<Asset> GetAssets(int branchId); // get librbary assets for a certain branch
        Branch Get(int branchId); // get library branch
        //IEnumerable<Branch> GetAddress(int id);
        //IEnumerable<Branch> GetPhoneNumber(int id);

    }
}
