using Library.Models;
using System.Collections.Generic;

namespace Library.Interfaces
{
    public interface IPatron
    {
        Patron Get(int id); // return a patron by id ( by primary key )
        IEnumerable<Patron> GetAll(); // returns collection of all patrons
    }
}
