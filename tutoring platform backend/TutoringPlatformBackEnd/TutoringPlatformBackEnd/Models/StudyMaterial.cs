namespace TutoringPlatformBackEnd.Models
{
    public class StudyMaterial
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string EducationLevel { get; set; }
        public List<string> Tags { get; set; }
        public string Content { get; set; }
    }
}
