using Library.ViewModels.Asset;
using System.Collections.Generic;

namespace Library.ViewModels.Asset
{
    public class AssetIndexModel
    {
        public IEnumerable<AssetIndexListingModel> Assets { get; set; }
    }
}
