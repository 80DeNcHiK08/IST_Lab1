using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using server.Interfaces;
using server.Models;

namespace server.Services
{
    public class UserService : IUserService
    {
        private dbContext _context;
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;

        public UserService(dbContext context, UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;            
        }

        public async Task<IdentityResult> AddUser(string email, string password)
        {
            var user = new UserEntity {Email = email};
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<SignInResult> SignIn(string email, string password)
        {
            return await _signInManager.PasswordSignInAsync(email, password, true, false);
        }

        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }
    }
}