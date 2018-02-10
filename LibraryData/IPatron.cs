using LibraryData.Models; // Patron
using System.Collections.Generic;

namespace LibraryData
{
    public interface IPatron
    {
        Patron Get(int id); // return a patron by id ( by primary key )
        IEnumerable<Patron> GetAll(); // returns collection of all patrons
        void Add(Patron newPatron); // // add a patron to db
        IEnumerable<Checkout> GetCheckouts(int patronId);
        IEnumerable<CheckoutHistory> GetCheckoutHistory(int patronId);
        IEnumerable<Hold> GetHolds(int patronId);
    }
}
