using IdentityExample.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityExample.Data
{
    public class StudentContext : IdentityDbContext<Student>
    {
        public StudentContext(DbContextOptions<StudentContext> options)
            : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<Student> Students { get; set; }
    }
}
