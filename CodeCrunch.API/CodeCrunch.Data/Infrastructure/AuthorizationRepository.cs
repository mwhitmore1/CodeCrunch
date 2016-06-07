using CodeCrunch.Core.Domain;
using CodeCrunch.Core.Infrastructure;
using CodeCrunch.Core.Models;
using CodeCrunch.Core.Repository;
using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;

namespace CodeCrunch.Data.Infrastructure
{
    public class AuthorizationRepository : IDisposable, IAuthorizationRepository
    {
        private readonly IDatabaseFactory _databaseFactory;
        private IUserStore<User, int> _userStore;
        private RoleManager<Role, int> _AppRoleManager;
        private readonly UserManager<User, int> _userManager;

        private UserContext db;
        private UserContext Db => db ?? (db = _databaseFactory.GetDataContext());

        public AuthorizationRepository(IDatabaseFactory databaseFactory, IUserStore<User, int> userStore)
        {
            _userStore = userStore;
            _databaseFactory = databaseFactory;
            _userManager = new UserManager<User, int>(userStore);
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
        public async Task<User> FindUserByIdAsync(int id)
        {
            User user = await _userManager.FindByIdAsync(id);

            return user;
        }
        public async Task<User> FindUserByName(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }

        public void Dispose()
        {
            _userManager.Dispose();
        }
    }
}