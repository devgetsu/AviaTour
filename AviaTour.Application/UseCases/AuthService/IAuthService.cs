using AviaTour.Domain.Entities.Auth;

namespace AviaTour.Application.UseCases.AuthService
{
    public interface IAuthService
    {
        public string GenerateToken(User user);
    }
}
