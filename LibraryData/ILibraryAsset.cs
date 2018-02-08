using LibraryData.Models;
using System.Collections.Generic;

namespace LibraryData
{
    public interface ILibraryAsset  // defines the methods that will be required for any service that implements this interface
    {
        IEnumerable<LibraryAsset> GetAll(); // returns a collection of all of the assets
        LibraryAsset GetById(int id); // return individual instance of an asset by id
        void Add(LibraryAsset newAsset); // add a Library asset 
        string GetAuthorOrDirector(int id); 
        string GetDeweyIndex(int id);
        string GetType(int id);
        string GetTitle(int id);
        string GetIsbn(int id);
        LibraryBranch GetCurrentLocation(int id); // return current location / current librbary branch of asset by asset id 
    }
}
