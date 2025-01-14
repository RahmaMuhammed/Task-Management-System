using Microsoft.AspNetCore.Identity;

namespace Task_Management_System.Models.Entites
{
    public class ApplicationUser : IdentityUser
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string Address { get; set; }
        public DateOnly DOB {  get; set; }
        public bool IsAgree { get; set; }
        public ICollection<Tasks> Tasks { get; set; }

    }
}
