using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeCrunch.API.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;

namespace CodeCrunch.API.Infrastructure
{
    public class AuthorizationRepository : IDisposable
    {
        private UserContext _ctx;

        private UserManager<User> _userManager;

        private ApplicationRoleManager _AppRoleManager;

        public AuthorizationRepository()
        {
            _ctx = new UserContext();
            _userManager = new UserManager<User>(new UserStore<User>(_ctx));
            _AppRoleManager = new ApplicationRoleManager(new RoleStore<IdentityRole>());
        }

        public async Task<IdentityResult> RegisterUser(BootcampRegistrationModel userModel)
        {
            UserCreator creator = new UserCreator();
            User user = creator.CreateUser(userModel);

            var result = await _userManager.CreateAsync(user, userModel.Password);

            return result;
        }

        public async Task<User> FindUser(string userName, string password)
        {
            User user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public async Task<User> FindUserByIdAsync(string id)
        {
            User user = await _userManager.FindByIdAsync(id);

            return user;
        }

        public async Task<IdentityResult> CreateNewRoleAsync(IdentityRole role)
        {
            return await _AppRoleManager.CreateAsync(role);
        }

        public async Task<IList<string>> GetUsersRolesById(string id)
        {
            IList<string> result = await _userManager.GetRolesAsync(id);
            return result; 
        }

        public async Task<IdentityResult> DeleteRoleAsync(IdentityRole role)
        {
            return await _AppRoleManager.DeleteAsync(role);
        }

        public async Task<IdentityResult> RemoveUserFromRoleAsync(string user, string role)
        {
            var result = await _userManager.RemoveFromRoleAsync(user, role);
            return result;
        }

        public async Task<IdentityResult> RemoveUserFromRoleAsync(string user, string[] roles)
        {
            var result = await _userManager.RemoveFromRolesAsync(user, roles);
            return result;
        }

        public bool UserIsInRole(string user, string role)
        {
            return _userManager.IsInRole<User, string>(user, role);
        }

        public async Task<IdentityResult> AddUserToRoleAsyc(string user, string role)
        {
            return await _userManager.AddToRoleAsync(user, role);
        }

        public async Task<IdentityResult> AddUserToRolesAsyc(string user, string[] role)
        {
            return await _userManager.AddToRolesAsync(user, role);
        }

        public async Task<string> GetUserIdAsync()
        {
            string username = HttpContext.Current.User.Identity.Name;

            User user = await _userManager.FindByNameAsync(username);

            return user.Id;
        }

        public async Task<User> FindUserByName(string name)
        {
            User user = await _userManager.FindByNameAsync(name);

            return user;
        }

        public async Task<IdentityRole> FindRoleByIdAsync(string id)
        {
            return await _AppRoleManager.FindByIdAsync(id);
        }

        public IQueryable<IdentityRole> GetRoles()
        {
            return _AppRoleManager.Roles;
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();
        }
    }

    internal class Role
    {
    }
}