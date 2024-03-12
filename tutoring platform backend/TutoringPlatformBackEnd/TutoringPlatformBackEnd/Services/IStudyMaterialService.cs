using TutoringPlatformBackEnd.Models;

namespace TutoringPlatformBackEnd.Services
{
    public interface IStudyMaterialService
    {
        StudyMaterial GetStudyMaterialById(int id);
        List<StudyMaterial> GetAllStudyMaterials();
        StudyMaterial CreateStudyMaterial(StudyMaterial material);
        StudyMaterial UpdateStudyMaterial(int id, StudyMaterial material);
        void DeleteStudyMaterial(int id);
    }
}
