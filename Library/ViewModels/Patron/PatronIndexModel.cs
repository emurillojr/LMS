using System.Collections.Generic;

namespace Library.ViewModels.Patron
{
    public class PatronIndexModel
    {
        public IEnumerable<PatronDetailModel> Patrons { get; set; }
    }
}
