using LibraryData.Models;
using System.Collections.Generic;

namespace LibraryData
{
    public interface ILibraryAsset
    {
        IEnumerable<LibraryAsset> GetAll(); // returns collection of all assets
        LibraryAsset GetById(int id); // return assset by id
        void Add(LibraryAsset newAsset); // add an asset to db
        string GetAuthorOrDirector(int id); 
        string GetDeweyIndex(int id);
        string GetType(int id);
        string GetTitle(int id);
        string GetIsbn(int id);
        LibraryBranch GetCurrentLocation(int id); // return current location / branch of asset
    }
}
