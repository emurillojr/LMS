using System.ComponentModel.DataAnnotations;

namespace LibraryData.Models
{
    public class BranchHours    // used to store the hours that a branch is open
    {
        public int Id { get; set; }
        public LibraryBranch Branch { get; set; }

        [Range(0, 6)]
        public int DayOfWeek { get; set; }

        [Range(0, 23)]
        public int OpenTime { get; set; }

        [Range(0, 23)]
        public int CloseTime { get; set; }
    }
}
