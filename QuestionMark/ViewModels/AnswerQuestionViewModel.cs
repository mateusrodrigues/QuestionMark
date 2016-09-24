using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuestionMark.ViewModels
{
    public class AnswerQuestionViewModel
    {
        [Required]
        public int QuestionID { get; set; }

        [Required]
        public string Answer { get; set; }
    }
}