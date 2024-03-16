using Microsoft.EntityFrameworkCore;
using TutoringPlatformBackEnd.StudyMaterials.Model;

namespace TutoringPlatformBackEnd
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<StudyMaterial> StudyMaterials { get; set; }
       
    }
    
}
