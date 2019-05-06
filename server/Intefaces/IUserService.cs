using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using server.Models;

namespace server.Interfaces
{
    public interface IUserService
    {
        Task<IdentityResult> AddUser(string email, string password);
        Task<SignInResult> SignIn(string email, string password);
        Task LogOut();
    }
}