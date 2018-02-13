using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.ViewModels.Branch
{
    public class BranchIndexModel
    {
        public IEnumerable<BranchDetailModel> Branches { get; set; }
    }
}
