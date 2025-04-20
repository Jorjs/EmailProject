using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace UserProject.Models
{
    [Table("UsersAttempts")]
    public class UsersAttempts
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public string Email { get; set; }
        public string EmailContent { get; set; }
        public bool UserClicked { get; set; }
        public bool Sent { get; set; }
    }
}



