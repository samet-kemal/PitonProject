using PitonProject.Models.Base;
using System;

namespace PitonProject.Models
{
    public class Todo:BaseEntity
    {
        public string TodoType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
