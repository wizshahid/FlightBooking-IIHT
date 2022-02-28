using AuthService.Models;

namespace AuthService.Services.Auth
{
    public interface IAuthManager
    {
        string AuthenticateAdmin(User User);

        string AuthenticateUser(User user);

        void UserRegister(User user);
    }
}
