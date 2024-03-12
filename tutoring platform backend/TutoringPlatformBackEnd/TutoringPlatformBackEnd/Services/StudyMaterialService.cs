using TutoringPlatformBackEnd.Models;

namespace TutoringPlatformBackEnd.Services
{
    public class StudyMaterialService : IStudyMaterialService
    {
        private List<StudyMaterial> _materials;
        private int _nextId = 1;

        public StudyMaterialService()
        {
            _materials = new List<StudyMaterial>();
        }

        public StudyMaterial GetStudyMaterialById(int id)
        {
            return _materials.FirstOrDefault(m => m.Id == id);
        }

        public List<StudyMaterial> GetAllStudyMaterials()
        {
            return _materials;
        }

        public StudyMaterial CreateStudyMaterial(StudyMaterial material)
        {
            material.Id = _nextId++;
            _materials.Add(material);
            return material;
        }

        public StudyMaterial UpdateStudyMaterial(int id, StudyMaterial material)
        {
            var existingMaterial = _materials.FirstOrDefault(m => m.Id == id);
            if (existingMaterial != null)
            {
                // Update material properties
                existingMaterial.Title = material.Title;
                existingMaterial.EducationLevel = material.EducationLevel;
                existingMaterial.Tags = material.Tags;
                existingMaterial.Content = material.Content;
            }
            return existingMaterial;
        }

        public void DeleteStudyMaterial(int id)
        {
            var materialToRemove = _materials.FirstOrDefault(m => m.Id == id);
            if (materialToRemove != null)
            {
                _materials.Remove(materialToRemove);
            }
        }
    }
}
