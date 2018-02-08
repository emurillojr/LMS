﻿using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryData.Models
{
    public class CheckoutHistory // audit table for when item is checked in / out
    {
        public int Id { get; set; }

        [Required]
        public LibraryAsset LibraryAsset { get; set; }

        [Required]
        public LibraryCard LibraryCard { get; set; }

        [Required]
        public DateTime CheckedOut { get; set; }
        public DateTime? CheckedIn { get; set; }
    }
}
