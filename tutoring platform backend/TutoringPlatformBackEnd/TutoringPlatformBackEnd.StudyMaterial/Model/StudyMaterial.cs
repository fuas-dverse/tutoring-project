using System.ComponentModel.DataAnnotations;

namespace TutoringPlatformBackEnd.StudyMaterials.Model
{
    public class StudyMaterial
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string EducationLevel { get; set; }

        public string[] Tags { get; set; }


        public string Content { get; set; }
    }
}
