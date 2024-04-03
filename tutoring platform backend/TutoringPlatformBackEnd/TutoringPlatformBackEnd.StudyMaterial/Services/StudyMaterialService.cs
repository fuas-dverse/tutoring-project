
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using TutoringPlatformBackEnd.StudyMaterials.Model;
using TutoringPlatformBackEnd.StudyMaterials.Services;

namespace TutoringPlatformBackEnd.StudyMaterials.Services
{
    public class StudyMaterialService : IStudyMaterialService
    {
        private readonly IMongoCollection<StudyMaterial> _studyMaterialCollection;

        public StudyMaterialService(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("StudyMaterial");
            _studyMaterialCollection = database.GetCollection<StudyMaterial>("TutoringPlatform");
        }

        public async Task<List<StudyMaterial>> GetAllStudyMaterialsAsync()
        {
            return await _studyMaterialCollection.Find(_ => true).ToListAsync();
        }

        public async Task<StudyMaterial> GetStudyMaterialByIdAsync(string id)
        {
            return await _studyMaterialCollection.Find(s => s.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<List<StudyMaterial>> GetStudyMaterialsByTutorIdAsync(string tutorId)
        {
            return await _studyMaterialCollection.Find(s => s.TutorId == tutorId).ToListAsync();
        }

        public async Task<StudyMaterial> CreateStudyMaterialAsync(StudyMaterial studyMaterial)
        {
            await _studyMaterialCollection.InsertOneAsync(studyMaterial);
            return studyMaterial;
        }

        public async Task UpdateStudyMaterialAsync(string id, StudyMaterial studyMaterial)
        {
            var objectId = ObjectId.Parse(id);
            await _studyMaterialCollection.ReplaceOneAsync(s => s.Id == objectId, studyMaterial);
        }

        public async Task DeleteStudyMaterialAsync(string id)
        {
            var objectId = ObjectId.Parse(id);
            await _studyMaterialCollection.DeleteOneAsync(s => s.Id == objectId);
        }
    }
}
