using Library.Models;
using System.Collections.Generic;

namespace Library.Interfaces
{
    public interface IAsset  // defines the methods that will be required for any service that implements this interface
    {
        IEnumerable<Asset> GetAll(); // returns a collection of all of the assets
        Asset GetById(int id); // return individual instance of an asset by id
        string GetAuthorOrDirector(int id); 
        string GetDeweyIndex(int id);
        string GetType(int id);
        string GetTitle(int id);
        string GetIsbn(int id);
        Branch GetCurrentLocation(int id); // return current location / current librbary branch of asset by asset id 
    }
}
