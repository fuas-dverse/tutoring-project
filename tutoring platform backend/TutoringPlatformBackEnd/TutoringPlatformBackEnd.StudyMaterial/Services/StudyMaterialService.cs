
using Microsoft.EntityFrameworkCore;
using TutoringPlatformBackEnd.StudyMaterials.Model;
using TutoringPlatformBackEnd.StudyMaterials.Services;

namespace TutoringPlatformBackEnd.StudyMaterials.Services
{
    public class StudyMaterialService : IStudyMaterialService
    {
        private readonly ApplicationDbContext _context;

        public StudyMaterialService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<StudyMaterial>> GetAllStudyMaterialsAsync()
        {
            return await _context.StudyMaterials.ToListAsync();
        }

        public async Task<StudyMaterial> GetStudyMaterialByIdAsync(int id)
        {
            return await _context.StudyMaterials.FindAsync(id);
        }

        public async Task CreateStudyMaterialAsync(StudyMaterial studyMaterial)
        {
            _context.StudyMaterials.Add(studyMaterial);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStudyMaterialAsync(StudyMaterial studyMaterial)
        {
            _context.Entry(studyMaterial).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudyMaterialAsync(int id)
        {
            var studyMaterial = await _context.StudyMaterials.FindAsync(id);
            if (studyMaterial != null)
            {
                _context.StudyMaterials.Remove(studyMaterial);
                await _context.SaveChangesAsync();
            }
        }
    }
}
