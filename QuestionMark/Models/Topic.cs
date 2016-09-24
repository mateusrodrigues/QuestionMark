using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestionMark.Models
{
    public class Topic
    {
        public int TopicID { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}