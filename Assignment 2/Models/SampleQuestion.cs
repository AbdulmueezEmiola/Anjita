using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_2.Models
{
    public class SampleQuestion
    {
        [Key]
        public int QuestionId { get; set; }

        [Required(ErrorMessage ="A question is needed")]
        public string Question { get; set; }

        public string Option1 { get; set; }

        public string Option2 { get; set; }

        public string Option3 { get; set; }

        public string  Option4 { get; set; }

        [Range(1,4)]
        public int CorrectAnswer { get; set; }

    }
}
