using TutoringPlatformBackEnd.StudyMaterials.Model;
using TutoringPlatformBackEnd.StudyMaterials.Services;

namespace TutoringPlatformBackEnd.StudyMaterials.Actor
{
    public class StudyMaterialActor : IStudyMaterialActor
    {
        private readonly IServiceProvider _serviceProvider;

        public StudyMaterialActor(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<List<StudyMaterial>> GetAllStudyMaterialsAsync()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var studyMaterialService = scope.ServiceProvider.GetRequiredService<IStudyMaterialService>();
                return await studyMaterialService.GetAllStudyMaterialsAsync();
            }
        }

        public async Task<StudyMaterial> GetStudyMaterialByIdAsync(string id)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var studyMaterialService = scope.ServiceProvider.GetRequiredService<IStudyMaterialService>();
                return await studyMaterialService.GetStudyMaterialByIdAsync(id);
            }
        }

        public async Task<List<StudyMaterial>> GetStudyMaterialsByTutorIdAsync(string tutorId)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var studyMaterialService = scope.ServiceProvider.GetRequiredService<IStudyMaterialService>();
                return await studyMaterialService.GetStudyMaterialsByTutorIdAsync(tutorId);
            }
        }

        public async Task<StudyMaterial> CreateStudyMaterialAsync(StudyMaterial studyMaterial)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var studyMaterialService = scope.ServiceProvider.GetRequiredService<IStudyMaterialService>();
                return await studyMaterialService.CreateStudyMaterialAsync(studyMaterial);
            }
        }

        public async Task UpdateStudyMaterialAsync(string id, StudyMaterial studyMaterial)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var studyMaterialService = scope.ServiceProvider.GetRequiredService<IStudyMaterialService>();
                await studyMaterialService.UpdateStudyMaterialAsync(id, studyMaterial);
            }
        }

        public async Task DeleteStudyMaterialAsync(string id)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var studyMaterialService = scope.ServiceProvider.GetRequiredService<IStudyMaterialService>();
                await studyMaterialService.DeleteStudyMaterialAsync(id);
            }
        }
    }
}
