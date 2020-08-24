using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_3.Models
{
    public class EmailModel
    {
        [Key]
        public int EmailId { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
