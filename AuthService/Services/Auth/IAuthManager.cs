using AuthService.Models;

namespace AuthService.Services.Auth
{
    public interface IAuthManager
    {
        AuthResponse AuthenticateAdmin(AuthRequest User);

        AuthResponse AuthenticateUser(AuthRequest user);

        void UserRegister(AuthRequest user);
    }
}
