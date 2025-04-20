using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EmailProject.Models.DTO
{
    public class AttemptDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string EmailContent { get; set; }
        public bool UserClicked { get; set; }
        public bool Sent { get; set; }
    }
}
