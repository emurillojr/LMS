﻿using System.ComponentModel.DataAnnotations;

namespace Library.Models.Items
{
    public class Video : Asset   // video is a library asset, inherits Asset
    {
        [Required]
        public string Director { get; set; }
    }
}
