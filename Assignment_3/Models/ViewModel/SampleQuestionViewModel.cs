using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_3.Models.ViewModel
{
    public class SampleQuestionViewModel
    {
        public SampleQuestion SampleQuestion { get; set; }
        public int QuestionNumber { get; set; }
        public bool ShowPrev { get; set; }
        public bool ShowNext { get; set; }
        public int Answer { get; set; }
    }
}
