using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.Models
{
    [Table("Patron")]
    public class Patron
    {

        
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ContactInformation { get; set; }


        // You can add more properties for tracking patron-related information.

        // If you want to establish a relationship with books, you can add a navigation property like this:
        // public ICollection<Book> Books { get; set; }
    }
}
