using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Task_Management_System.Models.Entites;

namespace Task_Management_System.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUsers>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Tasks> Tasks { get; set; }
    }
}
