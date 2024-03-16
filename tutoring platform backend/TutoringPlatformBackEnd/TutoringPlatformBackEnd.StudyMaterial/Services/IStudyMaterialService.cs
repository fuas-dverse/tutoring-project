using TutoringPlatformBackEnd.StudyMaterials.Model;

namespace TutoringPlatformBackEnd.StudyMaterials.Services
{
    public interface IStudyMaterialService
    {
        Task<List<StudyMaterial>> GetAllStudyMaterialsAsync();
        Task<StudyMaterial> GetStudyMaterialByIdAsync(int id);
        Task CreateStudyMaterialAsync(StudyMaterial studyMaterial);
        Task UpdateStudyMaterialAsync(StudyMaterial studyMaterial);
        Task DeleteStudyMaterialAsync(int id);
    }
}
