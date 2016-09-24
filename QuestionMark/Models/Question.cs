using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuestionMark.Models
{
    public enum Status
    {
        Awaiting,
        Answered,
        TurnedDown
    }

    public class Question
    {
        public int QuestionID { get; set; }
        public string Content { get; set; }
        public string Answer { get; set; }
        public DateTime PublishedAt { get; set; }
        public Status Status { get; set; }

        public int TopicID { get; set; }
        public virtual Topic Topic { get; set; }

        public string UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual ApplicationUser User { get; set; }
    }
}