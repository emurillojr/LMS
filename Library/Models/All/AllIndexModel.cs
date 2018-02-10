using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.All
{
    public class AllIndexModel
    {
        public IEnumerable<AllDetailModel> Alls { get; set; }
        public IEnumerable<AllDetailModel> Alls1 { get; set; }
        public IEnumerable<AllDetailModel> Alls2 { get; set; }

        public List<string> SelectedAssets { get; set; }
        public List<SelectListItem> AssetsList { get; set; }

    }
}
