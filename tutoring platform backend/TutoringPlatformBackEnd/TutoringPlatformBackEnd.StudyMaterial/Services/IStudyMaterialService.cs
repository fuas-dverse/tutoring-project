using TutoringPlatformBackEnd.StudyMaterials.Model;

namespace TutoringPlatformBackEnd.StudyMaterials.Services
{
    public interface IStudyMaterialService
    {
        Task<List<StudyMaterial>> GetAllStudyMaterialsAsync();
        Task<StudyMaterial> GetStudyMaterialByIdAsync(string id);
        Task<List<StudyMaterial>> GetStudyMaterialsByTutorIdAsync(string tutorId);
        Task<StudyMaterial> CreateStudyMaterialAsync(StudyMaterial studyMaterial);
        Task UpdateStudyMaterialAsync(string id, StudyMaterial studyMaterial);
        Task DeleteStudyMaterialAsync(string id);
    }
}
