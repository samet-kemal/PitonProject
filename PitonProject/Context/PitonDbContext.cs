using Microsoft.EntityFrameworkCore;
using PitonProject.Models;

namespace PitonProject.Context
{
    public class PitonDbContext:DbContext
    {
        public PitonDbContext(DbContextOptions<PitonDbContext> opt) :base(opt)
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<Todo> Todo { get; set; }
    }
}
