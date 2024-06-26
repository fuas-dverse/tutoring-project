﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace TutoringPlatformBackEnd.User.Models
{
    public class UserModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string AccountType { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string EducationLevel { get; set; } // Only for STUDENT
        public int Age { get; set; } // Only for STUDENT
        public string Specialization { get; set; } // Only for TUTOR
    }
}
