using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace TutoringPlatformBackEnd.StudyMaterials.Model
{
    public class StudyMaterial
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string TutorId { get; set; }
        public string Title { get; set; }
        public string EducationLevel { get; set; }
        public List<string> Tags { get; set; }
        public byte[] Content { get; set; } // Binary content (video/pdf/image)
    }
}
