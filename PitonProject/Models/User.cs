using PitonProject.Models.Base;

namespace PitonProject.Models
{
    public class User:BaseEntity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
