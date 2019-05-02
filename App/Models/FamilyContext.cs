using Microsoft.EntityFrameworkCore;

namespace App.Models
{
    public class FamilyContext: DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public FamilyContext(DbContextOptions<FamilyContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}