using Microsoft.AspNetCore.Identity;

namespace AviaTour.Domain.Entities.Auth
{
    public class User : IdentityUser<long>
    {
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public string? PhotoUrl { get; set; }
        public string? Password { get; set; }
        public required string Role { get; set; }
        public bool IsDeleted { get; set; }
    }
}
