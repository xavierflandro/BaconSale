using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BaconSale.Models
{
    public class Movie
    {
        //  Properties of the Movie class, gettters and setters
        //  all but Edited, LentTo, and Notes are required
        //  Notes prop has a max char length of 25 with associated error message
        [Required]
        public string Category { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        public bool Edited { get; set; }

        public string LentTo { get; set; }

        [StringLength(25, MinimumLength = 0, ErrorMessage = "Notes must be 25 characters or less.")]
        public string Notes { get; set; }
    }
}
