using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_3.Models
{
    public class UserAnswer
    {
        [Key]
        public int AnswerId{get;set;}
        public int QuestionId { get; set; }
        public int Answer { get; set; }
        public string EmailAddress { get; set; }
    }
}
