using Microsoft.AspNetCore.Identity;

namespace AviaTour.Domain.Entities.Auth
{
    public class User : IdentityUser<long>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? PhotoUrl { get; set; }
        public string? Password { get; set; }
        public string Role { get; set; }
        public bool IsDeleted { get; set; }
    }
}
