using Microsoft.EntityFrameworkCore;
using TutoringPlatformBackEnd.Models;

namespace TutoringPlatformBackEnd
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

       // public DbSet<StudyMaterial> StudyMaterials { get; set; }
        public DbSet<User> Users { get; set; }
    }
    
}
